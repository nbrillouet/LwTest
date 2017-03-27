using System;
using System.Web.Services;
using LemonWayTest.Service;
using System.Web.Script.Services;
using LemonWayTestService;

namespace LemonWayTest.Web
{
    /// <summary>
    /// LemonWayTestWebService:
    /// GetNthFibonacci
    /// XmlToJson
    /// </summary>
    [WebService(Namespace = "http://localhost/LemonWayTestWebService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class LemonWayTestWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public decimal GetNthFibonacci(int n)
        {
            Log4NetService.For(this).Info("BEGIN: Request GetNthFibonacci | parameter(" + n + ")");
            decimal nth;
            try
            {
                nth = ServiceFactory.Current.FibonacciService.GetNthFibonacci(n);
                Log4NetService.For(this).Info("END: Request GetNthFibonacci | RETURN(" + nth + ")");
                return nth;
            }
            catch(Exception e)
            {
                Log4NetService.For(this).Fatal("END: Request GetNthFibonacci | ERROR: (" + e.Message + ")");
                throw e;
            }
            
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void XmlToJson(string s)
        {
            Context.Response.Write(ServiceFactory.Current.XmlToJsonService.XmlToJson(s));
        }
    }
}
