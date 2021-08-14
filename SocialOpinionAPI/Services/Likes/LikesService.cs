using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Likes;
using SocialOpinionAPI.Models.Likes;
using System;
using System.Collections.Generic;

namespace SocialOpinionAPI.Services.Likes
{
    public class LikesService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        private const string _defaultToken = "000000";
        private string _expansionsFields = "attachments.poll_ids,attachments.media_keys,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,referenced_tweets.id,referenced_tweets.id.author_id";
        private string _TweetFields = "attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,public_metrics,possibly_sensitive,referenced_tweets,reply_settings,source,text,withheld";
        private string _MediaFields = "duration_ms,height,media_key,non_public_metrics,organic_metrics,preview_image_url,promoted_metrics,public_metrics,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";
        private int _defaultTweetsPerPage = 10;

        public LikesService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LikesDTO, LikesModel>();
                cfg.CreateMap<DTO.Likes.Datum, Models.Likes.Datum>();
                cfg.CreateMap<DTO.Likes.Entities, Models.Likes.Entities>();
                cfg.CreateMap<DTO.Likes.Description, Models.Likes.Description>();
                cfg.CreateMap<DTO.Likes.Annotation, Models.Likes.Annotation>();
                cfg.CreateMap<DTO.Likes.PublicMetrics, Models.Likes.PublicMetrics>();
                cfg.CreateMap<DTO.Likes.ReferencedTweet, Models.Likes.ReferencedTweet>();
                cfg.CreateMap<DTO.Likes.Url, Models.Likes.Url>();
                cfg.CreateMap<DTO.Likes.Mention, Models.Likes.Mention>();
                cfg.CreateMap<DTO.Likes.Meta, Models.Likes.Meta>();
                cfg.CreateMap<DTO.Likes.Includes, Models.Likes.Includes>();
                cfg.CreateMap<DTO.Likes.User, Models.Likes.User>();
                cfg.CreateMap<DTO.Likes.Tweet, Models.Likes.Tweet>();
                cfg.CreateMap<DTO.Likes.Hashtag, Models.Likes.Hashtag>();

                cfg.CreateMap<LikesDTO, LikesModel>();
                cfg.CreateMap<DTO.Likes.Datum, Models.Likes.Datum>();
                cfg.CreateMap<DTO.Likes.Meta, Models.Likes.Meta>();
                cfg.CreateMap<DTO.Likes.ContextAnnotation, Models.Likes.ContextAnnotation>();
                cfg.CreateMap<DTO.Likes.PublicMetrics, Models.Likes.PublicMetrics>();
                cfg.CreateMap<DTO.Likes.Domain, Models.Likes.Domain>();
                cfg.CreateMap<DTO.Likes.Entity, Models.Likes.Entity>();
                cfg.CreateMap<DTO.Likes.Entities, Models.Likes.Entities>();
            });

            _iMapper = config.CreateMapper();
        }

        /// <summary>
        /// returns a list of users and metadata that liked the given tweet id
        /// </summary>
        /// <param name="tweetId">the tweet id of interest</param>
        /// <returns></returns>
        public List<Models.Likes.User> GetLikingUsers(string tweetId)
        {
            LikesClient likesClient = new LikesClient(_oAuthInfo);
            List<Models.Likes.User> resultsList = new List<Models.Likes.User>();

            string response = string.Empty;

            response = likesClient.GetLikingUsers(tweetId, _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
            
            UserDTO resultsDTO = JsonConvert.DeserializeObject<UserDTO>(response);

            foreach(var user in resultsDTO.data)
            {
                Models.Likes.User model = _iMapper.Map<DTO.Likes.User, Models.Likes.User>(user);
                resultsList.Add(model);
            }

            return resultsList;
        }

        /// <summary>
        /// returns a list of tweets that a user has Liked
        /// </summary>
        /// <param name="id">the user id of interest</param>
        /// <param name="maxResults">how many tweets to fetch</param>
        /// <param name="maxAttempts">how many times to try if connection issues occur</param>
        /// <returns></returns>
        public List<LikesModel> GetUsersLikedTweets(string id, int maxResults, int maxAttempts)
        {
            LikesClient likesClient = new LikesClient(_oAuthInfo);
            List<LikesModel> resultsList = new List<LikesModel>();

            string nextToken = _defaultToken;
            int totalFetched = 0;
            int numAttempts = 0;

            while (!string.IsNullOrEmpty(nextToken) || totalFetched <= maxResults)
            {
                string response = string.Empty;

                if (nextToken != _defaultToken && !string.IsNullOrEmpty(nextToken))
                {
                    response = likesClient.GetUsersLikedTweets(id, maxResults.ToString(), nextToken, _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }
                else
                {
                    response = likesClient.GetUsersLikedTweets(id, maxResults.ToString(), null, _expansionsFields, _TweetFields, _MediaFields, _PlaceFields, _PollFields, _UserFields);
                }

                LikesDTO resultsDTO = JsonConvert.DeserializeObject<LikesDTO>(response);
                LikesModel model = _iMapper.Map<LikesDTO, LikesModel>(resultsDTO);
                resultsList.Add(model);

                totalFetched += resultsDTO.Meta.ResultCount;

                numAttempts = numAttempts + 1;

                if (numAttempts == maxAttempts)
                {
                    // exit as we dont want blocked by Twitter                    
                    Console.WriteLine("Backing off from Twitter API. Reached Max Attempts when fetching Likes for account: " + id);
                    return resultsList;
                }

                if (totalFetched >= maxResults)
                {
                    break;
                }

                nextToken = resultsDTO.Meta.NextToken;
            }
            return resultsList;
        }

        /// <summary>
        /// Causes the user ID identified in the path parameter to Like the target Tweet.
        /// </summary>
        /// <param name="userid">The user ID who you are liking a Tweet on behalf of. It must match your own user ID or that of an authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="tweetId">The ID of the Tweet that you would like the user id to Like</param>
        public bool LikeTweet(string userid, string tweetId)
        {
            LikesClient likesClient = new LikesClient(_oAuthInfo);

            LikeTweetDTO likeTweetDTO = new LikeTweetDTO { tweet_id = tweetId };
            string tweetToLike = JsonConvert.SerializeObject(likeTweetDTO);

            string response = likesClient.LikeTweet(userid, tweetToLike);
            LikeTweetResponseDTO resultsDTO = JsonConvert.DeserializeObject<LikeTweetResponseDTO>(response);

            return resultsDTO.data.liked;
        }

        /// <summary>
        /// Allows a user or authenticated user ID to unlike a Tweet. 
        /// </summary>
        /// <param name="userid">The user ID who you are removing a Like of a Tweet on behalf of. It must match your own user ID or that of an authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="tweetId">The ID of the Tweet that you would like the id to unlike.</param>
        public bool UnLikeTweet(string userid, string tweetId)
        {
            LikesClient likesClient = new LikesClient(_oAuthInfo);

            string response = likesClient.UnLikeTweet(userid, tweetId);
            UnLikeTweetResponseDTO resultsDTO = JsonConvert.DeserializeObject<UnLikeTweetResponseDTO>(response);

            return resultsDTO.data.liked;
        }
    }



}
