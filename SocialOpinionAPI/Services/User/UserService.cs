using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Users;
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
        private string _TweetFields = "attachments,author_id,created_at,entities,geo,id,in_reply_to_user_id,lang,possibly_sensitive,public_metrics,referenced_tweets,source,text,withheld";
        private string _MediaFields = "duration_ms,height,media_key,preview_image_url,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld,non_public_metrics";


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

    }
}
