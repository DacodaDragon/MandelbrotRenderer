using System.Drawing;
using System;
using System.Collections.Generic;

namespace MandelbrotRenderer
{
    /// <summary>
    /// Quick and dirty implementation of a curve in color space
    /// </summary>
    class ColorCurve
    {
        private Curve _R, _G, _B;

        public ColorCurve(Curve r, Curve g, Curve b)
        {
            this._R = r;
            this._G = g;
            this._B = b;
        }

        public Color Sample(double value)
        {
            int r = (int)Math.Min(_R.Sample(value) * 255, 255);
            int g = (int)Math.Min(_G.Sample(value) * 255, 255);
            int b = (int)Math.Min(_B.Sample(value) * 255, 255);
            return Color.FromArgb(r, g, b);
        }

        public static ColorCurve Parse(string args)
        {
            string[] values = args.Split(' ');

            List<Keyframe> redCurve = new List<Keyframe>();
            List<Keyframe> greenCurve = new List<Keyframe>();
            List<Keyframe> blueCurve = new List<Keyframe>();

            for (int j = 0; j < values.Length; j++)
            {
                switch (values[j].ToLower())
                {
                    case "r":
                        while (j + 2 < values.Length && double.TryParse(values[++j], out double pos) && double.TryParse(values[++j], out double val))
                            redCurve.Add(new Keyframe(pos, val));
                        --j;
                        break;
                    case "g":
                        while (j + 2 < values.Length && double.TryParse(values[++j], out double pos) && double.TryParse(values[++j], out double val))
                            greenCurve.Add(new Keyframe(pos, val));
                        --j;
                        break;
                    case "b":
                        while (j + 2 < values.Length && double.TryParse(values[++j], out double pos) && double.TryParse(values[++j], out double val))
                            blueCurve.Add(new Keyframe(pos, val));
                        --j;
                        break;
                }
            }

            return new ColorCurve(
                new Curve(redCurve.ToArray()),
                new Curve(greenCurve.ToArray()),
                new Curve(blueCurve.ToArray()));
        }
    }
}
