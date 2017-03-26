using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonWayTest.Service
{
    public abstract class BaseService : IServiceFactory
    {
        private ServiceFactory _serviceFactory;

        public ServiceFactory ServiceFactory
        {
            get
            {
                if (_serviceFactory == null)
                {
                    ServiceFactory = ServiceFactory.Current;
                }

                return _serviceFactory;
            }
            set { _serviceFactory = value; }
        }
    }
}
