using System;
using System.Collections.Generic;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double GetThreshold(double[,] original, double whitePixelsFraction)
        {
            var pixelList = new List<double>();
            // определяем граничную позицию черного-белого в массиве
            var thresholdIndex = (int)(original.Length * whitePixelsFraction);

            foreach (var pixel in original)
                pixelList.Add(pixel);
            pixelList.Sort();

            if (thresholdIndex > 0 && thresholdIndex <= pixelList.Count)
                return pixelList[(int)pixelList.Count - thresholdIndex];
            return Double.MaxValue;
        }

        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            //var original = new double[1, 1];
            //original[0, 0] = 123;
            //double whitePixelsFraction = 1;


            var t = GetThreshold(original, whitePixelsFraction);
            var hLength = original.GetLength(0);
            var vLength = original.GetLength(1);
            var tempList = original;

            for (var h = 0; h < hLength; h++)
                for (var v = 0; v < vLength; v++)
                {
                    if (original[h, v] >= t)
                        tempList[h, v] = 1.0;
                    else
                        tempList[h, v] = 0.0;
                }

            return tempList;
        }
    }
}