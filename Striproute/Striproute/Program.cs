using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Striproute
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webclient = new WebClient();

            String allStriproutes;

            JObject allStrips = new JObject();

            try
            {
                allStriproutes = webclient.DownloadString(@"http://opendata.brussels.be/api/records/1.0/search/?dataset=striproute0&rows=100");

                allStrips = JObject.Parse(allStriproutes);

                Console.WriteLine(allStrips);
            }
            catch (WebException ex)
            {
                Console.WriteLine("Cannot find the online web API.");
            }

            Console.ReadKey();
        }
    }
}
