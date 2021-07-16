using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Mutes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Mutes
{
    public class MutesService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;

        public MutesService(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
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
    }

}
