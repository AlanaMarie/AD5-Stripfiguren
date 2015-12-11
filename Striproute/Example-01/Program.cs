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

            //Console.WriteLine(allStrips);

            //var strips = from records in allStrips["records"]
            //             //from fields in records["personnage_s"]
            //             select records["fields"].Values<String>();

            //foreach (var strip in strips)
            //{
            //    Console.WriteLine(strip.ToString());
            //}

            var listStripfiguren = allStrips.Descendants().OfType<JProperty>().Where(p => p.Name == "personnage_s").ToList<JProperty>();

            foreach (var strip in listStripfiguren)
            {
                Console.WriteLine(strip.ToString());
            }

            Console.WriteLine(listStripfiguren);

            //var fields = allStrips["records"].Children()["fields"];

            //var personages = fields.Children()["personnage_s"];

            //foreach (var personage in personages)
            //{
            //    Console.WriteLine(personage.ToString());
            //}

            Console.ReadKey();

        }

        

    }

}
