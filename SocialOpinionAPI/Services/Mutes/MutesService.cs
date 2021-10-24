using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Mutes;
using SocialOpinionAPI.Models.Mutes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Mutes
{
    public class MutesService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        private const int _defaultResults = 100;
        private const int _maxResults = 1000;
        private const string _defaultToken = "000000";
        private string _expansionsFields = "pinned_tweet_id";
        private string _TweetFields = "attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,organic_metrics,possibly_sensitive,promoted_metrics,public_metrics,referenced_tweets,reply_settings,source,text,withheld";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";

        public MutesService(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;

                var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MutedUsersResponseDTO, MutesModel>();
                cfg.CreateMap<DTO.Mutes.Datum, Models.Mutes.Datum>();

                cfg.CreateMap<DTO.Mutes.Entities, Models.Mutes.Entities>();
                cfg.CreateMap<DTO.Mutes.Description, Models.Mutes.Description>();
                cfg.CreateMap<DTO.Mutes.Mention, Models.Mutes.Mention>();
                cfg.CreateMap<DTO.Mutes.Hashtag, Models.Mutes.Hashtag>();
                cfg.CreateMap<DTO.Mutes.PublicMetrics, Models.Mutes.PublicMetrics>();
                cfg.CreateMap<DTO.Mutes.Meta, Models.Mutes.Meta>();
                cfg.CreateMap<DTO.Mutes.Url, Models.Mutes.Url>();
                cfg.CreateMap<DTO.Mutes.Meta, Models.Mutes.Meta>();
            });

            _iMapper = config.CreateMapper();
        }

        /// <summary>
        /// Allows an authenticated user ID to mute the target user.
        /// </summary>
        /// <param name="id">The user ID who you would like to initiate the mute on behalf of. It must match your own user ID or that of an authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="target_user_id">The user ID of the user that you would like the id to mute. </param>
        /// <returns>Indicates whether the user is muting the specified user as a result of this request.</returns>
        public bool Mute(string id, string target_user_id)
        {
            MutesClient client = new MutesClient(_oAuthInfo);

            MuteUserDTO muteUserDTO = new MuteUserDTO { target_user_id = target_user_id };
            string userToBlock = JsonConvert.SerializeObject(muteUserDTO);

            string response = client.Mute(id, userToBlock);

            MuteUserResponseDTO resultsDTO = JsonConvert.DeserializeObject<MuteUserResponseDTO>(response);

            return resultsDTO.data.muting;
        }

        /// <summary>
        /// Allows an authenticated user ID to unmute the target user. The request succeeds with no action when the user sends a request to a user they're not muting or have already unmuted.
        /// </summary>
        /// <param name="source_user_id">The user ID who you would like to initiate an unmute on behalf of. The user’s ID must correspond to the user ID of the authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="target_user_id">The user ID of the user that you would like the source_user_id to unmute.</param>
        /// <returns>Indicates whether the user is muting the specified user as a result of this request. The returned value is false for a successful unmute request.</returns>
        public bool UnMute(string source_user_id, string target_user_id)
        {
            MutesClient client = new MutesClient(_oAuthInfo);

            string response = client.UnMute(source_user_id, target_user_id);

            MuteUserResponseDTO resultsDTO = JsonConvert.DeserializeObject<MuteUserResponseDTO>(response);

            return resultsDTO.data.muting;
        }

        /// <summary>
        /// Returns a list of users who are muted by the specified user ID.
        /// </summary>
        /// <param name="userid">The user ID whose muted users you would like to retrieve. The user’s ID must correspond to the user ID of the authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="maxResults">The maximum number of results to be returned per page. This can be a number between 1 and 1000. By default, each page will return 100 results.</param>
        /// <returns>MutesModel</returns>
        public List<MutesModel> GetMutes(string userid, int maxResults)
        {
            MutesClient client = new MutesClient(_oAuthInfo);
            List<MutesModel> resultsList = new List<MutesModel>();

            string nextToken = _defaultToken;
            int totalFetched = 0;
            int numAttempts = 0;

            while (!string.IsNullOrEmpty(nextToken) || totalFetched <= maxResults)
            {
                if (numAttempts >= 0 && string.IsNullOrEmpty(nextToken))
                {
                    //we have no more data to fetch, despite not reaching the max number of items we wanted
                    // so return the list
                    return resultsList;
                }
                string response = string.Empty;

                if (nextToken != _defaultToken && !string.IsNullOrEmpty(nextToken))
                {
                    response = client.GetMutes(userid, _expansionsFields, _maxResults, nextToken, _TweetFields, _UserFields);
                }
                else
                {
                    response = client.GetMutes(userid, _expansionsFields, _maxResults, null, _TweetFields, _UserFields);
                }

                MutedUsersResponseDTO resultsDTO = JsonConvert.DeserializeObject<MutedUsersResponseDTO>(response);
                MutesModel model = _iMapper.Map<MutedUsersResponseDTO, MutesModel>(resultsDTO);
                resultsList.Add(model);

                totalFetched += resultsDTO.Meta.ResultCount;

                numAttempts = numAttempts + 1;

                if (numAttempts == _maxResults)
                {
                    // exit as we dont want blocked by Twitter                    
                    Console.WriteLine("Backing off from Twitter API. Reached Max Attempts when fetching Mutes for account: " + userid);
                    return resultsList;
                }

                if (totalFetched >= maxResults || resultsDTO.Meta.ResultCount <= maxResults)
                {
                    break;
                }

                nextToken = resultsDTO.Meta.NextToken;
            }
            return resultsList;
        }

    }

}
