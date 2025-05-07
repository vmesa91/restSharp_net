
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace APITrelloRestSharp.Tests.Arguments.Holders;
public class BoardIdValidationArgumentsHolder {

    public IEnumerable<Parameter> PathParams { get; set; }
    public string ErrorMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }

}