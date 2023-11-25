using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascii_Art
{
    class ImageProcessing
    {
        static char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '@' };
       static int height;
       static int width;
        public ImageProcessing(Bitmap image)
        {
            height = 40;
            width = 80;
            CreateAsciiArt(image);

        }


        private static void CreateAsciiArt(Bitmap image)
        {
            if (image == null)
            {
                Console.WriteLine("No image could be found");
                return;
            }

            float scaleX = (float)image.Width / width;
            float scaleY = (float)image.Height / height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int originX = (int)(x * scaleX);
                    int originY = (int)(y * scaleY);

                    Color pixelColor = image.GetPixel(originX, originY);
                    char asciiSymbol = GetAsciiChar(pixelColor);
                    Console.Write(asciiSymbol);
                }
                Console.WriteLine();
            }
        }

        private static char GetAsciiChar(Color color)
        {
            int grayValue = (color.R + color.G + color.B) / 3;
            int index = grayValue * (asciiChars.Length - 1) / 255;
            return asciiChars[index];
        }
    }


}
