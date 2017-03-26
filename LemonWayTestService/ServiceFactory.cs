using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonWayTest.Service
{
    public interface IServiceFactory
    {
        ServiceFactory ServiceFactory
        {
            get;
            set;
        }
    }

    public sealed class ServiceFactory
    {
        private ServiceFactory()
        { }

        internal static ServiceFactory New
        {
            get
            {
                return new ServiceFactory();
            }
        }


        public static ServiceFactory Current { get { return Nested.current; } }

        private class Nested
        {
            static Nested()
            { }

            internal static readonly ServiceFactory current = new ServiceFactory();
        }

        private T CreateService<T>() where T : new()
        {
            T item = new T();

            (item as IServiceFactory).ServiceFactory = ServiceFactory.Current;
            return item;
        }

        private FibonacciService _internalFibonacciService;
        ///<summary>
        /// Current FibonacciService instance.
        ///</summary>
        public FibonacciService FibonacciService
        {
            get
            {
                if (_internalFibonacciService == null)
                {
                    _internalFibonacciService = CreateService<FibonacciService>();
                }
                return _internalFibonacciService;
            }
        }

        private XmlToJsonService _internalXmlToJsonService;
        ///<summary>
        /// Current FibonacciService instance.
        ///</summary>
        public XmlToJsonService XmlToJsonService
        {
            get
            {
                if (_internalXmlToJsonService == null)
                {
                    _internalXmlToJsonService = CreateService<XmlToJsonService>();
                }
                return _internalXmlToJsonService;
            }
        }
    }
}
