using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Striproute
{
    class Program
    {
        static void Main(string[] args)
        {
            // To extract the data from an online source
            WebClient webclient = new WebClient();

            String allStriproutes;

            // Get's all objects
            JObject allStrips = new JObject();

            // In case the link doesn't work an exception must been thrown.
            try
            {
                // Sends a GET-request
                allStriproutes = webclient.DownloadString(@"http://opendata.brussels.be/api/records/1.0/search/?dataset=striproute0&rows=100");

                // Parses the data from the GET-request
                allStrips = JObject.Parse(allStriproutes);

                // Using LinQ to get a specific field with JProperty
                var listStripfiguren = allStrips.Descendants()
                                                .OfType<JProperty>()
                                                .Where(p => p.Name == "personnage_s")
                                                .ToList<JProperty>();

                // Loop through the list
                foreach (var strip in listStripfiguren)
                {
                    // Use Value instead of ToString()
                    // strip.ToString() will give => "personnage_s" : "TinTin" 
                    // strip.Value will give => Tintin
                    // See the difference?
                    Console.WriteLine(strip.Value);
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Cannot find the online web API.");
            }

            Console.ReadKey();
        }
    }

}
