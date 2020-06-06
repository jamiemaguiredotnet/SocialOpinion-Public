# SocialOpinion-Public
APIs written in C# that connect to the TwitterAPI

Provides support for the following APIs:

* Filtered Stream Client and Service
[![Labs v1](https://img.shields.io/static/v1?label=Twitter%20API&message=Developer%20Labs%20v1&color=794BC4&style=flat&logo=Twitter)](https://developer.twitter.com/en/docs/labs/overview/versioning)  

* Metrics Service Client and Service
[![Labs v1](https://img.shields.io/static/v1?label=Twitter%20API&message=Developer%20Labs%20v1&color=794BC4&style=flat&logo=Twitter)](https://developer.twitter.com/en/docs/labs/overview/versioning)  

* Recent Search Client and Service
[![Labs v2](https://img.shields.io/static/v1?label=Twitter%20API&message=Developer%20Labs%20v2&color=794BC4&style=flat&logo=Twitter)](https://developer.twitter.com/en/docs/labs/overview/versioning)  

* Tweets / Users Client and Service
[![Labs v2](https://img.shields.io/static/v1?label=Twitter%20API&message=Developer%20Labs%20v2&color=794BC4&style=flat&logo=Twitter)](https://developer.twitter.com/en/docs/labs/overview/versioning)  

* Sampled Stream Client and Service
[![Labs v1](https://img.shields.io/static/v1?label=Twitter%20API&message=Developer%20Labs%20v1&color=794BC4&style=flat&logo=Twitter)](https://developer.twitter.com/en/docs/labs/overview/versioning)

* Hide Replies Client and Service
[![Labs v2](https://img.shields.io/static/v1?label=Twitter%20API&message=Developer%20Labs%20v2&color=794BC4&style=flat&logo=Twitter)](https://developer.twitter.com/en/docs/labs/overview/versioning)  

* Premium Search Client (in progress)
[![Premium](https://img.shields.io/static/v1?label=Twitter%20API&message=Premium&color=794BC4&style=flat&logo=Twitter)](https://developer.twitter.com/en/docs/tweets/search/api-reference/premium-search)


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
