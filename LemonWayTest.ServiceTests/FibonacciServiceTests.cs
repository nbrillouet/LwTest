using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonWayTest.Service.Tests
{
    [TestClass()]
    public class FibonacciServiceTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
        [DeploymentItem(@"..\..\Datas\Fibonacci.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Fibonacci.xml", "Row", DataAccessMethod.Sequential)]
        public void GetNthFibonacciTest()
        {
            // Arrange
            int n = (int)TestContext.DataRow[0];
            decimal expected = (decimal)TestContext.DataRow[1];
            string message = TestContext.DataRow[2].ToString();

            // Act
            decimal result = ServiceFactory.Current.FibonacciService.GetNthFibonacci(n);

            // Assert
            Assert.AreEqual(expected, result,message);
        }
    }
}