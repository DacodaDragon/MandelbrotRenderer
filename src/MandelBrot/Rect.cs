namespace MandelbrotRenderer
{
    /// <summary>
    /// Quick implementation of a Rectangle
    /// </summary>
    struct Rect
    {
        public double left, right, top, bottom;
        public double Width => right - left;
        public double Height => top - bottom;

        public double MapWidth (double x, double min, double max) => MathExtension.MapRange(x, min, max, left, right);
        public double MapHeight(double x, double min, double max) => MathExtension.MapRange(x, min, max, top, bottom);

        public Rect(double left, double right, double top, double bottom)
        {
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }

        public override string ToString()
        {
            return $"({left}. {right}, {top}, {bottom})";
        }
    }
}
