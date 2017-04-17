using System;
using System.Collections.Generic;
using System.Text;

namespace Rx1
{
    public class PageTuple
    {
        public string Response { get; }
        public DateTime? LastModif { get; }

        public PageTuple(string response, DateTime? modif)
        {
            this.Response = response;
            this.LastModif = modif;
        }

        public override string ToString()
        {
            string result = ""
                + "lastModif: " + LastModif
                + " | response:  " + Response;
            return result;
        }
    }
}
