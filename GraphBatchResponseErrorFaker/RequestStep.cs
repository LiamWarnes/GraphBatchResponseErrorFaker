using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBatchResponseErrorFaker
{
    public class RequestStep
    {
        /// <summary>
        /// "body": {
        /// "destinationId": "deleteditems"
        /// },
        /// "headers": {
        /// "Content-Type": "application/json; charset=utf-8"
        /// },
        /// "id": "AAkALgAAAAAAHYQDEapmEc2byACqAC-EWg0AgW_2Nf_rW0_lIOM-NTFOMgACuCrsZAAA",
        /// "method": "POST",
        /// "url": "/users/cfbef5f3-a97c-4209-ab6b-0330a94fb27f/messages/AAkALgAAAAAAHYQDEapmEc2byACqAC-EWg0AgW_2Nf_rW0_lIOM-NTFOMgACuCrsZAAA/microsoft.graph.move"
        /// </summary>
        public string Id
        {
            get; set;
        }

        public object? Body
        {
            get; set;
        }

        public object? Headers
        {
            get; set;
        }

        public HttpMethod HttpMethod { get; set; }

        public string Url
        {
            get; set;
        }
    }
}
