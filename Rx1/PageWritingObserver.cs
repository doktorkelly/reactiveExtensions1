using System;
using System.Collections.Generic;
using System.Text;

namespace Rx1
{
    public class PageWritingObserver : IObserver<PageQR>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(PageQR value)
        {
            throw new NotImplementedException();
        }
    }
}
