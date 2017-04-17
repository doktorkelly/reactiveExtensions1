using System;
using System.Collections.Generic;
using System.Text;

namespace Rx1
{
    public class PageRequest
    {
        public string BaseUrl { get;}
        public string Channel { get; }
        public DateTime From { get; }
        public DateTime Until { get; }
        public DateTime? ModifAfter { get; }

        public PageRequest(string url, string chan, DateTime from, DateTime until, DateTime? modif)
        {
            this.BaseUrl = url;
            this.Channel = chan;
            this.From = from;
            this.Until = until;
            this.ModifAfter = modif;
        }

        public PageRequest CloneWith(DateTime? modif)
        {
            PageRequest newPage = new PageRequest(
                this.BaseUrl,
                this.Channel,
                this.From,
                this.Until,
                modif
                );
            return newPage;
        }

        public override string ToString()
        {
            return ""
                + "ModifAfter: " + ModifAfter
                + " | Channel: " + Channel
                ;
        }
    }
}
