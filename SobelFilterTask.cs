using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] TransposeMatrix(double[,] sx)
        {
            // получаем размеры матрицы
            var width = sx.GetLength(0);
            var height = sx.GetLength(1);
            //вводим матрицу, которая должна быть результатом транспонирования
            var sy = new double[height, width];
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    sy[j, i] = sx[i, j];
            return sy;
        }

        public static double Multiply(double[,] g, double[,] xy, int shift, int x, int y)
        {
            var sxWidth = xy.GetLength(0);
            var multiplication = 0.0;
            for (var i = 0; i < sxWidth; i++)
                for (var j = 0; j < sxWidth; j++)
                    multiplication += xy[i, j] * g[x - shift + i, y - shift + j];

            return multiplication;
        }

        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var result = new double[g.GetLength(0), g.GetLength(1)];

            var shift = sx.GetLength(0) / 2;
            // минимальное смещение от границ матрицы-изображения (на половину матрицы-маски)
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var sy = TransposeMatrix(sx);


            for (var x = shift; x < width - shift; x++)
                for (var y = shift; y < height - shift; y++) // для каждого пикселя в изображении
                {
                    var gx = Multiply(g, sx, shift, x, y);
                    var gy = Multiply(g, sy, shift, x, y);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }
    }
}