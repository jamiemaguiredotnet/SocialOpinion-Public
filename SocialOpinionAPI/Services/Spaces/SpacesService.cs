using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Spaces;
using SocialOpinionAPI.Models.Spaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Spaces
{
    public class SpacesService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;

        public enum State
        {
            live,
            scheduled
        }

        private string _expansionsFields = "invited_user_ids,speaker_ids,creator_id,host_ids";
        private string _spaceFields = "host_ids,created_at,creator_id,id,lang,invited_user_ids,participant_count,speaker_ids,started_at,state,title,updated_at,scheduled_start,is_ticketed";
        private string _userFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";

        public SpacesService(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.Spaces.Data, Models.Spaces.Data>();
                cfg.CreateMap<DTO.Spaces.SpaceDTO, Models.Spaces.SpaceModel>();
                cfg.CreateMap<DTO.Spaces.SpacesDTO, Models.Spaces.SpacesModel>();
                cfg.CreateMap<DTO.Spaces.Mention, Models.Spaces.Mention>();
                cfg.CreateMap<DTO.Spaces.Entities, Models.Spaces.Entities>();
                cfg.CreateMap<DTO.Spaces.PublicMetrics, Models.Spaces.PublicMetrics>();
                cfg.CreateMap<DTO.Spaces.User, Models.Spaces.User>();
                cfg.CreateMap<DTO.Spaces.Url, Models.Spaces.Url>();
                cfg.CreateMap<DTO.Spaces.Urls, Models.Spaces.Urls>();
                cfg.CreateMap<DTO.Spaces.Description, Models.Spaces.Description>();
                cfg.CreateMap<DTO.Spaces.Includes, Models.Spaces.Includes>();
                cfg.CreateMap<DTO.Spaces.Meta, Models.Spaces.Meta>();
            });

            _iMapper = config.CreateMapper();
        }

        public SpacesModel Search(string query, State state, int maxResults)
        {
            SpacesClient spacesClient = new SpacesClient(_oAuthInfo);

            string spacesJson = spacesClient.Search(query, state.ToString(), _expansionsFields, maxResults.ToString(), _spaceFields, _userFields);

            SpacesDTO resultsDTO = JsonConvert.DeserializeObject<SpacesDTO>(spacesJson);

            SpacesModel model = _iMapper.Map<SpacesDTO, SpacesModel>(resultsDTO);

            return model;
        }

        /// <summary>
        /// Returns a variety of information about a single Space specified by the requested ID.
        /// </summary>
        /// <param name="id">Unique identifier of the Space to request.</param>
        /// <returns>Spaces Model with data related to the requested id</returns>
        public SpaceModel Lookup(string id)
        {
            SpacesClient spacesClient = new SpacesClient(_oAuthInfo);

            string spacesJson = spacesClient.LookupSpaceById(id, _expansionsFields, _spaceFields, _userFields);

            SpaceDTO resultsDTO = JsonConvert.DeserializeObject<SpaceDTO>(spacesJson);

            SpaceModel model = _iMapper.Map<SpaceDTO, SpaceModel>(resultsDTO);

            return model;
        }

        /// <summary>
        /// Returns details about multiple Spaces. Up to 100 comma-separated Spaces IDs can be looked up using this endpoint.
        /// </summary>
        /// <param name="ids">A comma separated list of Spaces (up to 100).</param>
        /// <returns>List of Space Models</returns>
        public SpacesModel Lookup(List<string> ids)
        {
            SpacesClient spacesClient = new SpacesClient(_oAuthInfo);

            string spacesJson = spacesClient.LookupSpacesByIds(string.Join(",",ids), _expansionsFields, _spaceFields, _userFields);

            SpacesDTO resultsDTO = JsonConvert.DeserializeObject<SpacesDTO>(spacesJson);

            SpacesModel model = _iMapper.Map<SpacesDTO, SpacesModel>(resultsDTO);

            return model;
        }

        /// <summary>
        /// Returns live or scheduled Spaces created by the specified user IDs. Up to 100 comma-separated IDs can be looked up using this endpoint.
        /// </summary>
        /// <param name="ids">creator ids</param>
        /// <returns>list of Spaces for the given creator ids</returns>
        public SpacesModel LookupByCreatorId(List<string> ids)
        {
            SpacesClient spacesClient = new SpacesClient(_oAuthInfo);

            string spacesJson = spacesClient.LookupSpacesByCreatorIds(string.Join(",", ids), _expansionsFields, _spaceFields, _userFields);

            SpacesDTO resultsDTO = JsonConvert.DeserializeObject<SpacesDTO>(spacesJson);

            SpacesModel model = _iMapper.Map<SpacesDTO, SpacesModel>(resultsDTO);

            return model;
        }


    }
}
