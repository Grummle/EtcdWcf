using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TestService;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code is written by an application developer.
            // Create a channel factory.
            BasicHttpBinding myBinding = new BasicHttpBinding();

            EndpointAddress myEndpoint = new EndpointAddress("http://localhost/TestService/Service1.svc");

            ChannelFactory<IService1> myChannelFactory = new ChannelFactory<IService1>(myBinding, myEndpoint);

            // Create a channel.
            IService1 wcfClient1 = myChannelFactory.CreateChannel();
            var result = wcfClient1.GetData();
            ((IClientChannel)wcfClient1).Close();

            Console.WriteLine(result);

        }
    }
}
