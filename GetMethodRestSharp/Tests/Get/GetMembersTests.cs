using System.Net;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace GetMethodRestSharp.Tests.Get
{
    public class MembersTests: BaseTest
    {

        [Test]
        public void CheckGetBoards()
        {
            var request = RequestWithAuth("/1/members/{member}/boards")
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("member", "virginiamesa1");
            
            var response = _client!.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContent = JToken.Parse(response.Content);
            var JsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_boards.json"));
            Assert.True(responseContent.IsValid(JsonSchema));


        }

        [Test]

        public void CheckGetMember()
        {
            var request = RequestWithAuth("/1/members/{member}")
            .AddQueryParameter("fields", "id,fullName,idBoards")
                .AddUrlSegment("member", "virginiamesa1");

            var response = _client!.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContent = JToken.Parse(response.Content);
            var JsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_member.json"));
            Assert.True(responseContent.IsValid(JsonSchema));    
        }
    }
}