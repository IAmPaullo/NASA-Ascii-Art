using System;
using System.Drawing;
namespace Ascii_Art
{
    class Program
    {
        static string DESTINATION_PATH;
        static string IMAGE_FULL_PATH;
        static string IMAGE_NAME;
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 50);
            FolderConfig.SetupFolderConfig(ref DESTINATION_PATH);
            ImageDownload.GetAndSaveImageFromURL(DESTINATION_PATH);
            IMAGE_FULL_PATH = ImageDownload.IMAGE_FULL_PATH;
            Bitmap image = new Bitmap(IMAGE_FULL_PATH);
            ImageProcessing imageProcessing = new ImageProcessing(image);
        }
    }
}