using System.Net;
using NUnit.Framework;
using RestSharp;

namespace Rest_Sharp_First_Project;

public class RestSharpRunner
{
    public static void Main(string[] args)
    {
        var request = new RestRequest();
        var client = new RestClient("https://api.trello.com");

        var response = client.Get(request);

        Console.Write(response.Content);

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

    }
}
