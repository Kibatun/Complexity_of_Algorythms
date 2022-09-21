using System;

namespace Recognizer
{
    public static class GrayscaleTask
    {
        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var width = original.GetLength(0);
            var length = original.GetLength(1);
            var grayscale = new double[width, length];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    var pixelR = Convert.ToDouble(original[i, j].R);
                    var pixelG = Convert.ToDouble(original[i, j].G);
                    var pixelB = Convert.ToDouble(original[i, j].B);
                    var toGray = (0.299 * pixelR + 0.587 * pixelG + 0.114 * pixelB) / 255;
                    grayscale[i, j] = toGray;
                }
            }

            return grayscale;
        }
    }
}