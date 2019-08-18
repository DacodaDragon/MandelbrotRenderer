
using System.Diagnostics;

namespace MandelbrotRenderer
{
    /// <summary>
    /// Contains the mandelbrot formula and a utility function to fill a 2D array with values from a section of the mandelbrot. 
    /// </summary>
    static class MandelBrot
    {
        const double MAX_VALUE_EXTENT = 2.0;
        const double MAX_NORM = MAX_VALUE_EXTENT * MAX_VALUE_EXTENT;

        public static double Calculate(ComplexNumber c)
        {
            int maxIterations = Settings.Global.Iterations;

            ComplexNumber z = ComplexNumber.Zero;
            int i = 0;

            do { z = z * z + c; ++i; }
            while (z.Norm < MAX_NORM && i < maxIterations);

            if (i < maxIterations)
                return (double)i / maxIterations;

            return 0;
        }

        public static Array2D<double> GetValues(Rect rect, int pixelWidth, int pixelHeight)
        {
            Array2D<double> array2D = new Array2D<double>(pixelWidth, pixelHeight);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Stopwatch timer = Stopwatch.StartNew();

            array2D.Each((x, y) =>
            {
                if (stopwatch.ElapsedMilliseconds > 40)
                {
                    int percentage = (int)(((x *array2D.Height) + y) / (double)array2D.TotalSize * 100);
                    System.Console.Write($"\rCalculating Mandelbrot: {percentage}% x:{x} y:{y}");
                    stopwatch.Restart();
                }
                return Calculate(new ComplexNumber(rect.MapWidth(x, 0, pixelWidth), rect.MapHeight(y, 0, pixelHeight)));
            });

            System.Console.WriteLine($"\rCalculating Mandelbrot: 100% x:{array2D.Width} y:{array2D.Height}");
            System.Console.WriteLine($"Calculations done: {timer.Elapsed}");
            return array2D;
        }
    }
}
