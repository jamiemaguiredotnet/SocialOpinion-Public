using AutoMapper;
using Newtonsoft.Json;
using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.Blocks;
using SocialOpinionAPI.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Services.Blocks
{
    public class BlocksService
    {
        private OAuthInfo _oAuthInfo;
        private IMapper _iMapper;
        private const int _defaultResults = 100;
        private const int _maxResults = 1000;
        private const string _defaultToken = "000000";
        private string _expansionsFields = "pinned_tweet_id";
        private string _TweetFields = "attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,public_metrics,possibly_sensitive,referenced_tweets,reply_settings,source,text,withheld";
        private string _UserFields = "created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld";


        public BlocksService(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BlocksDTO, BlocksModel>();
                cfg.CreateMap<DTO.Blocks.BlockData, Models.Blocks.BlockData>();

                cfg.CreateMap<DTO.Blocks.ContextAnnotation, Models.Blocks.ContextAnnotation>();
                cfg.CreateMap<DTO.Blocks.Attachments, Models.Blocks.Attachments>();
                cfg.CreateMap<DTO.Blocks.Domain, Models.Blocks.Domain>();
                cfg.CreateMap<DTO.Blocks.Entity, Models.Blocks.Entity>();
                cfg.CreateMap<DTO.Blocks.Entities, Models.Blocks.Entities>();
                cfg.CreateMap<DTO.Blocks.Description, Models.Blocks.Description>();
                cfg.CreateMap<DTO.Blocks.Image, Models.Blocks.Image>();
                cfg.CreateMap<DTO.Blocks.Annotation, Models.Blocks.Annotation>();
                cfg.CreateMap<DTO.Blocks.Mention, Models.Blocks.Mention>();
                cfg.CreateMap<DTO.Blocks.Hashtag, Models.Blocks.Hashtag>();
                cfg.CreateMap<DTO.Blocks.PublicMetrics, Models.Blocks.PublicMetrics>();
                cfg.CreateMap<DTO.Blocks.Tweet, Models.Blocks.Tweet>();
                cfg.CreateMap<DTO.Blocks.Includes, Models.Blocks.Includes>();
                cfg.CreateMap<DTO.Blocks.Meta, Models.Blocks.Meta>();
                cfg.CreateMap<DTO.Blocks.Url, Models.Blocks.Url>();

                cfg.CreateMap<DTO.Blocks.Meta, Models.Blocks.Meta>();
            });

            _iMapper = config.CreateMapper();
        }

        public List<BlocksModel> GetBlocks(string userid, int maxResults)
        {
            BlocksClient client = new BlocksClient(_oAuthInfo);
            List<BlocksModel> resultsList = new List<BlocksModel>();

            string nextToken = _defaultToken;
            int totalFetched = 0;
            int numAttempts = 0;
            
            while (!string.IsNullOrEmpty(nextToken) || totalFetched <= maxResults)
            {
                if(numAttempts >=0 && string.IsNullOrEmpty(nextToken))
                {
                    //we have no more data to fetch, despite not reaching the max number of items we wanted
                    // so return the list
                    return resultsList;
                }
                string response = string.Empty;

                if (nextToken != _defaultToken && !string.IsNullOrEmpty(nextToken))
                {
                    response = client.GetBlocks(userid, _expansionsFields, _maxResults, nextToken, _TweetFields, _UserFields);
                }
                else
                {
                    response = client.GetBlocks(userid, _expansionsFields, _maxResults, null, _TweetFields, _UserFields);
                }

                BlocksDTO resultsDTO = JsonConvert.DeserializeObject<BlocksDTO>(response);
                BlocksModel model = _iMapper.Map<BlocksDTO, BlocksModel>(resultsDTO);
                resultsList.Add(model);

                totalFetched += resultsDTO.Meta.ResultCount;

                numAttempts = numAttempts + 1;
                
                if (numAttempts == _maxResults)
                {
                    // exit as we dont want blocked by Twitter                    
                    Console.WriteLine("Backing off from Twitter API. Reached Max Attempts when fetching Blocks for account: " + userid);
                    return resultsList;
                }

                if (totalFetched >= maxResults)
                {
                    break;
                }

                nextToken = resultsDTO.Meta.NextToken;
            }
            return resultsList;
        }

        /// <summary>
        /// Causes the user (in the path) to block the target user. The user (in the path) must match the user context authorizing the request.
        /// </summary>
        /// <param name="id">The user ID who you would like to initiate the block on behalf of. It must match your own user ID or that of an authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="target_user_id">The user ID of the user that you would like the id to block.</param>
        public bool Block(string id, string target_user_id)
        {
            BlocksClient client = new BlocksClient(_oAuthInfo);

            BlockUserDTO blockUserDTO = new BlockUserDTO { target_user_id = target_user_id };
            string userToBlock = JsonConvert.SerializeObject(blockUserDTO);

            string response = client.Block(id, userToBlock);

            BlockUseResponseDTO resultsDTO = JsonConvert.DeserializeObject<BlockUseResponseDTO>(response);

            return resultsDTO.data.blocking;
        }

        /// <summary>
        /// Allows a user or authenticated user ID to unblock another user. The request succeeds with no action when the user sends a request to a user they're not blocking or have already unblocked.
        /// </summary>
        /// <param name="source_user_id">The user ID who you would like to initiate an unblock on behalf of. The user’s ID must correspond to the user ID of the authenticating user, meaning that you must pass the Access Tokens associated with the user ID when authenticating your request.</param>
        /// <param name="target_user_id">The user ID of the user that you would like the source_user_id to unblock.</param>
        public bool UnBlock(string source_user_id, string target_user_id)
        {
            BlocksClient client = new BlocksClient(_oAuthInfo);

            //UnBlockUserDTO unblockUserDTO = new UnBlockUserDTO {};
            //string userToBlock = JsonConvert.SerializeObject(unblockUserDTO);

            string response = client.UnBlock(source_user_id, target_user_id);

            BlockUseResponseDTO resultsDTO = JsonConvert.DeserializeObject<BlockUseResponseDTO>(response);

            return resultsDTO.data.blocking;
        }

    }
}
