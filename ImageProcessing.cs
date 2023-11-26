using System;
using System.Drawing;


namespace Ascii_Art
{
    class ImageProcessing
    {
        static readonly char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '@' };
        static int height;
        static int width;

        const float luminosityR = 0.2126f;
        const float luminosityG = 0.7152f;
        const float luminosityB = 0.0722f;
        const float pBrightnessR = 0.2989f;
        const float pBrightnessG = 0.5870f;
        const float pBrightnessB = 0.1140f;
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
        private static char GetAsciiCharLuminosity(Color color)
        {
            float grayValue = (luminosityR * color.R + luminosityG * color.G + luminosityB * color.B) / 3;
            int index = (int)grayValue * (asciiChars.Length - 1) / 255;
            return asciiChars[index];
        }
        private static char GetAsciiCharPerceivableBrightness(Color color)
        {
            float grayValue = (pBrightnessR * color.R + pBrightnessG * color.G + pBrightnessB * color.B) / 3;
            int index = (int)grayValue * (asciiChars.Length - 1) / 255;
            return asciiChars[index];
        }
        //private static char GetColoredAsciiChar(Color color)
        //{
        //    int grayValue = (color.R + color.G + color.B) / 3;
        //    int index = grayValue * (asciiChars.Length - 1) / 255;
        //    ConsoleColor consoleColor = newColor;
        //    Console.ForegroundColor = newColor;
        //    return asciiChars[index];
        //TODO:maybe implement color library??
        //}
    }


}
