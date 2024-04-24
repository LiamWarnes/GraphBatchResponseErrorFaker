using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBatchResponseErrorFaker
{
    public class BatchResponseBody
    {
        public List<Response> Responses { get; set; } = new List<Response>();
    }
}
