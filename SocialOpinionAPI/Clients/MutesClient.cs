using SocialOpinionAPI.Core;

namespace SocialOpinionAPI.Clients
{
    public class MutesClient
    {
        private string _muting = "https://api.twitter.com/2/users/:id/muting";
        private string _unmute = "https://api.twitter.com/2/users/:source_user_id/muting/:target_user_id";

        private OAuthInfo _oAuthInfo;

        public MutesClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string Mute(string id, string jsonBody)
        {
            string url = _muting.Replace(":id", id);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "POST", url);
            return rb.ExecuteJsonParamsInBody(jsonBody);
        }

        public string UnMute(string id, string idToBlock)
        {
            string url = _unmute.Replace(":source_user_id", id);
            url = url.Replace(":target_user_id", idToBlock);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "DELETE", url);
            return rb.Execute();
        }

    }
}
