using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Tweets;
using SocialOpinionAPI.Models.Tweets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Tweet
{
    public class TweetService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        private string _expansionsFields = "attachments.poll_ids,attachments.media_keys,author_id,geo.place_id,in_reply_to_user_id,referenced_tweets.id";
        // promoted_metrics throws error when tweet isnt promoted
        private string _TweetFields = "attachments,author_id,context_annotations,created_at,entities,geo,id,in_reply_to_user_id,lang,possibly_sensitive,organic_metrics,public_metrics,referenced_tweets,source,text,withheld";
        private string _MediaFields = "duration_ms,height,media_key,non_public_metrics,preview_image_url,public_metrics,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";

        public TweetService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TweetDTO, TweetModel>();
                cfg.CreateMap<TweetsDTO, TweetsModel>();
                cfg.CreateMap<DTO.Tweets.Data, Models.Tweets.Data>();
                cfg.CreateMap<DTO.Tweets.Entities, Models.Tweets.Entities>();
                cfg.CreateMap<DTO.Tweets.PublicMetrics, Models.Tweets.PublicMetrics>();
                cfg.CreateMap<DTO.Tweets.OrganicMetrics, Models.Tweets.OrganicMetrics>();
                cfg.CreateMap<DTO.Tweets.Url, Models.Tweets.Url>();
                cfg.CreateMap<DTO.Tweets.Urls, Models.Tweets.Urls>();
                cfg.CreateMap<DTO.Tweets.Includes, Models.Tweets.Includes>();
                cfg.CreateMap<DTO.Tweets.User, Models.Tweets.User>();
                cfg.CreateMap<DTO.Users.Attachments, Models.Users.Attachments>();
            });

            _iMapper = config.CreateMapper();
        }

        public TweetModel GetTweet(string id)
        {
            TweetsClient client = new TweetsClient(_oAuthInfo);

            string tweetJson = client.GetTweet(id, _expansionsFields, _TweetFields, _MediaFields, _PollFields, _PlaceFields, _UserFields);

            TweetDTO resultsDTO = JsonConvert.DeserializeObject<TweetDTO>(tweetJson);

            TweetModel model = _iMapper.Map<TweetDTO, TweetModel>(resultsDTO);

            return model;
        }

        public TweetsModel GetTweets(List<string> ids)
        {
            TweetsClient client = new TweetsClient(_oAuthInfo);

            string tweetJson = client.GetTweets(ids, _expansionsFields, _TweetFields, _MediaFields, _PollFields, _PlaceFields, _UserFields);

            TweetsDTO resultsDTO = JsonConvert.DeserializeObject<TweetsDTO>(tweetJson);

            TweetsModel model = _iMapper.Map<TweetsDTO, TweetsModel>(resultsDTO);

            return model;
        }

    }
}
