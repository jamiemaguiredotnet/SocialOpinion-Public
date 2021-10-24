using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class ComplianceClient
    {

        private string _createJob = "https://api.twitter.com/2/compliance/jobs";
        private string _getJobs = "https://api.twitter.com/2/compliance/jobs";
        private string _getJobById = "https://api.twitter.com/2/compliance/jobs/:id";

        private static HttpClient _httpClient = new HttpClient();

        private OAuthInfo _oAuthInfo;

        public ComplianceClient(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            _oAuthInfo = new OAuthInfo
            {
                AccessSecret = accessTokenSecret,
                AccessToken = accessToken,
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret
            };
        }

        public string Upload(string url, string data)
        {
            using (var content = new StringContent(data, System.Text.Encoding.UTF8, "text/plain"))
            {
                HttpResponseMessage result = _httpClient.PostAsync(url, content).Result;

                string returnValue = result.Content.ReadAsStringAsync().Result;

                throw new Exception($"Failed to PUT data: ({result.StatusCode}): {returnValue}");
            }
        }

        public string CreateJob(string job_name, string resumable)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "POST", _createJob);

            rb.AddParameter("job_name", job_name);
            rb.AddParameter("resumable", resumable);

            string result = rb.Execute();

            return result;
        }

        public string GetJobs(string status)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _createJob);

            //rb.AddParameter("start_time", start_time);
            //rb.AddParameter("end_time", start_time);
            //rb.AddParameter("status", resumable);

            string result = rb.Execute();

            return result;
        }

    }
}
