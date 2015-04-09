using System;
using System.IO;
using System.Net;
using System.Text;
namespace HarkkatyöTietokannat
{
    class haku
    {
        public static void etsi()
        {
            String aika = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm");


            string postData = ("{ 'studentGroup': ['12I224'],'startDate':'2015-04-09T12:00'}");
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("https://opendata.tamk.fi/r1/reservation/search?apiKey=BekzCh4TblzdA9oe962E");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
          
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
