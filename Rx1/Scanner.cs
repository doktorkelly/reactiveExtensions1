using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Rx1
{
    public class Scanner
    {
        public static IObservable<PageQR> GetPagesQR(PageRequest request, int maxPages = 100)
        {
            PageQR startPage = new PageQR(request, null);
            IObservable<PageQR> pages = Observable.Range(1, maxPages)
                .Scan(startPage, (acc, num) => GetPageQR(acc, num))
                .TakeWhile(page => page.Response.MaxModif != null);                
            return pages;
        }

        public static IEnumerable<PageQR> GetPagesList(PageRequest request, int maxPages = 100)
        {
            IEnumerable<PageQR> pages = GetPagesQR(request, maxPages)
                .ToEnumerable();
            return pages;
        }

        private static PageQR GetPageQR(PageQR prevPage, int num)
        {
            PageRequest prevRequest = prevPage.Request;
            DateTime? lastModif = prevPage.Response?.MaxModif ?? prevRequest.ModifAfter;
            PageRequest request = prevRequest.CloneWith(lastModif);
            PageResponse response = WebClient.GetPageResponse(request, num);
            PageQR page = new PageQR(request, response);
            return page;
        }


        #region obsolete methods

        [Obsolete("todo")]
        private static (PageRequest req, PageResponse resp, DateTime? modif) StartPage(DateTime? modif)
        {
            //call example:
            //var startValTup = StartPage(DateTime.Now.AddDays(-7));
            //DateTime? mod = startValTup.modif;

            (PageRequest req, PageResponse resp, DateTime? modif) pageTup = (null, null, modif);
            return pageTup;
        }

        [Obsolete("use GetPagesQR")]
        public static IObservable<PageTuple> GetPages(DateTime startModif)
        {
            DateTime from = DateTime.Today.AddDays(-2);
            DateTime until = DateTime.Today;
            PageRequest req = new PageRequest("url", "chan1", from, until, null);
            PageTuple startTup = new PageTuple(null, startModif);
            IObservable<PageTuple> pages = Observable.Range(1, 100)
                .Scan(startTup, (acc, num) => GetPageTup(req, acc.LastModif, num))
                .TakeWhile(page => page.LastModif != null);
            return pages;
        }

        [Obsolete("use GetPageQR")]
        private static PageTuple GetPageTup(PageRequest req, DateTime? lastModif, int num)
        {
            string response = "page " + num;
            DateTime? nextModif = (lastModif < DateTime.Now)
                ? lastModif?.AddDays(1)
                : null;
            PageTuple pageTup = new PageTuple(response, nextModif);
            return pageTup;
        }

        public static void DoScan()
        {
            //TODO
        }

        public static string GetNumbers()
        {
            string result = null;
            IObservable<string> range = Observable.Range(1, 10)
                .Select(num => num.ToString())
                .Aggregate((acc, num) => acc + " | " + num);
            IDisposable disp = range.Subscribe(item => result = item);

            return result;
        }

        public static IObservable<string> GetNumbersObs()
        {
            IObservable<string> result = Observable.Range(1, 10)
                .Select(num => num.ToString())
                .Aggregate((acc, num) => acc + " | " + num);
            return result;
        }

        public static IObservable<DateTime?> GetDates()
        {
            DateTime? start = DateTime.Now.AddDays(-7);
            IObservable<DateTime?> pages = Observable.Range(1, 50)
                .Scan(start, (acc, num) => GetDate(acc))
                .TakeWhile(dt => dt != null);
            return pages;
        }

        private static DateTime? GetDate(DateTime? lastDT)
        {
            DateTime? nextDT = lastDT?.AddDays(1);
            return (nextDT < DateTime.Now)
                ? nextDT
                : null;
        }

        #endregion

    }
}
