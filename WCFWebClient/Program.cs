using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client("BasicHttpBinding_IService1");

            client.Open();

            for(int i = 0; i < 25; i += 5)
            {
                showFactorial(client, i);
            }
            Console.WriteLine("Press <ENTER> to exit!");
            Console.ReadKey();

            client.Close();
        }

        static void showFactorial(Service1Client client, long n)
        {
            Console.WriteLine($"Result: {n}! = {client.factorial(n)}");
        }
    }
}
