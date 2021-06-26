using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Tweets
{
    public class TweetCountData
    {
        public DateTime end { get; set; }
        public DateTime start { get; set; }
        public int tweet_count { get; set; }
    }

    public class Meta
    {
        public int total_tweet_count { get; set; }
    }

    public class TweetCountsModel
    {
        public IList<TweetCountData> data { get; set; }
        public Meta meta { get; set; }
    }


}
