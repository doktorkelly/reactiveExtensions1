using System;
using System.Collections.Generic;
using System.Text;

namespace Rx1
{
    public class PageResponse
    {
        public string Content { get; }
        public DateTime? MaxModif { get; }

        public PageResponse(string content, DateTime? modif)
        {
            this.Content = content;
            this.MaxModif = modif;
        }

        public override string ToString()
        {
            return ""
                + "MaxModif: " + MaxModif
                + " | Content: " + Content
                ;
        }
    }
}
