namespace MandelbrotRenderer
{
    /// <summary>
    /// Quick and dirty implementation of a keyframe for in curves
    /// </summary>
    struct Keyframe
    {
        public double position;
        public double value;

        public Keyframe(double position, double value)
        {
            this.position = position;
            this.value = value;
        }
    }
}
