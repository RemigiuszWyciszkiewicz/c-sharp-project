using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ResponseWrapper<T>
    {

        public T responseBody { get; set; }
        public String responseMessage { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }
        

    }
}
