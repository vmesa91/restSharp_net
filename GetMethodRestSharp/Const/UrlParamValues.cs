
using RestSharp;

namespace GetMethodRestSharp.Const
{
    public class UrlParamValues
    {
        public const string IdExistingBoard = "5e4e41e6bcb42d46c9cd0ed6";
        public const string KeyAuth = "7bb20fb34c87959469a1986625a86a46";
        public const string TokenAuth = "ATTA800bb425efd8795ec1c2edf34d3626df60b2c43b674a8108e4f86a7c527e413425692248";

        public static readonly IEnumerable<Parameter> AuthQueryParams = new[]
        { 
            Parameter.CreateParameter("key", KeyAuth, ParameterType.QueryString ), 
            Parameter.CreateParameter("token", TokenAuth, ParameterType.QueryString ) 
        };
        
    }
}