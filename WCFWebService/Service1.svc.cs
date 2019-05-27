using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFWebService
{
    public class Service1 : IService1
    {
        public long factorial(long value)
        {
            long result = 1;
            for(long i = 1; i <= value; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
