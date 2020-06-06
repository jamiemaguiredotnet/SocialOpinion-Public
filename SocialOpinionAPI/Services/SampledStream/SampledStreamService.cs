using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.SampledStream;
using SocialOpinionAPI.Models.SampledStream;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.SampledStream
{
    public class SampledStreamService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;

        public event EventHandler DataReceivedEvent;
        public class DataReceivedEventArgs : EventArgs
        {
            public Models.SampledStream.SampledStreamModel StreamDataResponse { get; set; }
        }
        protected void OnDataReceivedEvent(DataReceivedEventArgs dataReceivedEventArgs)
        {
            if (DataReceivedEvent == null)
                return;
            DataReceivedEvent(this, dataReceivedEventArgs);
        }

        public SampledStreamService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SampledStreamDTO, SampledStreamModel>();
                cfg.CreateMap<DTO.SampledStream.Annotation, Models.SampledStream.Annotation>();
                cfg.CreateMap<DTO.SampledStream.ContextAnnotation, Models.SampledStream.ContextAnnotation>();
                cfg.CreateMap<DTO.SampledStream.Data, Models.SampledStream.Data>();
                cfg.CreateMap<DTO.SampledStream.Domain, Models.SampledStream.Domain>();
                cfg.CreateMap<DTO.SampledStream.Entities, Models.SampledStream.Entities>();
                cfg.CreateMap<DTO.SampledStream.Entity, Models.SampledStream.Entity>();
                cfg.CreateMap<DTO.SampledStream.ReferencedTweet, Models.SampledStream.ReferencedTweet>();
                cfg.CreateMap<DTO.SampledStream.Stats, Models.SampledStream.Stats>();
                cfg.CreateMap<DTO.SampledStream.Url, Models.SampledStream.Url>();
            });

            _iMapper = config.CreateMapper();
        }

        public void StartStream(string address, int maxTweets, int maxConnectionAttempts)
        {
            SampledStreamClient streamClient = new SampledStreamClient(_oAuthInfo.ConsumerKey, _oAuthInfo.ConsumerSecret);

            streamClient.StreamDataReceivedEvent += StreamClient_StreamDataReceivedEvent;

            streamClient.StartStream(address, maxTweets, maxConnectionAttempts);
        }

        private void StreamClient_StreamDataReceivedEvent(object sender, EventArgs e)
        {
            // convert to dto and model
            SampledStreamClient.TweetReceivedEventArgs eventArgs = e as SampledStreamClient.TweetReceivedEventArgs;
            DTO.SampledStream.SampledStreamDTO resultsDTO = JsonConvert.DeserializeObject<DTO.SampledStream.SampledStreamDTO>(eventArgs.StreamDataResponse);
            SampledStreamModel model = _iMapper.Map<SampledStreamDTO, SampledStreamModel>(resultsDTO);

            // raise event with Model
            OnDataReceivedEvent(new DataReceivedEventArgs { StreamDataResponse = model });
        }
    }
}
