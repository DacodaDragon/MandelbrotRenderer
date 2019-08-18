using System;
using System.Collections.Generic;

namespace MandelbrotRenderer
{
    /// <summary>
    /// Contains global settings for this project
    /// </summary>
    class Settings
    {
        public static Lazy<Settings> _global = new Lazy<Settings>();
        public static Settings Global => _global.Value;

        public int ImageWidth { get; private set; } = 1920;
        public int ImageHeight { get; private set; } = 1080;
        public int Iterations { get; private set; } = 1000;
        public string ImageName { get; private set; } = "Mandelbrot.bmp";
        public Rect MandelbrotSection { get; private set; } = new Rect(-2, 1, 1, -1);
        public ColorCurve ColorCurve { get; private set; } = ColorCurve.Parse("r 0 0 1 1 g 0 0 1 1 b 0 0 1 1");

        public void SetFromArgs(string[] args)
        {
            if (args.Length == 1 && (args[0] == "?" || args[0] == "help"))
            {
                Console.WriteLine("-r imageWidth imageHeight");
                Console.WriteLine("-s left right top bottom");
                Console.WriteLine("-fn filename");
                Console.WriteLine("-c ColorCurve");
                Console.WriteLine("-i iterations");
                Environment.Exit(0);
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-r" || args[i] == "-res" || args[i] == "-resolution")
                {
                    ImageWidth = int.Parse(args[++i]);
                    ImageHeight = int.Parse(args[++i]);
                }

                if (args[i] == "-i")
                {
                    Iterations = int.Parse(args[++i]);
                }

                if (args[i] == "-s")
                {
                    MandelbrotSection = new Rect(
                        MathExtension.MapRange(double.Parse(args[++i]), 0, 1, -2, 1),
                        MathExtension.MapRange(double.Parse(args[++i]), 0, 1, -2, 1),
                        MathExtension.MapRange(double.Parse(args[++i]), 0, 1, -1, 1),
                        MathExtension.MapRange(double.Parse(args[++i]), 0, 1, -1, 1));
                }

                if (args[i] == "-c")
                {
                    ColorCurve = ColorCurve.Parse(args[++i]);
                }
            }
        }
    }
}
