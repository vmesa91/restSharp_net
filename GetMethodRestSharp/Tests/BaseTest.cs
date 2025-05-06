using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetMethodRestSharp.Const;
using NUnit.Framework;
using RestSharp;

namespace GetMethodRestSharp.Tests
{
    public class BaseTest
    {

        protected static IRestClient? _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() =>
            _client = new RestClient("https://api.trello.com");


        [OneTimeTearDown]
        public static void CleanUp() {
            _client?.Dispose();
        } 
        protected RestRequest RequestWithAuth(string url) {
            return new RestRequest(url)
                .AddOrUpdateParameters(UrlParamValues.AuthQueryParams);
               
        }  

        protected RestRequest RequestWithAuth(string url, Method method) {
            return new RestRequest(url, method)
                .AddOrUpdateParameters(UrlParamValues.AuthQueryParams);
        } 

        protected RestRequest RequestWithoutAuth(string url) {
            return new RestRequest(url);
        } 

    }
}