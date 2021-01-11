using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Timeline;
using SocialOpinionAPI.Models.Timeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Timeline
{
    public class TimelineService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        private string _expansionsFields = "attachments.poll_ids,attachments.media_keys,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,referenced_tweets.id,referenced_tweets.id.author_id";
        private string _TweetFields = "attachments,author_id,created_at,entities,geo,id,in_reply_to_user_id,lang,possibly_sensitive,public_metrics,referenced_tweets,source,text,withheld,reply_settings";
        private string _MediaFields = "duration_ms,height,media_key,preview_image_url,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";

        public TimelineService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserMentionedTimelineDTO, UserMentionedTimelineModel>();
                cfg.CreateMap<DTO.Timeline.Datum, Models.Timeline.Datum>();
                cfg.CreateMap<DTO.Timeline.Entities, Models.Timeline.Entities>();
                cfg.CreateMap<DTO.Timeline.Description, Models.Timeline.Description>();
                cfg.CreateMap<DTO.Timeline.Annotation, Models.Timeline.Annotation>();
                cfg.CreateMap<DTO.Timeline.PublicMetrics, Models.Timeline.PublicMetrics>();
                cfg.CreateMap<DTO.Timeline.ReferencedTweet, Models.Timeline.ReferencedTweet>();
                cfg.CreateMap<DTO.Timeline.Geo, Models.Timeline.Geo>();
                cfg.CreateMap<DTO.Timeline.Url, Models.Timeline.Url>();
                cfg.CreateMap<DTO.Timeline.Mention, Models.Timeline.Mention>();
                cfg.CreateMap<DTO.Timeline.Meta, Models.Timeline.Meta>();
                cfg.CreateMap<DTO.Timeline.Includes, Models.Timeline.Includes>();
                cfg.CreateMap<DTO.Timeline.Properties, Models.Timeline.Properties>();
                cfg.CreateMap<DTO.Timeline.User, Models.Timeline.User>();
                cfg.CreateMap<DTO.Timeline.Place, Models.Timeline.Place>();
                cfg.CreateMap<DTO.Timeline.Tweet, Models.Timeline.Tweet>();
                cfg.CreateMap<DTO.Timeline.Medium, Models.Timeline.Medium>();
                cfg.CreateMap<DTO.Timeline.Hashtag, Models.Timeline.Hashtag>();
                cfg.CreateMap<DTO.Timeline.Cashtag, Models.Timeline.Cashtag>();
                cfg.CreateMap<DTO.Timeline.Attachments, Models.Timeline.Attachments>();
                cfg.CreateMap<DTO.Timeline.Image, Models.Timeline.Image>();

            });

            _iMapper = config.CreateMapper();
        }

        public void GetUserTweetsTimeline(string id, DateTime? endtime, bool excludeRetweets, bool excludeReplies, int maxResults,
                                      string pagination_token, DateTime? startTime, string since_id, string until_id)
        {
            TimelineClient client = new TimelineClient(_oAuthInfo);

            List<string> exclude = new List<string>();

            if (excludeRetweets)
            {
                exclude.Add("retweets");
            }
            if (excludeReplies)
            {
                exclude.Add("replies");
            }
        }

        public UserMentionedTimelineModel GetUserMentionedTimeline(string id, DateTime? endtime, int maxResults, string pagination_token, DateTime? startTime, string since_id, string until_id)
        {
            TimelineClient client = new TimelineClient(_oAuthInfo);


            string results = client.GetMentionedTimeline(id, endtime, _expansionsFields, maxResults, _MediaFields, pagination_token,
                                                         _PlaceFields, _PollFields, since_id, startTime, _TweetFields, until_id, _UserFields);

            UserMentionedTimelineDTO timelineDTO = JsonConvert.DeserializeObject<UserMentionedTimelineDTO>(results);

            UserMentionedTimelineModel model = _iMapper.Map<UserMentionedTimelineDTO, UserMentionedTimelineModel>(timelineDTO);

            return model;

        }
    }
}
