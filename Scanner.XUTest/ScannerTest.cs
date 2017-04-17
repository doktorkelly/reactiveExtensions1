using Rx1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Scanner.XUTest
{
    public class ScannerTest
    {
        //private ILogger logger = null;
        private readonly ITestOutputHelper output;

        public ScannerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DoScan_x_y()
        {
            //Arrange
            Rx1.Scanner scan = new Rx1.Scanner();

            //Act
            Rx1.Scanner.DoScan();

            //Assert
            output.WriteLine("DoScan: " + null);
        }

        [Fact]
        public void GetNumbers_x_y()
        {
            //Arrange
            Rx1.Scanner scan = new Rx1.Scanner();

            //Act
            string result = Rx1.Scanner.GetNumbers();

            //Assert
            output.WriteLine("result: " + result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetNumbersObs_x_y()
        {
            //Arrange
            Rx1.Scanner scan = new Rx1.Scanner();

            //Act
            IObservable<string> result = Rx1.Scanner.GetNumbersObs();
            var disp = result.Subscribe(new OutputObserver(output));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetDates_x_y()
        {
            //Arrange
            Rx1.Scanner scan = new Rx1.Scanner();

            //Act
            IObservable<string> result = Rx1.Scanner.GetDates()
                .Select(dt => dt.ToString());
            var disp = result.Subscribe(new OutputObserver(output));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPages_x_y()
        {
            //Arrange
            Rx1.Scanner scan = new Rx1.Scanner();

            //Act
            IObservable<string> result = Rx1.Scanner.GetPages(DateTime.Today.AddDays(-5))
                .Select(pageTup => pageTup?.ToString());
            var disp = result.Subscribe(new OutputObserver(output));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPagesQR_Observable_Output()
        {
            //Arrange
            Rx1.Scanner scan = new Rx1.Scanner();
            PageRequest request = new PageRequest("url", "chan1", 
                DateTime.Today.AddDays(-2),
                DateTime.Today.AddDays(0),
                DateTime.Now.AddDays(-7));

            //Act
            IObservable<string> pages = Rx1.Scanner.GetPagesQR(request)
                .Select(pageTup => pageTup?.ToString());
            var disp = pages.Subscribe(new OutputObserver(output));

            //Assert
            Assert.NotNull(pages);
            Assert.NotEmpty(output.ToString());
            //Assert.Contains("OnNext:\r\nRequest: ModifAfter: 10.04.2017", output.ToString());
        }

        [Fact]
        public void GetPagesList_Observable_List()
        {
            //Arrange
            Rx1.Scanner scan = new Rx1.Scanner();
            PageRequest request = new PageRequest("url", "chan1",
                DateTime.Today.AddDays(-2),
                DateTime.Today.AddDays(0),
                DateTime.Now.AddDays(-7));

            //Act
            IEnumerable<PageQR> pages = Rx1.Scanner.GetPagesList(request);

            //Assert
            output.WriteLine(ToString(pages));
            Assert.NotNull(pages);
            Assert.NotEmpty(pages);
        }

        #region helper

        private static string ToString(IEnumerable<PageQR> pages)
        {
            string result = pages?.Select(page => page.ToString())
                .Aggregate((acc, p) => acc + "\r\n" + p);
            return result;
        }

        #endregion

    }
}
