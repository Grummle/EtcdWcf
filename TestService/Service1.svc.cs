using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using etcetera;

namespace TestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static void Configure(ServiceConfiguration config)
        {
            //ServiceEndpoint se = new ServiceEndpoint(new ContractDescription("IService1"), new BasicHttpBinding(), new EndpointAddress("http://localhost/testservice/service1.svc"));
            //se.Behaviors.Add(new MyEndpointBehavior());
            //config.AddServiceEndpoint(se);

            config.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            config.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

            var etcd = new EtcdClient(new Uri("http://localhost:4001/v2/keys/"));
            etcd.Set("local/EtcdPrototype.IService1/url", config.BaseAddresses.First().ToString());
//            etcd.Set("local/EtcdPrototype.IService1/binding",config.)
        }

        public string GetData()
        {
            return "Herp Derp";
        }

        public string HelloNewman(string param1)
        {
            return "Hello Sienfeld....";
        }
    }
}
