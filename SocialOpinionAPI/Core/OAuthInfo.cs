using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Core
{
	public class OAuthInfo
	{
		public string ConsumerKey { get; set; }
		public string ConsumerSecret { get; set; }
		public string AccessToken { get; set; }
		public string AccessSecret { get; set; }
	}
}
