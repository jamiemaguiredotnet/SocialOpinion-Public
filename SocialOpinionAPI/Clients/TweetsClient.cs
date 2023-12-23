using OAuth;
using RestSharp;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Tweets;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SocialOpinionAPI.Clients
{
    public class TweetsClient
    {

        private string _baseUrl = "https://api.twitter.com";
        private string _tweetEndpointV1 = "https://api.twitter.com/1.1/statuses/update.json";
        
        private string _tweetsEndpointV2 = "/2/tweets?";
        //private string _tweetsEndpointV2 = "https://api.twitter.com/2/tweets";
        private string _tweetCounts = "https://api.twitter.com/2/tweets/counts/recent";

        private OAuthInfo _oAuthInfo;

        public TweetsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweet(string id, string expansions, string tweet_fields, string media_fields,
                               string poll_fields, string place_fields, string user_fields)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _baseUrl + _tweetsEndpointV2 + id);

            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("media.fields", media_fields);
            rb.AddParameter("place.fields", place_fields);
            rb.AddParameter("poll.fields", poll_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string GetTweets(List<string> ids, string expansions, string tweet_fields, string media_fields,
                              string poll_fields, string place_fields, string user_fields)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _baseUrl + _tweetsEndpointV2);

            rb.AddParameter("ids", string.Join(",", ids));
            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("media.fields", media_fields);
            rb.AddParameter("place.fields", place_fields);
            rb.AddParameter("poll.fields", poll_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string CountsRecent(string query, string end_time, string granularity, string since_id,
                                   string start_time, string until_id)
        {
            BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", _tweetCounts);

            rb.AddParameter("query", query);

            if (!string.IsNullOrEmpty(end_time))
            {
                rb.AddParameter("end_time", end_time);
            }

            rb.AddParameter("granularity", granularity.ToLower());

            if (!string.IsNullOrEmpty(since_id))
            {
                rb.AddParameter("since_id", since_id);
            }

            if (!string.IsNullOrEmpty(start_time))
            {
                rb.AddParameter("start_time", start_time);
            }

            if (!string.IsNullOrEmpty(until_id))
            {
                rb.AddParameter("until_id", until_id);
            }

            return rb.Execute();
        }

        public string PostTweet(string text)
        {
            var rb = new RequestBuilder(_oAuthInfo, "POST", _tweetsEndpoint);
            var json = JsonConvert.SerializeObject(new PostTweetDTO { text = text });
            
            var result = rb.ExecuteJsonParamsInBody(json);

            return result;
        }

        
        public string PostTweetV2(string text)
        {
            OAuthRequest oAuthRequest = 
                OAuthRequest.ForProtectedResource("POST", _oAuthInfo.ConsumerKey, _oAuthInfo.ConsumerSecret, 
                                                          _oAuthInfo.AccessToken, _oAuthInfo.AccessSecret);
            
            oAuthRequest.RequestUrl = _baseUrl + _tweetsEndpointV2;
            
            string oAuthHeaderValue = oAuthRequest.GetAuthorizationHeader();

            var options = new RestClientOptions(_baseUrl)
            {
                MaxTimeout = -1,
            };
            
            var client = new RestClient(options);
            
            var request = new RestRequest(_baseUrl + _tweetsEndpointV2, Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", oAuthHeaderValue);

            // add the content to post
            request.AddStringBody(text, DataFormat.Json);
            RestResponse response = client.Execute(request);

            if (response != null)
            {
                return response.Content;
            }
            else
            {
                return response.Content;
            }

        }
    }
}