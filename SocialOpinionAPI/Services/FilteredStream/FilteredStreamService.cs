using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.FilteredStream;
using SocialOpinionAPI.DTO.FilteredStream.Rules;
using SocialOpinionAPI.Models.FilteredStream;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.FilteredStream
{
    public class FilteredStreamService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;

        public event EventHandler DataReceivedEvent;
        public class DataReceivedEventArgs : EventArgs
        {
            public Models.FilteredStream.FilteredStreamModel FilteredStreamDataResponse { get; set; }
        }
        protected void OnDataReceivedEvent(DataReceivedEventArgs dataReceivedEventArgs)
        {
            if (DataReceivedEvent == null)
                return;
            DataReceivedEvent(this, dataReceivedEventArgs);
        }

        public FilteredStreamService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FilteredStreamDTO, FilteredStreamModel>();
                cfg.CreateMap<DTO.FilteredStream.Annotation, Models.FilteredStream.Annotation>();
                cfg.CreateMap<DTO.FilteredStream.ContextAnnotation, Models.FilteredStream.ContextAnnotation>();
                cfg.CreateMap<DTO.FilteredStream.Data, Models.FilteredStream.Data>();
                cfg.CreateMap<DTO.FilteredStream.Domain, Models.FilteredStream.Domain>();
                cfg.CreateMap<DTO.FilteredStream.Entities, Models.FilteredStream.Entities>();
                cfg.CreateMap<DTO.FilteredStream.Entity, Models.FilteredStream.Entity>();
                cfg.CreateMap<DTO.FilteredStream.MatchingRule, Models.FilteredStream.MatchingRule>();
                cfg.CreateMap<DTO.FilteredStream.ReferencedTweet, Models.FilteredStream.ReferencedTweet>();
                cfg.CreateMap<DTO.FilteredStream.Stats, Models.FilteredStream.Stats>();
                cfg.CreateMap<DTO.FilteredStream.Url, Models.FilteredStream.Url>();
            });

            _iMapper = config.CreateMapper();
        }

        public List<FilteredStreamRule> CreateRule(Models.FilteredStream.MatchingRule rule)
        {
            FilteredStreamClient streamClient = new FilteredStreamClient(_oAuthInfo.ConsumerKey, _oAuthInfo.ConsumerSecret);

            RulesToAddDTO addRulesDTO = new RulesToAddDTO();

            addRulesDTO.add.Add(new Add { value = rule.Value, tag = rule.tag });
            string response = streamClient.CreateRule(addRulesDTO);

            CreateRulesResponseDTO responseDTO = JsonConvert.DeserializeObject<CreateRulesResponseDTO>(response);

            List<FilteredStreamRule> streamRules = new List<FilteredStreamRule>();
            
            foreach(RuleDTO dto in responseDTO.data)
            {
                streamRules.Add(new FilteredStreamRule { id = dto.id, tag = dto.tag, value = dto.value });
            }

            return streamRules;
        }

        public Models.FilteredStream.MatchingRule GetAllRules(Models.FilteredStream.MatchingRule rule)
        {
            throw new NotImplementedException();
        }

        public Models.FilteredStream.MatchingRule DeleteRule(Models.FilteredStream.MatchingRule rule)
        {
            throw new NotImplementedException();
        }

        public void StartStream(string address, int maxTweets, int maxConnectionAttempts)
        {
            FilteredStreamClient streamClient = new FilteredStreamClient(_oAuthInfo.ConsumerKey, _oAuthInfo.ConsumerSecret);

            streamClient.FilteredStreamDataReceivedEvent += StreamClient_FilteredStreamDataReceivedEvent;

            streamClient.StartStream(address, maxTweets, maxConnectionAttempts);
        }

        private void StreamClient_FilteredStreamDataReceivedEvent(object sender, EventArgs e)
        {
            // convert to dto and model
            FilteredStreamClient.TweetReceivedEventArgs eventArgs = e as FilteredStreamClient.TweetReceivedEventArgs;
            DTO.FilteredStream.FilteredStreamDTO resultsDTO = JsonConvert.DeserializeObject<DTO.FilteredStream.FilteredStreamDTO>(eventArgs.filteredStreamDataResponse);
            FilteredStreamModel model = _iMapper.Map<FilteredStreamDTO, FilteredStreamModel>(resultsDTO);

            // raise event with Model
            OnDataReceivedEvent(new DataReceivedEventArgs { FilteredStreamDataResponse = model });
        }
    }
}
