namespace MandelbrotRenderer
{
    /// <summary>
    /// Quick and dirty implementation of a keyframed curve where values in between keyframes are interpolated linearly
    /// </summary>
    class Curve
    {
        Keyframe[] _Keyframes;

        public Curve(params Keyframe[] keyframes)
        {
            _Keyframes = keyframes;
        }

        public double Sample(double value)
        {
            for (int i = 1; i < _Keyframes.Length; i++)
                if (value < _Keyframes[i].position)
                    return MathExtension.MapRange(value,
                        _Keyframes[i - 1].position,
                        _Keyframes[i].position,
                        _Keyframes[i - 1].value,
                        _Keyframes[i].value);
            return 1;
        }
    }
}
