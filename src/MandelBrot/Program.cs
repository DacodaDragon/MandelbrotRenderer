using System;
using System.Globalization;
using System.Threading;

namespace MandelbrotRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            AppDomain.CurrentDomain.ProcessExit += (a, b) =>
            {
                Console.CursorVisible = true;
            };

            Settings.Global.SetFromArgs(args);

            Array2D<double> values = MandelBrot.GetValues(
                Settings.Global.MandelbrotSection,
                Settings.Global.ImageWidth,
                Settings.Global.ImageHeight);

            ValueGridBitmapRenderer.Render(values);
        }
    }
}
