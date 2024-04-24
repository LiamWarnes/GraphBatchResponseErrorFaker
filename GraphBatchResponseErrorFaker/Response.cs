using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraphBatchResponseErrorFaker
{
    public class Response
    {
        public string Id { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object? Body { get;set;}
    }
}
