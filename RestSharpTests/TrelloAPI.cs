using System.Net;
using RestSharp;
using NUnit.Framework;

namespace RestSharpTests;

public class TrelloAPI
{

    private static IRestClient _client;

    [OneTimeSetUp]
    public static void InitializeRestClient() => 
        _client = new RestClient("https://api.trello.com"); 
        
    [Test]
    public void CheckTrelloApI()
    {
        var request = new RestRequest();

        Console.WriteLine($"{_client} {request.Method}");

        var response = _client.Get(request);

        Console.WriteLine(response.Content);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);


    }
}
