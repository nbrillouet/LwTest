using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonWayTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LemonWayTest.Service.Tests
{
    [TestClass()]
    public class XmlToJsonServiceTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
        [DeploymentItem(@"..\..\Datas\XmlToJson.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "XmlToJson.xml", "Row", DataAccessMethod.Sequential)]
        public void XmlToJsonTest()
        {
            
            // Arrange
            string s = (string)TestContext.DataRow[0];
            string expected = (string)TestContext.DataRow[1];
            string message = TestContext.DataRow[2].ToString();
            
            // Act
            //using Newtonsoft.Json.Linq;
            string result = ServiceFactory.Current.XmlToJsonService.XmlToJson(s);

            try
            {
                JObject jsonObject = JObject.Parse(result);
                result = jsonObject.GetType().Name.ToString();
            }
            catch { result = "false"; }

            Assert.AreEqual(expected, result, message);
        }
    }

}