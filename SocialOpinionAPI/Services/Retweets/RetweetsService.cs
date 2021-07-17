using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Retweet;
using SocialOpinionAPI.DTO.Users;
using SocialOpinionAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Retweets
{
    public class RetweetsService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        
        private string _expansionsFields = "pinned_tweet_id";
        private string _TweetFields = "attachments,author_id,context_annotations,created_at,entities,geo,id,in_reply_to_user_id,lang,possibly_sensitive,organic_metrics,public_metrics,referenced_tweets,source,text,withheld";
        private string _MediaFields = "duration_ms,height,media_key,preview_image_url,public_metrics,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";

        public RetweetsService(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserModel>();
                cfg.CreateMap<UsersDTO, UsersModel>();
                cfg.CreateMap<DTO.Users.Data, Models.Users.Data>();
                cfg.CreateMap<DTO.Users.Mention, Models.Users.Mention>();
                cfg.CreateMap<DTO.Users.Hashtag, Models.Users.Hashtag>();
                cfg.CreateMap<DTO.Users.Entities, Models.Users.Entities>();
                cfg.CreateMap<DTO.Users.PublicMetrics, Models.Users.PublicMetrics>();
                cfg.CreateMap<DTO.Users.Url, Models.Users.Url>();
                cfg.CreateMap<DTO.Users.Urls, Models.Users.Urls>();
                cfg.CreateMap<DTO.Users.Description, Models.Users.Description>();
                cfg.CreateMap<DTO.Users.Includes, Models.Users.Includes>();
                cfg.CreateMap<DTO.Users.Tweet, Models.Users.Tweet>();
                cfg.CreateMap<DTO.Users.Attachments, Models.Users.Attachments>();
            });

            _iMapper = config.CreateMapper();
        }

        /// <summary>
        /// Causes the user ID identified in the path parameter to Retweet the target Tweet.
        /// </summary>
        /// <param name="id">The user ID who you are Retweeting a Tweet on behalf of. It must match your own user ID or that of an authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="tweet_id">The ID of the Tweet that you would like the user id to Retweet.</param>
        public bool Retweet(string id, string tweet_id)
        {
            RetweetsClient client = new RetweetsClient(_oAuthInfo);

            RetweetDTO rtDTO = new RetweetDTO { tweet_id = tweet_id };
            string retweet = JsonConvert.SerializeObject(rtDTO);

            string response = client.Retweet(id, retweet);

            RetweetResponseDTO resultsDTO = JsonConvert.DeserializeObject<RetweetResponseDTO>(response);

            return resultsDTO.data.retweeted;
        }

        /// <summary>
        /// Allows a user or authenticated user ID to remove the Retweet of a Tweet. The request succeeds with no action when the user sends a request to a user they're not Retweeting the Tweet or have already removed the Retweet of.
        /// </summary>
        /// <param name="id">The user ID who you are removing a the Retweet of a Tweet on behalf of. It must match your own user ID or that of an authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="source_tweet_id">The ID of the Tweet that you would like the id to remove the Retweet of.</param>
        public bool RemoveRetweet(string id, string source_tweet_id)
        {
            RetweetsClient client = new RetweetsClient(_oAuthInfo);

            string response = client.RemoveRetweet(id, source_tweet_id);

            RetweetResponseDTO resultsDTO = JsonConvert.DeserializeObject<RetweetResponseDTO>(response);

            return resultsDTO.data.retweeted;
        }

        /// <summary>
        /// Allows you to get information about who has Retweeted a Tweet.
        /// </summary>
        /// <param name="id">Tweet ID of the Tweet to request Retweeting users of.</param>
        /// <returns>Users Model with list of users</returns>
        public UsersModel GetWhoRetweetedTweet(string id)
        {
            RetweetsClient client = new RetweetsClient(_oAuthInfo);

            string userJson = client.GetWhoRetweetedTweet(id,_expansionsFields, _TweetFields, _MediaFields, _PollFields, _PlaceFields, _UserFields);

            UsersDTO resultsDTO = JsonConvert.DeserializeObject<UsersDTO>(userJson);

            UsersModel models = _iMapper.Map<UsersDTO, UsersModel>(resultsDTO);

            return models;
        }
    }
}
