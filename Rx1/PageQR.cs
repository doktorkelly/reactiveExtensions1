using System;
using System.Collections.Generic;
using System.Text;

namespace Rx1
{
    public class PageQR
    {
        public PageRequest Request { get; }
        public PageResponse Response { get; }

        public PageQR(PageRequest request, PageResponse response)
        {
            this.Request = request;
            this.Response = response;
        }

        public override string ToString()
        {
            string result = ""
                + "\r\nRequest: " + Request
                + "\r\nResponse: " + Response
                ;
            return result;
        }
    }
}
