using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SocialOpinionAPI.Core
{
    public class RequestBuilder
    {
        private const string VERSION = "1.0";
        private const string SIGNATURE_METHOD = "HMAC-SHA1";

        private readonly OAuthInfo oauth;
        private readonly string method;
        private readonly IDictionary<string, string> customParameters;
        private readonly string url;

        public RequestBuilder(OAuthInfo oauth, string method, string url)
        {
            this.oauth = oauth;
            this.method = method;
            this.url = url;
            customParameters = new Dictionary<string, string>();
        }

        public RequestBuilder AddParameter(string name, string value)
        {
            customParameters.Add(name, value.EncodeDataString());
            return this;
        }

        public string ExecuteJsonParamsInBody(string postBody)
        {
            var timespan = GetTimestamp();
            var nonce = CreateNonce();

            var parameters = new Dictionary<string, string>(customParameters);
            AddOAuthParameters(parameters, timespan, nonce);

            var signature = GenerateSignature(parameters);
            var headerValue = GenerateAuthorizationHeaderValue(parameters, signature);

            var request = (HttpWebRequest)WebRequest.Create(GetRequestUrl());
            request.Method = method;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", headerValue);

            WriteRequestBody(request, postBody);

            var response = request.GetResponse();

            string content;
          
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            request.Abort();

            return content;
        }

        public string Execute()
        {
            var timespan = GetTimestamp();
            var nonce = CreateNonce();

            var parameters = new Dictionary<string, string>(customParameters);
            AddOAuthParameters(parameters, timespan, nonce);

            var signature = GenerateSignature(parameters);
            var headerValue = GenerateAuthorizationHeaderValue(parameters, signature);

            var request = (HttpWebRequest)WebRequest.Create(GetRequestUrl());
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded";

            request.Headers.Add("Authorization", headerValue);

            WriteRequestBody(request);

            // It looks like a bug in HttpWebRequest. It throws random TimeoutExceptions
            // after some requests. Abort the request seems to work. More info: 
            // http://stackoverflow.com/questions/2252762/getrequeststream-throws-timeout-exception-randomly

            var response = request.GetResponse();

            string content;

            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            request.Abort();

            return content;
        }

        private void WriteRequestBody(HttpWebRequest request)
        {
            if (method == "GET")
                return;

            var requestBody = Encoding.ASCII.GetBytes(GetCustomParametersString());
            using (var stream = request.GetRequestStream())
                stream.Write(requestBody, 0, requestBody.Length);
        }

        private void WriteRequestBody(HttpWebRequest request, string body)
        {
            if (method == "GET")
                return;

            var requestBody = Encoding.ASCII.GetBytes(body);
            using (var stream = request.GetRequestStream())
                stream.Write(requestBody, 0, requestBody.Length);
        }

        private string GetRequestUrl()
        {
            if (method != "GET" || customParameters.Count == 0)
                return url;

            return string.Format("{0}?{1}", url, GetCustomParametersString());
        }

        private string GetCustomParametersString()
        {
            return customParameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)).Join("&");
        }

        private string GenerateAuthorizationHeaderValue(IEnumerable<KeyValuePair<string, string>> parameters, string signature)
        {
            return new StringBuilder("OAuth ")
                .Append(parameters.Concat(new KeyValuePair<string, string>("oauth_signature", signature))
                            .Where(x => x.Key.StartsWith("oauth_"))
                            .Select(x => string.Format("{0}=\"{1}\"", x.Key, x.Value.EncodeDataString()))
                            .Join(","))
                .ToString();
        }

        private string GenerateSignature(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var dataToSign = new StringBuilder()
                .Append(method).Append("&")
                .Append(url.EncodeDataString()).Append("&")
                .Append(parameters
                            .OrderBy(x => x.Key)
                            .Select(x => string.Format("{0}={1}", x.Key, x.Value))
                            .Join("&")
                            .EncodeDataString());

            var signatureKey = string.Format("{0}&{1}", oauth.ConsumerSecret.EncodeDataString(), oauth.AccessSecret.EncodeDataString());
            var sha1 = new HMACSHA1(Encoding.ASCII.GetBytes(signatureKey));

            var signatureBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(dataToSign.ToString()));
            return Convert.ToBase64String(signatureBytes);
        }

        private void AddOAuthParameters(IDictionary<string, string> parameters, string timestamp, string nonce)
        {
            parameters.Add("oauth_version", VERSION);
            parameters.Add("oauth_consumer_key", oauth.ConsumerKey);
            parameters.Add("oauth_nonce", nonce);
            parameters.Add("oauth_signature_method", SIGNATURE_METHOD);
            parameters.Add("oauth_timestamp", timestamp);
            parameters.Add("oauth_token", oauth.AccessToken);
        }

        private static string GetTimestamp()
        {
            return ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        }

        private static string CreateNonce()
        {
            return new Random().Next(0x0000000, 0x7fffffff).ToString("X8");
        }
    }

    public static class RequestBuilderExtensions
    {
        public static string Join<T>(this IEnumerable<T> items, string separator)
        {
            return string.Join(separator, items.ToArray());
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T value)
        {
            return items.Concat(new[] { value });
        }

        public static string EncodeDataString(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return Uri.EscapeDataString(value);
        }
    }

}
