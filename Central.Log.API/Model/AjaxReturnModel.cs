

using System;
using System.Net;

namespace Central.Log.API.Help.Validation
{
    public class AjaxReturnModel
    {
        public bool Sucesso { get; set; }
        public HttpStatusCode Code { get; set; }
        public Object Data { get; set; }
        public string Message { get; set; }
    }
}
