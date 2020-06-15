using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SocialOpinionAPI.Core
{
    public class BearerTokenRequestBuilder
    {
        private readonly OAuthInfo _oauth;
        private readonly string _method;
        private readonly string _url;
        private readonly IDictionary<string, string> _customParameters;

        public BearerTokenRequestBuilder(OAuthInfo oauth, string method, string url)
        {
            _oauth = oauth;
            _method = method;
            _url = url;
            _customParameters = new Dictionary<string, string>();
        }

        public BearerTokenRequestBuilder AddParameter(string name, string value)
        {
            _customParameters.Add(name, value.EncodeDataString());
            return this;
        }

        private string GetBearerToken()
        {
            // step 1:encode the consumer key and secret
            string bearerRequest =
                HttpUtility.UrlEncode(_oauth.ConsumerKey) + ":" + HttpUtility.UrlEncode(_oauth.ConsumerSecret);

            bearerRequest =
                Convert.ToBase64String(Encoding.UTF8.GetBytes(bearerRequest));

            // step 2: setup the request to obtain the Bearer Token from 
            //         the Twitter API using the key and secret
            WebRequest request =
                WebRequest.Create("https://api.twitter.com/oauth2/token");

            request.Headers.Add("Authorization", "Basic " + bearerRequest);
            request.Method = "POST";
            request.ContentType =
                "application/x-www-form-urlencoded;charset=UTF-8";

            // step 3: set the OAuth Grant Type. 
            // Using this Grant Type, we get a Bearer Token from Twitter if our 
            // Consumer Key and Secret are valid. 
            // (Twitter current only support "grant_type=Client_Credential)
            string grantType =
                "grant_type=client_credentials";
            byte[] requestContent = Encoding.UTF8.GetBytes(grantType);

            // fetch the stream
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestContent, 0, requestContent.Length);
            requestStream.Close();

            string jsonResponse = string.Empty;

            // get the response
            HttpWebResponse response =
                (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                jsonResponse = new StreamReader(responseStream).ReadToEnd();
            }

            JObject jObject = JObject.Parse(jsonResponse);

            // return the bearer token
            return jObject["access_token"].ToString();
        }

        private string GetCustomParametersString()
        {
            return _customParameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)).Join("&");
        }

        private string GetRequestUrl()
        {
            if (_method != "GET" || _customParameters.Count == 0)
                return _url;

            return string.Format("{0}?{1}", _url, GetCustomParametersString());
        }

        public string Execute(string jsonBody = "")
        {
            string requestUrl = GetRequestUrl();

            if (_method == "GET")
            {
                return SendGET(requestUrl);
            }

            if(_method =="POST")
            {
                return SendPOST(requestUrl, jsonBody);
            }

            throw new NotImplementedException("Method not yet supported.");
        }

        private string SendGET(string address)
        {
            WebRequest request = WebRequest.Create(address);

            request.Headers.Add("Authorization", "Bearer " + GetBearerToken());
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            string responseJson = string.Empty;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                responseJson = new StreamReader(responseStream).ReadToEnd();

                return responseJson;
            }
            else
            {
                return "Error:" + response.StatusDescription;
            }
        }

        public string SendPOST(string address, string jsonBody)
        {
            GetBearerToken();

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(address);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + GetBearerToken());
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            string strRequestContent = jsonBody;
            byte[] bytearrayRequestContent = System.Text.Encoding.UTF8.GetBytes(strRequestContent);
            System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(bytearrayRequestContent, 0, bytearrayRequestContent.Length);
            requestStream.Close();

            string responseJson = string.Empty;

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

            System.IO.Stream responseStream = response.GetResponseStream();
            responseJson = new StreamReader(responseStream).ReadToEnd();

            return responseJson;
        }

    }
}
