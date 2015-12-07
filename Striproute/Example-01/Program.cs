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

            var allStriproutes = webclient.DownloadString("http://opendata.brussels.be/api/records/1.0/search?dataset=striproute0");

            //Console.WriteLine(jsonData);

            JObject striproutes = JObject.Parse(allStriproutes);

            //var listStripfiguren = (string)jObject.Descendants().OfType<JProperty>().Where(p => p.Name == "personnage_s").First().Value;

            //Console.WriteLine(listStripfiguren);


            JArray listStripfiguren = (JArray)striproutes["records"];

            IList<string> strStripfiguren = listStripfiguren.Select(p => (string)p).ToList();

            Console.WriteLine(listStripfiguren);

            Console.ReadKey();
            
        }

        
    }
}
