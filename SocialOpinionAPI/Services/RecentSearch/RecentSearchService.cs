using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.RecentSearch;
using SocialOpinionAPI.Models.RecentSearch;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace SocialOpinionAPI.Services.RecentSearch
{
    public class RecentSearchService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        private const string _defaultToken = "000000";
        private string _expansionsFields = "attachments.poll_ids,attachments.media_keys,author_id,geo.place_id,in_reply_to_user_id,referenced_tweets.id";
        private string _TweetFields = "author_id,context_annotations,created_at,entities,geo,id,in_reply_to_user_id,lang,possibly_sensitive,public_metrics,referenced_tweets,source,text,withheld";
        private string _MediaFields = "duration_ms,height,media_key,non_public_metrics,preview_image_url,public_metrics,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";
        private int _defaultTweetsPerPage = 100;

        public RecentSearchService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RecentSearchResultsDTO, RecentSearchResultsModel>();
                cfg.CreateMap<DTO.RecentSearch.Datum, Models.RecentSearch.Datum>();
                cfg.CreateMap<DTO.RecentSearch.ContextAnnotation, Models.RecentSearch.ContextAnnotation>();
                cfg.CreateMap<DTO.RecentSearch.Attachments, Models.RecentSearch.Attachments>();
                cfg.CreateMap<DTO.RecentSearch.Domain, Models.RecentSearch.Domain>();
                cfg.CreateMap<DTO.RecentSearch.Entity, Models.RecentSearch.Entity>();
                cfg.CreateMap<DTO.RecentSearch.Image, Models.RecentSearch.Image>();
                cfg.CreateMap<DTO.RecentSearch.Annotation, Models.RecentSearch.Annotation>();
                cfg.CreateMap<DTO.RecentSearch.Mention, Models.RecentSearch.Mention>();
                cfg.CreateMap<DTO.RecentSearch.Hashtag, Models.RecentSearch.Hashtag>();
                cfg.CreateMap<DTO.RecentSearch.Entities, Models.RecentSearch.Entities>();
                cfg.CreateMap<DTO.RecentSearch.PublicMetrics, Models.RecentSearch.PublicMetrics>();
                cfg.CreateMap<DTO.RecentSearch.UserPublicMetrics, Models.RecentSearch.UserPublicMetrics>();
                cfg.CreateMap<DTO.RecentSearch.ReferencedTweet, Models.RecentSearch.ReferencedTweet>();
                cfg.CreateMap<DTO.RecentSearch.Medium, Models.RecentSearch.Medium>();
                cfg.CreateMap<DTO.RecentSearch.User, Models.RecentSearch.User>();
                cfg.CreateMap<DTO.RecentSearch.Tweet, Models.RecentSearch.Tweet>();
                cfg.CreateMap<DTO.RecentSearch.Includes, Models.RecentSearch.Includes>();
                cfg.CreateMap<DTO.RecentSearch.Meta, Models.RecentSearch.Meta>();
                cfg.CreateMap<DTO.RecentSearch.Url, Models.RecentSearch.Url>();

            });

            _iMapper = config.CreateMapper();
        }


        public List<RecentSearchResultsModel> SearchTweets(string query, int maxResults, int maxAttempts, string expansionFields = "",
                                                           string tweetFields = "", string mediaFields = "",
                                                           string placeFields = "", string pollFields = "", string userFields = "")
        {
            RecentSearchClient client = new RecentSearchClient(_oAuthInfo);
            List<RecentSearchResultsModel> resultsList = new List<RecentSearchResultsModel>();

            string nextToken = _defaultToken;
            int totalFetched = 0;
            int numAttempts = 0;

            if (!string.IsNullOrEmpty(expansionFields))
            {
                _expansionsFields = expansionFields;
            }
            if (!string.IsNullOrEmpty(tweetFields))
            {
                _TweetFields = tweetFields;
            }
            if (!string.IsNullOrEmpty(mediaFields))
            {
                _MediaFields = mediaFields;
            }
            if (!string.IsNullOrEmpty(placeFields))
            {
                _PlaceFields = placeFields;
            }
            if (!string.IsNullOrEmpty(pollFields))
            {
                _PollFields = pollFields;
            }
            if (!string.IsNullOrEmpty(userFields))
            {
                _UserFields = userFields;
            }

            // page through the results until no more "next" tokens or we hit the max number of results we want
            // todo: implement rate limit checking / back-off
            while (!string.IsNullOrEmpty(nextToken) || totalFetched <= maxResults)
            {
                string response = string.Empty;

                if (nextToken != _defaultToken)
                {
                    response = client.GetTweets(query, "", "", "", "", _defaultTweetsPerPage, nextToken, _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }
                else
                {
                    response = client.GetTweets(query, "", "", "", "", _defaultTweetsPerPage, "", _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }

                RecentSearchResultsDTO resultsDTO = JsonConvert.DeserializeObject<RecentSearchResultsDTO>(response);
                RecentSearchResultsModel model = _iMapper.Map<RecentSearchResultsDTO, RecentSearchResultsModel>(resultsDTO);
                resultsList.Add(model);

                totalFetched += resultsDTO.meta.result_count;

                if (totalFetched >= maxResults)
                {
                    break;
                }

                numAttempts = numAttempts + 1;

                if (numAttempts == maxAttempts)
                {
                    // exit as we dont want blocked by Twitter
                    Console.WriteLine("Backing off from Twitter API. Reached Max Attempts for query " + query);
                    return resultsList;
                    //break;
                }

                nextToken = resultsDTO.meta.next_token;
            }
            return resultsList;
        }

        public List<RecentSearchResultsModel> SearchTweets(string query, int maxResults, string sinceid, string untilid, int maxAttempts)
        {
            RecentSearchClient client = new RecentSearchClient(_oAuthInfo);
            List<RecentSearchResultsModel> resultsList = new List<RecentSearchResultsModel>();

            string nextToken = _defaultToken;
            int totalFetched = 0;
            int numAttempts = 0;

            // page through the results until no more "next" tokens or we hit the max number of results we want
            // todo: implement rate limit checking / back-off
            while (!string.IsNullOrEmpty(nextToken) || totalFetched <= maxResults)
            {
                string response = string.Empty;

                if (nextToken != _defaultToken)
                {
                    response = client.GetTweets(query, "", "", sinceid, untilid, _defaultTweetsPerPage, nextToken, _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }
                else
                {
                    response = client.GetTweets(query, "", "", sinceid, untilid, _defaultTweetsPerPage, "", _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }

                RecentSearchResultsDTO resultsDTO = JsonConvert.DeserializeObject<RecentSearchResultsDTO>(response);
                RecentSearchResultsModel model = _iMapper.Map<RecentSearchResultsDTO, RecentSearchResultsModel>(resultsDTO);
                resultsList.Add(model);

                totalFetched += resultsDTO.meta.result_count;

                if (totalFetched >= maxResults)
                {
                    break;
                }

                numAttempts = numAttempts + 1;

                if (numAttempts == maxAttempts)
                {
                    // exit as we dont want blocked by Twitter                    
                    Console.WriteLine("Backing off from Twitter API. Reached Max Attempts for query " + query);
                    return resultsList;
                }

                nextToken = resultsDTO.meta.next_token;
            }
            return resultsList;
        }

        public List<RecentSearchResultsModel> SearchTweets(string query, int maxResults, int maxAttempts)
        {
            RecentSearchClient client = new RecentSearchClient(_oAuthInfo);
            List<RecentSearchResultsModel> resultsList = new List<RecentSearchResultsModel>();

            string nextToken = _defaultToken;
            int totalFetched = 0;
            int numAttempts = 0;

            // page through the results until no more "next" tokens or we hit the max number of results we want
            // todo: implement rate limit checking / back-off

            while (!string.IsNullOrEmpty(nextToken) || totalFetched <= maxResults)
            {
                string response = string.Empty;

                if (nextToken != _defaultToken && !string.IsNullOrEmpty(nextToken))
                {
                    response = client.GetTweets(query, "", "", "", "", _defaultTweetsPerPage, nextToken, _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }
                else
                {
                    response = client.GetTweets(query, "", "", "", "", _defaultTweetsPerPage, "", _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }

                RecentSearchResultsDTO resultsDTO = JsonConvert.DeserializeObject<RecentSearchResultsDTO>(response);
                RecentSearchResultsModel model = _iMapper.Map<RecentSearchResultsDTO, RecentSearchResultsModel>(resultsDTO);
                resultsList.Add(model);

                totalFetched += resultsDTO.meta.result_count;
                
                numAttempts = numAttempts + 1;

                if(numAttempts == maxAttempts)
                {
                    // exit as we dont want blocked by Twitter                    
                    Console.WriteLine("Backing off from Twitter API. Reached Max Attempts for query " + query);
                    return resultsList;
                    //break;
                }

                if (totalFetched >= maxResults)
                {
                    break;
                }

                nextToken = resultsDTO.meta.next_token;
            }
            return resultsList;
        }

      

    }
}
