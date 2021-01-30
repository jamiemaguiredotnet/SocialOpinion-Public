using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Users;
using SocialOpinionAPI.DTO.Users.Followers;
using SocialOpinionAPI.DTO.Users.Following;
using SocialOpinionAPI.Models.Followers;
using SocialOpinionAPI.Models.Following;
using SocialOpinionAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Users
{
    public class UserService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        private string _expansionsFields = "pinned_tweet_id";
        private string _TweetFields = "attachments,author_id,created_at,entities,geo,id,in_reply_to_user_id,lang,possibly_sensitive,public_metrics,referenced_tweets,source,text,withheld,reply_settings";
        private string _MediaFields = "duration_ms,height,media_key,preview_image_url,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        //private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld,non_public_metrics";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,url,username,verified,withheld";


        public UserService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

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

                cfg.CreateMap<DTO.Users.Followers.FollowersDTO, Models.Followers.FollowersModel>();
                cfg.CreateMap<DTO.Users.Followers.Datum, Models.Followers.Datum>();
                cfg.CreateMap<DTO.Users.Followers.Meta, Models.Followers.Meta>();
                cfg.CreateMap<DTO.Users.Followers.Error, Models.Followers.Error>();
                cfg.CreateMap<DTO.Users.Followers.PublicMetrics, Models.Followers.PublicMetrics>();
                cfg.CreateMap<DTO.Users.Followers.Description, Models.Followers.Description>();
                cfg.CreateMap<DTO.Users.Followers.Mention, Models.Followers.Mention>();
                cfg.CreateMap<DTO.Users.Followers.Hashtag, Models.Followers.Hashtag>();
                cfg.CreateMap<DTO.Users.Followers.Entities, Models.Followers.Entities>();
                cfg.CreateMap<DTO.Users.Followers.Url, Models.Followers.Url>();
                cfg.CreateMap<DTO.Users.Followers.Description, Models.Followers.Description>();
                
                cfg.CreateMap<DTO.Users.Following.FollowingDTO, Models.Following.FollowingModel>();
                cfg.CreateMap<DTO.Users.Following.Datum, Models.Following.Datum>();
                cfg.CreateMap<DTO.Users.Following.Meta, Models.Following.Meta>();
                cfg.CreateMap<DTO.Users.Following.Error, Models.Following.Error>();
                cfg.CreateMap<DTO.Users.Following.PublicMetrics, Models.Following.PublicMetrics>();
                cfg.CreateMap<DTO.Users.Following.Description, Models.Following.Description>();
                cfg.CreateMap<DTO.Users.Following.Mention, Models.Following.Mention>();
                cfg.CreateMap<DTO.Users.Following.Hashtag, Models.Following.Hashtag>();
                cfg.CreateMap<DTO.Users.Following.Entities, Models.Following.Entities>();
                cfg.CreateMap<DTO.Users.Following.Url, Models.Following.Url>();
                cfg.CreateMap<DTO.Users.Following.Description, Models.Following.Description>();
            });

            _iMapper = config.CreateMapper();
        }

        public UserModel GetUser(string username)
        {
            UsersClient client = new UsersClient(_oAuthInfo);

            string userJson = client.GetSingleUser(username, _expansionsFields, _TweetFields, _MediaFields, _PollFields, _PlaceFields, _UserFields);

            UserDTO resultsDTO = JsonConvert.DeserializeObject<UserDTO>(userJson);

            UserModel model = _iMapper.Map<UserDTO, UserModel>(resultsDTO);

            return model;
        }

        public UsersModel GetUsers(List<string> usernames)
        {
            UsersClient client = new UsersClient(_oAuthInfo);

            string userJson = client.GetUsers(usernames, _expansionsFields, _TweetFields, _MediaFields, _PollFields, _PlaceFields, _UserFields);

            UsersDTO resultsDTO = JsonConvert.DeserializeObject<UsersDTO>(userJson);

            UsersModel models = _iMapper.Map<UsersDTO, UsersModel> (resultsDTO);

            return models;
        }

        public FollowersModel GetFollowers(string id, string maxResults, string paginationToken)
        {
            UsersClient client = new UsersClient(_oAuthInfo);

            // these override the base behaviour for the user service when fetching followers
            string tweetFields = "attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,public_metrics,organic_metrics,promoted_metrics,possibly_sensitive,referenced_tweets,reply_settings,source,text,withheld";
            string userFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";
            
            string followersJson = client.GetFollowers(id, _expansionsFields, maxResults, paginationToken, tweetFields, userFields);

            FollowersDTO resultsDTO = JsonConvert.DeserializeObject<FollowersDTO>(followersJson);

            FollowersModel models = _iMapper.Map<FollowersDTO, FollowersModel>(resultsDTO);

            return models;
        }

        public FollowingModel GetFollowing(string id, string maxResults, string paginationToken)
        {
            UsersClient client = new UsersClient(_oAuthInfo);

            // these override the base behaviour for the user service when fetching followers
            string tweetFields = "attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,public_metrics,organic_metrics,promoted_metrics,possibly_sensitive,referenced_tweets,reply_settings,source,text,withheld";
            string userFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";

            string followersJson = client.GetFollowing(id, _expansionsFields, maxResults, paginationToken, tweetFields, userFields);

            FollowingDTO resultsDTO = JsonConvert.DeserializeObject<FollowingDTO>(followersJson);

            FollowingModel models = _iMapper.Map<FollowingDTO, FollowingModel>(resultsDTO);

            return models;
        }

    }
}
