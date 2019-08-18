using System;
using System.Drawing;
using System.Diagnostics;

namespace MandelbrotRenderer
{
    /// <summary>
    /// Renders a 2D double array into a colored BMP
    /// </summary>
    static class ValueGridBitmapRenderer
    {
        public static void Render(Array2D<double> array)
        {
            Bitmap bitmap = new Bitmap(array.Width, array.Height);

            double maxValue = 0;
            array.Each(x => { maxValue = Math.Max(maxValue, x); });


            Stopwatch stopwatch = Stopwatch.StartNew();
            Stopwatch timer = Stopwatch.StartNew();

            array.Each((x, y) =>
            {
                if (stopwatch.ElapsedMilliseconds > 40)
                {
                    int percentage = (int)(((x * array.Height) + y) / (double)array.TotalSize * 100);
                    Console.Write($"\rRendering to BMP: {percentage}% x:{x} y:{y}");
                    stopwatch.Restart();
                }
                bitmap.SetPixel(x, y, GetColor(array[x, y], maxValue));
            });

            Console.WriteLine($"\rRendering to BMP: 100% x:{array.Width} y:{array.Height}");
            Console.WriteLine($"Rendering Completed: {timer.Elapsed}");
            bitmap.Save(Settings.Global.ImageName);
        }

        private static Color GetColor(double value, double maxValue)
            => Settings.Global.ColorCurve.Sample(MathExtension.MapRange(value, 0, maxValue, 0, 1));
    }
}
