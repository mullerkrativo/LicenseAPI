using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;

namespace Clowdr.Core.Exceptions
{
    public class HttpException : HttpResponseException
    {
        public HttpException(HttpStatusCode httpStatusCode)
        :base(httpStatusCode)
        {}

        public HttpException(HttpStatusCode httpStatusCode, string message)
        :base(new HttpResponseMessage { StatusCode = httpStatusCode, ReasonPhrase = message})
        {}
    }
}
