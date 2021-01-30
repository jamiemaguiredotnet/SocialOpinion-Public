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
        // promoted_metrics for _TweetFields return null. omit for time being
        private string _TweetFields = "attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,public_metrics,organic_metrics,possibly_sensitive,referenced_tweets,reply_settings,source,text,withheld";
        private string _MediaFields = "duration_ms,height,media_key,preview_image_url,type,url,width";
        private string _PlaceFields = "contained_within,country,country_code,full_name,geo,id,name,place_type";
        private string _PollFields = "duration_minutes,end_datetime,id,options,voting_status";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";

        private bool _includePrivateMetrics = true;

        public TimelineService(OAuthInfo oAuth, bool includePrivateMetrics = true)
        {
            _oAuthInfo = oAuth;
            _includePrivateMetrics = includePrivateMetrics;

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

                cfg.CreateMap<UserTweetTimelineDTO, UserTweetTimelineModel>();
                cfg.CreateMap<DTO.Timeline.TweetDatum, Models.Timeline.TweetDatum>();
                cfg.CreateMap<DTO.Timeline.TweetMeta, Models.Timeline.TweetMeta>();
                cfg.CreateMap<DTO.Timeline.OrganicMetrics, Models.Timeline.OrganicMetrics>();
                cfg.CreateMap<DTO.Timeline.NonPublicMetrics, Models.Timeline.TweetNonPublicMetrics>();
                cfg.CreateMap<DTO.Timeline.ContextAnnotation, Models.Timeline.ContextAnnotation>();
                cfg.CreateMap<DTO.Timeline.TweetPublicMetrics, Models.Timeline.TweetPublicMetrics>();
                cfg.CreateMap<DTO.Timeline.Domain, Models.Timeline.Domain>();
                cfg.CreateMap<DTO.Timeline.Entity, Models.Timeline.Entity>();
                cfg.CreateMap<DTO.Timeline.Entities, Models.Timeline.Entities>();
                cfg.CreateMap<DTO.Timeline.Error, Models.Timeline.Error>();

            });

            _iMapper = config.CreateMapper();
        }

        public UserTweetTimelineModel GetUserTweetsTimeline(string id, DateTime? endtime, 
                                      bool excludeRetweets, bool excludeReplies, int maxResults,
                                      string pagination_token, DateTime? startTime, string since_id, string until_id)
        {
            TimelineClient client = new TimelineClient(_oAuthInfo);

            if (_includePrivateMetrics == false)
            {
                _TweetFields = _TweetFields.Replace("non_public_metrics,", "");
                _TweetFields = _TweetFields.Replace("organic_metrics,", "");
            }

            List<string> exclude = new List<string>();

            if (excludeRetweets)
            {
                exclude.Add("retweets");
            }
            if (excludeReplies)
            {
                exclude.Add("replies");
            }

            string results = client.GetTweetsTimeline(id, endtime, string.Join(",", exclude), _expansionsFields,
                                     maxResults, _MediaFields, pagination_token, _PlaceFields,
                                     _PollFields, since_id, startTime, _TweetFields, until_id, _UserFields);

            UserTweetTimelineDTO tweetTimelineDTO = JsonConvert.DeserializeObject<UserTweetTimelineDTO>(results);

            UserTweetTimelineModel model = _iMapper.Map<UserTweetTimelineDTO, UserTweetTimelineModel>(tweetTimelineDTO);

            return model;
        }

        public UserMentionedTimelineModel GetUserMentionedTimeline(string id, DateTime? endtime, int maxResults, string pagination_token, DateTime? startTime, string since_id, string until_id)
        {
            TimelineClient client = new TimelineClient(_oAuthInfo);

            if (_includePrivateMetrics == false)
            {
                _TweetFields = _TweetFields.Replace("non_public_metrics,", "");
                _TweetFields = _TweetFields.Replace("organic_metrics,", "");
            }

            string results = client.GetMentionedTimeline(id, endtime, _expansionsFields, maxResults, _MediaFields, pagination_token,
                                                         _PlaceFields, _PollFields, since_id, startTime, _TweetFields, until_id, _UserFields);

            UserMentionedTimelineDTO timelineDTO = JsonConvert.DeserializeObject<UserMentionedTimelineDTO>(results);

            UserMentionedTimelineModel model = _iMapper.Map<UserMentionedTimelineDTO, UserMentionedTimelineModel>(timelineDTO);

            return model;

        }
    }
}
