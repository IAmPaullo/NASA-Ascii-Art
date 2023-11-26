using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
            string imgTitle = GetTitleFromJSON(json);
            //string imgURL = "https://www.cidademarketing.com.br/marketing/wp-content/uploads/2019/05/Microsoft_logo.png";
            string IMAGE_NAME = Path.GetFileName(new Uri(imgURL).AbsolutePath);
            IMAGE_FULL_PATH = destinationFolder + "\\" + IMAGE_NAME;
            Task downloadTask = webClient.DownloadFileTaskAsync(new Uri(imgURL), IMAGE_FULL_PATH);
            CheckDownloadProgress(webClient);
            downloadTask.ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("Image downloaded successfully!");
                }
                else if (task.Status == TaskStatus.Canceled)
                {
                    Console.WriteLine("Image download canceled.");
                }
                else
                {
                    Console.WriteLine("Image download failed.");
                }
            });
            Task.WaitAll(downloadTask);
            ClearConsoleSequence();
            Console.WriteLine($"Title: {imgTitle}");
        }

        private static void CheckDownloadProgress(WebClient webClient)
        {
            webClient.DownloadProgressChanged += (sender, e) =>
            {
                long bytesDownloaded = e.BytesReceived;
                long totalBytesToDownload = e.TotalBytesToReceive;
                float progressPercentage = (float)bytesDownloaded / totalBytesToDownload * 100;

                Console.WriteLine($"Download progress: {progressPercentage}%");
            };
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
            Console.WriteLine("Failed to obtain NASA APOD JSON");
            return null;
        }

        static string GetUrlDataFromJSON(string json)
        {
            JObject obj = JObject.Parse(json);
            string url = obj["url"].ToString();
            return url;
        }
        static string GetTitleFromJSON(string json)
        {
            JObject obj = JObject.Parse(json);
            string title = obj["title"].ToString();
            return title;
        }

        static void ClearConsoleSequence()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 4; i++)
            {

                Console.WriteLine("Clearing Console...");
                Thread.Sleep(500);
                Console.Clear();
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(1500);
        }
    }
}
