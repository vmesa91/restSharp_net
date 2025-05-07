
using System.Collections;
using System.Collections.Immutable;
using System.Net;
using APITrelloRestSharp.Tests.Arguments.Holders;
using NUnit.Framework;
using RestSharp;

namespace APITrelloRestSharp.Tests.Arguments.Providers
{
    public class BoardNameValidationArgumentsProvider :IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData(
           
                new Dictionary<string, object> {           
                    {
                        "name", 123456
                    }}
            ).SetName("Invalid BoardName");

            yield return new TestCaseData(

                ImmutableDictionary<string, object>.Empty

            ).SetName("Empty BoardName");
        }     
    }
}