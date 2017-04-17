using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Scanner.XUTest
{
    public class OutputObserver : IObserver<string>
    {
        private readonly ITestOutputHelper output;

        public OutputObserver(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void OnCompleted()
        {
            output.WriteLine("OnCompleted");
        }

        public void OnError(Exception error)
        {
            output.WriteLine("OnError: " + error);
        }

        public void OnNext(string value)
        {
            output.WriteLine("OnNext: " + value);
        }
    }
}
