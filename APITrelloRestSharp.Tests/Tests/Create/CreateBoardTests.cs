using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APITrelloRestSharp.Tests.Arguments.Providers;
using APITrelloRestSharp.Tests.Const;
using APITrelloRestSharp.Tests.Tests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace APITrelloRestSharp.Tests.Tests.Create
{
    public class CreateBoardTests : BaseTest
    {
        private string _createBoardId; 

        [Test]
        public void CheckCreateBoard()
        {
            var boardName = "New Board by API" + DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(BoardsEndpoints.PostCreateBoardUrl)
                .AddJsonBody( new Dictionary<string, string> {{ "name" , boardName }} );

            var response = _client?.Post(request);

            var responseContent = JToken.Parse(response.Content);

            _createBoardId = responseContent.SelectToken("id").ToString();

            Assert.AreEqual( HttpStatusCode.OK, response.StatusCode );
            Assert.AreEqual( boardName, responseContent.SelectToken("name").ToString() );

            // Check the Board was created
            request = RequestWithAuth(BoardsEndpoints.GetBoardsUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("member", UrlParamValues.UserName);
            
            response = _client!.Get(request);
            responseContent = JToken.Parse( response.Content );
            
            Assert.True(responseContent.Children().Select(token => token.SelectToken("name")).Contains(boardName));

        }
       
        [Test]
        public void DeleteCreateBoard()
        {
               var request = RequestWithAuth(BoardsEndpoints.DeleteBoardUrl, Method.Delete)
                .AddUrlSegment("id", _createBoardId); 

                var response = _client?.Execute(request);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [Test]
        [TestCaseSource(typeof(BoardNameValidationArgumentsProvider))]
        public void CheckCreateBoardWithInvalidName(IDictionary<string, object> bodyParams)
        {
            var request = RequestWithAuth(BoardsEndpoints.PostCreateBoardUrl, Method.Post)
                .AddJsonBody(bodyParams);

            var response = _client.Execute(request);
            var json = JObject.Parse(response.Content);
            var message = json["message"]?.ToString();
            
            Assert.That(HttpStatusCode.BadRequest, Is.EqualTo(response.StatusCode));
            Assert.That(message, Is.EqualTo("invalid value for name"));


        }


    }
}