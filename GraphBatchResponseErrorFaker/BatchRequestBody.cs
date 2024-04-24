using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBatchResponseErrorFaker
{
    public class BatchRequestBody
    {
        public List<RequestStep> Requests { get; set; }
    }
}
