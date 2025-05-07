
using System.Collections;
using System.Net;
using APITrelloRestSharp.Tests.Arguments.Holders;
using APITrelloRestSharp.Tests.Const;
using NUnit.Framework;
using RestSharp;

namespace APITrelloRestSharp.Tests.Arguments.Providers
{
    public class AuthValidationArgumentsProvider: IEnumerable
    {

     public IEnumerator GetEnumerator()
     {
        yield return new TestCaseData (
            new AuthIdValidationArgumentsHolder { AuthParams = ArraySegment<Parameter>.Empty}
        ).SetName("Empty");
        yield return new TestCaseData (
            new AuthIdValidationArgumentsHolder { AuthParams = new[]{ Parameter.CreateParameter("key", UrlParamValues.KeyAuth, ParameterType.UrlSegment ) }}
        ).SetName("Missing Token");
        yield return new TestCaseData (
            new AuthIdValidationArgumentsHolder { AuthParams = new[]{ Parameter.CreateParameter("token", UrlParamValues.TokenAuth, ParameterType.UrlSegment ) }}
        ).SetName("Missing Key");
     }   
    }
}