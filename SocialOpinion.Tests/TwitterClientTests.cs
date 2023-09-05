using System;
using System.Threading.Tasks;
using SocialOpinionAPI.Core;
using Xunit;

namespace SocialOpinion.Tests;

public class TwitterClientTests
{
    [Fact(Skip = "should be secure configured")]
    public async Task TestSendingTweet()
    {
        var accessToken = "";
        var accessSecret = "";
        var consumerKey = "";
        var consumerSecret = "";

        var client = new SocialOpinionAPI.Clients.TweetsClient(new OAuthInfo
        {
            AccessToken = accessToken,
            AccessSecret = accessSecret,
            ConsumerKey = consumerKey,
            ConsumerSecret = consumerSecret
        });

        try
        {
            client.PostTweet("Hello world 2!");

            Assert.True(true);
        }
        catch (Exception ex)
        {
            Assert.True(false);
        }
    }
}