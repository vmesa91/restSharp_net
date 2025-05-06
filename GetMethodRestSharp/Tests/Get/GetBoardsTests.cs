
using System.Net;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using GetMethodRestSharp.Arguments.Providers;
using GetMethodRestSharp.Arguments.Holders;
using GetMethodRestSharp.Const;


namespace GetMethodRestSharp.Tests.Get
{
    public class GetBoardsTests: BaseTest
    {

        [Test]
        public void CheckGetBoard()
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("id", UrlParamValues.IdExistingBoard);
            
            var response = _client!.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("TFG Virginia (ant)", JToken.Parse(response.Content).SelectToken("name").ToString());
            var responseContent = JToken.Parse(response.Content);
            var JsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_board.json"));
            Assert.True(responseContent.IsValid(JsonSchema));
        }

        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentsProvider))]
        public void CheckGetBoardWithInvalidId( BoardIdValidationArgumentsHolder validationArguments )
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl, Method.Get)
                .AddOrUpdateParameters(validationArguments.PathParams);

            var response = _client!.Execute(request); 

            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }

        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentsProvider))]
        public void CheckGetBoardWithNotFoundId( BoardIdValidationArgumentsHolder validationArguments )
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl, Method.Get)
                 .AddOrUpdateParameters(validationArguments.PathParams);

            var response = _client!.Execute(request); 

            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }

        [Test]
        public void CheckGetListOnBoard() 
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl, Method.Get)
                .AddUrlSegment("id", UrlParamValues.IdExistingBoard);

            var response = _client!.Execute(request);

            Assert.AreEqual("TFG Virginia (ant)", JToken.Parse(response.Content).SelectToken("name").ToString());    
        }

        [Test]
        [TestCaseSource(typeof(AuthValidationArgumentsProvider))]
        public void CheckGetBoardWithInvalidAuth( AuthIdValidationArgumentsHolder authValidationArguments )
        {
            var request = RequestWithoutAuth(BoardsEndpoints.GetBoardUrl)
                .AddOrUpdateParameters(authValidationArguments.AuthParams)
                .AddUrlSegment("id", UrlParamValues.IdExistingBoard);
            
            var response = _client.Execute(request);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.AreEqual("unauthorized permission requested", response.Content);
        }


    }
}