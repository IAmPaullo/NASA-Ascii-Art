using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.IO;

namespace Ascii_Art
{
    class Program
    {
        static string DESTINATION_PATH;
        static string IMAGE_FULL_PATH;
        static string IMAGE_NAME;
        static int screenWidth = Console.LargestWindowWidth / 2;
        static int screenHeight = Console.LargestWindowHeight / 2;
        static int height = 40;
        static void Main(string[] args)
        {
            //Console.SetWindowSize((int)(Console.LargestWindowWidth / 2), (int)(Console.LargestWindowHeight / 2));
            FolderConfig.SetupFolderConfig(ref DESTINATION_PATH);
            ImageDownload.GetAndSaveImageFromURL(DESTINATION_PATH);
            IMAGE_FULL_PATH = ImageDownload.IMAGE_FULL_PATH;
            Bitmap image = new Bitmap(IMAGE_FULL_PATH);
            ImageProcessing imageProcessing = new ImageProcessing(image);
        }




    }
}