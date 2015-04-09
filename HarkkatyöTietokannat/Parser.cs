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
            string[] varaus;
            varaus = new string[3];

            JObject o = JObject.Parse(data);
            for (int i = 0; i < 3; i++)
            {
                switch(i)
                {
                    case 0:
                        varaus[0] = ("Name: " + o["reservations"][0]["subject"]);
                        break;
                    case 1:
                        varaus[1] = ("Startdate: " + o["reservations"][0]["startDate"]);
                        break;
                    case 2:
                        varaus[2] = ("Enddate: " + o["reservations"][0]["endDate"]);
                        break;
                }
            }

            return varaus;
        }

    }
}
