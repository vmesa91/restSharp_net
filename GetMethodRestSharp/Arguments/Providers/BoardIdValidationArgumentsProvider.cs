
using System.Collections;
using System.Net;
using GetMethodRestSharp.Arguments.Holders;
using NUnit.Framework;
using RestSharp;

namespace GetMethodRestSharp.Arguments.Providers
{
    public class BoardIdValidationArgumentsProvider :IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData(
           
                new BoardIdValidationArgumentsHolder {
                    ErrorMessage = "invalid id",
                    StatusCode = HttpStatusCode.BadRequest,
                    PathParams = new[] { Parameter.CreateParameter("id", "invalid", ParameterType.UrlSegment) }
                }
            
            ).SetName("Invalid ID - BadRequest");
 
            yield return new TestCaseData(
                new BoardIdValidationArgumentsHolder {
                    ErrorMessage = "The requested resource was not found.",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] { Parameter.CreateParameter("id", "5fe66b295f6e001878d47976", ParameterType.UrlSegment) }
                }
            ).SetName("Missing ID - NotFound");
        }
    }
}

