using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WCFRestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Pick format (xml or json):");
                    string format = Console.ReadLine();

                    Console.WriteLine("Pick method (GET or PUT):");
                    string method = Console.ReadLine();

                    Console.WriteLine("Specify RELATIVE url");
                    string path = Console.ReadLine();

                    string uri = $"http://localhost:50248/RestService.svc/{format}/{path}";

                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;

                    Console.WriteLine($"Sending request to {uri}");

                    req.KeepAlive = false;
                    req.Method = method.ToUpper();

                    if (format == "xml")
                        req.ContentType = "text/xml";
                    else
                        req.ContentType = "application/json";

                    switch (method.ToUpper())
                    {
                        case "GET":
                            break;
                        case "PUT":
                            Console.WriteLine("Paste the XML or JSON content");
                            string data = Console.ReadLine();

                            byte[] buffer = Encoding.UTF8.GetBytes(data);
                            req.ContentLength = buffer.Length;

                            Stream postData = req.GetRequestStream();

                            postData.Write(buffer, 0, buffer.Length);
                            postData.Close();
                            break;
                        default:
                            break;
                    }

                    HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader responseStream = new StreamReader(response.GetResponseStream(), enc);

                    string responseString = responseStream.ReadToEnd();

                    responseStream.Close();
                    response.Close();

                    Console.WriteLine($"Server Response: \n{responseString}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

                Console.WriteLine("\nDo you want to continue? (Y or N)");
            } while (Console.ReadLine().ToUpper() == "Y");
                      
        }
    }
}
