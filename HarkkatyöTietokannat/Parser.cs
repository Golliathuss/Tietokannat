using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace HarkkatyöTietokannat
{
    class Parser
    {
        public static string[] parseri(string data)
        {
            // Katsotaan montako varausta löytyi
            String testi = "subject";
            int count = (data.Length - data.Replace(testi, "").Length) / testi.Length;
            
            // Jokaisesta varauksesta 3 tietoa talteen
            string[] varaus;
            varaus = new string[count*3];

            int k = 0;
            JObject o = JObject.Parse(data);

            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            varaus[k] = ("Name: " + o["reservations"][j]["subject"]);
                            k++;
                            break;
                        case 1:
                            varaus[k] = ("Startdate: " + o["reservations"][j]["startDate"]);
                            k++;
                            break;
                        case 2:
                            varaus[k] = ("Enddate: " + o["reservations"][j]["endDate"]);
                            k++;
                            break;

                    }
                   
                }
            }
            return varaus;
        }

    }
}
