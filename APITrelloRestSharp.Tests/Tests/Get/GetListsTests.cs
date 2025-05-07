using System.Net;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using APITrelloRestSharp.Tests.Tests;

namespace APITrelloRestSharp.Tests.Get
{
    public class GetListsTests: BaseTest
    {

        [Test]
        public void CheckGetAList() 
        {
            var request = RequestWithAuth("/1/lists/{id}")
                .AddUrlSegment("id", "5fe66a474b44da29b7a1988e");

            var response = _client!.Get(request);

            Assert.AreEqual("BACKLOG", JToken.Parse(response.Content).SelectToken("name").ToString());    
        }
        
        [Test]
        public void CheckGetACard() 
        {
            var request = RequestWithAuth("/1/lists/{id}/cards")
                .AddUrlSegment("id", "5fe66a474b44da29b7a1988e");

            var response = _client!.Get(request);

            Assert.AreEqual("Universidad Python : Manejo de Archivos", JToken.Parse(response.Content).SelectToken("[0].name")?.ToString());    
        }



    }
}