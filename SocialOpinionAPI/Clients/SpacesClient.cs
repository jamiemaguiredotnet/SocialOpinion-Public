using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class SpacesClient
    {
        private string _search = "https://api.twitter.com/2/spaces/search";
        private string _lookupById = "https://api.twitter.com/2/spaces/:id";
        private string _lookupByIds = "https://api.twitter.com/2/spaces";
        private string _lookupByCreatorIds = "https://api.twitter.com/2/spaces/by/creator_ids";

        private OAuthInfo _oAuthInfo;

        public SpacesClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string Search(string query, string state, string expansions,string max_results, string space_fields, string user_fields)
        {
            BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", _search);

            rb.AddParameter("query", query);
            rb.AddParameter("state", state);
            rb.AddParameter("expansions", expansions);
            rb.AddParameter("max_results", max_results);
            rb.AddParameter("space.fields", space_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string LookupSpaceById(string id,string expansions, string space_fields, string user_fields)
        {
            string url = _lookupById.Replace(":id", id);
            url = url.Replace(":id", id);

            BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", url);

            rb.AddParameter("expansions", expansions);
            rb.AddParameter("space.fields", space_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string LookupSpacesByIds(string ids, string expansions, string space_fields, string user_fields)
        {
            BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", _lookupByIds);

            rb.AddParameter("ids", ids);
            rb.AddParameter("expansions", expansions);
            rb.AddParameter("space.fields", space_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string LookupSpacesByCreatorIds(string user_ids, string expansions, string space_fields, string user_fields)
        {
            BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", _lookupByCreatorIds);

            rb.AddParameter("user_ids", user_ids);
            rb.AddParameter("expansions", expansions);
            rb.AddParameter("space.fields", space_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }
    }
}
