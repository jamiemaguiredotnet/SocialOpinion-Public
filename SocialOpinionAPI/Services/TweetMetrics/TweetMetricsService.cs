using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.TweetMetrics;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Models.TweetMetrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.TweetMetrics
{
    public class TweetMetricsService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;

        public TweetMetricsService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TweetMetricDTO, TweetMetricModel>();

            });

            _iMapper = config.CreateMapper();
        }

        public List<TweetMetricModel> GetTweetMetrics(List<string> tweetIds)
        {
            MetricsClient metricsClient = new MetricsClient(_oAuthInfo);
            List<TweetMetricModel> metricModels = new List<TweetMetricModel>();

            string response = metricsClient.GetTweetMetrics(tweetIds);

            TweetMetricDTO tweetMetrics = JsonConvert.DeserializeObject<TweetMetricDTO>(response);
            
            foreach (Data metricData in tweetMetrics.data)
            {
                metricModels.Add(new TweetMetricModel
                    {
                        tweet_id = metricData.tweet_id,
                        impression_count = metricData.tweet.impression_count,
                        like_count = metricData.tweet.like_count,
                        quote_count = metricData.tweet.quote_count,
                        reply_count = metricData.tweet.reply_count,
                        retweet_count = metricData.tweet.retweet_count
                    });
            }
            return metricModels;
        }

    }
}
