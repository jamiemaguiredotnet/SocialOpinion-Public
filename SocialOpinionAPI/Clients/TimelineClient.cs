using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class TimelineClient
    {
        private string _userTweetsTimeline = "https://api.twitter.com/2/users/:id/tweets";
        private string _userMentionTimeLine = "https://api.twitter.com/2/users/:id/mentions";
        private OAuthInfo _oAuthInfo;

        public TimelineClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweetsTimeline(string id, DateTime? endtime, string exclude,
                               string expansions, int maxResults, string mediafields,
                               string pagination_token, string placefields, string pollfields,
                               string since_id, DateTime? start_time, string tweet_fields,
                               string until_id, string user_fields)
        {
            _userTweetsTimeline = _userTweetsTimeline.Replace(":id", id);

            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _userTweetsTimeline);

            if (endtime.HasValue)
            {
                rb.AddParameter("end_time", endtime.Value.ToString());
            }

            if (!string.IsNullOrEmpty(exclude))
            {
                rb.AddParameter("exclude", exclude);
            }

            rb.AddParameter("expansions", expansions);

            if (maxResults>0)
            {
                rb.AddParameter("max_results", maxResults.ToString());
            }

            if (!string.IsNullOrEmpty(mediafields))
            {
                rb.AddParameter("media.fields", mediafields);
            }

            if (!string.IsNullOrEmpty(pagination_token))
            {
                rb.AddParameter("pagination_token", pagination_token);
            }

            if (!string.IsNullOrEmpty(placefields))
            {
                rb.AddParameter("place.fields", placefields);
            }

            if (!string.IsNullOrEmpty(pollfields))
            {
                rb.AddParameter("poll.fields", pollfields);
            }

            if (!string.IsNullOrEmpty(since_id))
            {
                rb.AddParameter("since_id", since_id);
            }

            if (start_time.HasValue)
            {
                rb.AddParameter("start_time", start_time.Value.ToString());
            }

            if (!string.IsNullOrEmpty(tweet_fields))
            {
                rb.AddParameter("tweet.fields", tweet_fields);
            }

            if (!string.IsNullOrEmpty(until_id))
            {
                rb.AddParameter("until_id", until_id);
            }

            if (!string.IsNullOrEmpty(user_fields))
            {
                rb.AddParameter("user.fields", user_fields);
            }

            string result = rb.Execute();

            return result;
        }

        public string GetMentionedTimeline(string id, DateTime? endtime, string expansions, int maxResults, 
                                           string mediafields, string pagination_token, string placefields, string pollfields,
                                           string since_id, DateTime? start_time, string tweet_fields,
                                           string until_id, string user_fields)
        {
            _userMentionTimeLine = _userMentionTimeLine.Replace(":id", id);

            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _userMentionTimeLine);

            if (endtime.HasValue)
            {
                rb.AddParameter("end_time", endtime.Value.ToString());
            }

            rb.AddParameter("expansions", expansions);

            if (maxResults>0)
            {
                rb.AddParameter("max_results", maxResults.ToString());
            }

            if (!string.IsNullOrEmpty(mediafields))
            {
                rb.AddParameter("media.fields", mediafields);
            }

            if (!string.IsNullOrEmpty(pagination_token))
            {
                rb.AddParameter("pagination_token", pagination_token);
            }

            if (!string.IsNullOrEmpty(placefields))
            {
                rb.AddParameter("place.fields", placefields);
            }

            if (!string.IsNullOrEmpty(pollfields))
            {
                rb.AddParameter("poll.fields", pollfields);
            }

            if (!string.IsNullOrEmpty(since_id))
            {
                rb.AddParameter("since_id", since_id);
            }

            if (start_time.HasValue)
            {
                rb.AddParameter("start_time", start_time.Value.ToString());
            }

            if (!string.IsNullOrEmpty(tweet_fields))
            {
                rb.AddParameter("tweet.fields", tweet_fields);
            }

            if (!string.IsNullOrEmpty(until_id))
            {
                rb.AddParameter("until_id", until_id);
            }

            if (!string.IsNullOrEmpty(user_fields))
            {
                rb.AddParameter("user.fields", user_fields);
            }

            string result = rb.Execute();

            return result;
        }
    }
}
