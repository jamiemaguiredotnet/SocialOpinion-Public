# SocialOpinion-Public
APIs written in C# that connect to the NEW TwitterAPI (https://developer.twitter.com/en/docs/api-reference-index#twitter-api-v2)

Provides support for the following endpoints:

#### Tweets
 * Filtered Stream [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Hide Replies [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Likes / Likes Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Retweets [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Sampled Stream [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Recent Search [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Timelines [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Tweet Counts [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Tweet Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
#### Users 
 * Blocks [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Follows Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Mutes [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * User Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
  
# Prerequisites
* Twitter Developer Account
* Twitter Project and Application in the new Twitter Developer Portal
* Obtain your application key and secret from the Twitter Developer Admin screen
* App.config file in SocialOpinionConsole Project with Application Keys and Secrets from the Twitter Developer Admin screen

# Prerequisites
* Twitter Developer Account
* Twitter Developer Labs Setup (for Labs interfaces)
* Obtain your application key and secret from the Twitter Developer Admin screen
* App.config file in SocialOpinionConsole Project with Application Keys and Secrets from the Twitter Developer Admin screen

# SocialOpinionAPI
Contains the C# APIs

# SocialOpinionConsole
Contains examples of how to use the APIs

The following configuration file must exist to ensure the test project works:

**App.config**
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="ConsumerKey" value="key here"/>
    <add key="ConsumerSecret" value="secret here"/>
    <add key="AccessToken" value="access token here"/>
    <add key="AccessTokenSecret" value="access token secret here"/>
  </appSettings>  
</configuration>
```
Alternatively, you can simply assign them in the **Program.cs** file here as string values and bypass loading them from the XML file
```
string _ConsumerKey = "key";
string _ConsumerSecret = "secret";
string _AccessToken = "access token";
string _AccessTokenSecret = "access token secret";
```
## More documentation soon!
