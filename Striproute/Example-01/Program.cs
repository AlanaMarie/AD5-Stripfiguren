using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Example_01
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webclient = new WebClient();

            String allStriproutes = webclient.DownloadString(@"http://opendata.brussel.be/api/records/1.0/search/?dataset=striproute0");

            JObject allStrips = JObject.Parse(allStriproutes);

            var listStripfiguren = allStrips.Descendants().OfType<JProperty>().Where(p => p.Name == "personnage_s").ToList<JProperty>();

            foreach (var strip in listStripfiguren)
            {
                Console.WriteLine(strip.Value);
            }

            Console.WriteLine(listStripfiguren);

            Console.ReadKey();

        }

        

    }

}
