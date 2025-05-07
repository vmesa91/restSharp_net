
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace APITrelloRestSharp.Tests.Arguments.Holders;
public class CardBodyValidationArgumentsHolder {

    public IDictionary<string, object> BodyParams { get; set; }
    public string ErrorMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }

}