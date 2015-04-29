using System;
using System.IO;
using System.Net;
using System.Text;
namespace HarkkatyöTietokannat
{
    class haku
    {
        static string apiKey = "BekzCh4TblzdA9oe962E";
        public static string etsi(string ryhma)
        {
            String aika = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd'T'HH:mm");

            String alkuosa = "{ 'studentGroup': ['" + ryhma;
            String valiosa = "'],'startDate':'" + aika;
            String loppuosa = "'}";

            String lopullinen = alkuosa + valiosa + loppuosa;

            string postData = lopullinen;

            // Webrequest
            WebRequest request = WebRequest.Create("https://opendata.tamk.fi/r1/reservation/search?apiKey="+apiKey);
            request.Method = "POST";

            // Postdata bytearray
          
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // Response
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
