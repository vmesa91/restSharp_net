
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace GetMethodRestSharp.Arguments.Holders;
public class AuthIdValidationArgumentsHolder {

    public IEnumerable<Parameter> AuthParams { get; set; }
    public string ErrorMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }

}