namespace MandelbrotRenderer
{
    /// <summary>
    /// Represents a complex number
    /// </summary>
    struct ComplexNumber
    {
        public double re; // real part of complex number
        public double im; // imaginary part of complex number "x*Sqrt(-1))"

        public ComplexNumber(double x, double y)
        {
            this.re = x;
            this.im = y;
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.re + b.re, a.im + b.im);

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);

        public double Norm
            => re * re + im * im;

        public static ComplexNumber Zero 
            => new ComplexNumber();
    }
}
