using System;
using System.Collections.Generic;
using System.Text;

namespace Rx1
{
    public class WebClient
    {
        public static (string response, DateTime? maxModif) GetPageTuple(PageRequest request, int num)
        {
            PageResponse pageResp = GetPageResponse(request, num);
            var pageTup = (pageResp.Content, pageResp.MaxModif);
            return pageTup;
        }

        public static PageResponse GetPageResponse(PageRequest request, int num)
        {
            DateTime? nextModif = (request.ModifAfter < DateTime.Now)
                ? request.ModifAfter?.AddDays(1)
                : null;
            string response = "page " + num;
            PageResponse pageResp = new PageResponse(response, nextModif);
            return pageResp;
        }
    }
}
