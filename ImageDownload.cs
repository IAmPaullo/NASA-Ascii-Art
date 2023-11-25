using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Ascii_Art
{
    public class ImageDownload
    {
        const string apiKey = "JNu1S2fQ6azkWzBJsicY6TvSJfLVNuB3dRf2IcMd";
        static string apiUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}";
        public static string IMAGE_FULL_PATH;
        public static void GetAndSaveImageFromURL(string destinationFolder)
        {
            WebClient webClient = new WebClient();
            string json = GetNasaPicJSON();
            string imgURL = GetUrlDataFromJSON(json);
            //string imgURL = "https://www.cidademarketing.com.br/marketing/wp-content/uploads/2019/05/Microsoft_logo.png";
            //string imgURL = apiUrl;
            //string picData = await GetNASAData(apiUrl);
            //if (!string.IsNullOrEmpty(picData))
            //{
            //    // Process and display the POTD data (you can customize this part)
            //    Console.WriteLine(picData);
            //}
            //else
            //{
            //    Console.WriteLine("Failed to retrieve NASA POTD.");
            //}
            string IMAGE_NAME = Path.GetFileName(new Uri(imgURL).AbsolutePath);
            IMAGE_FULL_PATH = destinationFolder + "\\" + IMAGE_NAME;
            Task downloadTask = webClient.DownloadFileTaskAsync(new Uri(imgURL), IMAGE_FULL_PATH);
            Task.WaitAll(downloadTask);
            Console.WriteLine("Image downloaded sucessfully!");
        }

        static string GetNasaPicJSON()
        {
            HttpClient httpClient = new HttpClient();
            string url = apiUrl;
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string body = response.Content.ReadAsStringAsync().Result;
                return body;
            }
            Console.WriteLine("Falha ao obter o JSON da API da NASA");
            return null;
        }

        static string GetUrlDataFromJSON(string json)
        {
            JObject obj = JObject.Parse(json);
            string url = obj["url"].ToString();
            return url;
        }

        //static async Task<String> 
    }
}
