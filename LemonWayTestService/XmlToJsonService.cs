using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LemonWayTest.Service
{
    public class XmlToJsonService: BaseService
    {
        /// <summary>
        ///  takes input a string s, and return a json using Newtonsoft library
        /// </summary>
        /// <param name="s">string must be in xml format</param>
        /// <returns>json conversion of the xml parameter</returns>
        public string XmlToJson(string s)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(s);
                return JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception e)
            {
                if (e.Source == "System.Xml")
                    return ("Bad Xml format");
                else
                    return e.Message;
            }
        }
    }
}
