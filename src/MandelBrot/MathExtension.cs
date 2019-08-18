namespace MandelbrotRenderer
{
    /// <summary>
    /// Container for globally used math
    /// </summary>
    class MathExtension
    {
        public static double MapRange(double s, double a1, double a2, double b1, double b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
    }
}
