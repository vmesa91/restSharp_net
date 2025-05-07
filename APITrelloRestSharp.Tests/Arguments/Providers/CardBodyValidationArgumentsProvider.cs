
using System.Collections;
using System.Data.Common;
using System.Net;
using APITrelloRestSharp.Tests.Arguments.Holders;
using APITrelloRestSharp.Tests.Const;
using NUnit.Framework;
using RestSharp;

namespace APITrelloRestSharp.Tests.Arguments.Providers
{
    public class CardBodyValidationArgumentsProvider :IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData(
           
                new CardBodyValidationArgumentsHolder {
                    ErrorMessage = "invalid value for name",
                    StatusCode = HttpStatusCode.BadRequest,
                    BodyParams = new Dictionary<string, object> 
                    {
                          { "name" , 123 },
                          { "description" , "New Card on Board by API - Testing RestSharp" },
                          { "idList", UrlParamValues.IdListBacklog }      
                    }
                }
            
            ).SetName("Invalid Name - BadRequest");

            yield return new TestCaseData(
           
                new CardBodyValidationArgumentsHolder {
                    ErrorMessage = "invalid value for idList",
                    StatusCode = HttpStatusCode.BadRequest,
                    BodyParams = new Dictionary<string, object> 
                    {
                          { "name", "New Card on Board by API" }
               
                    }
                }
            
            ).SetName("Invalid ID - BadRequest");
 
        }
    }
}

