using System;
using System.Text;

namespace MandelbrotRenderer
{
    /// <summary>
    /// Wrapper around a 2D array with some utility functions I found handy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Array2D<T>
    {
        private T[][] _Array;

        public int Width { get; }
        public int Height { get; }
        public int TotalSize => Width * Height;

        public Array2D(int width, int height)
        {
            Width = width;
            Height = height;

            _Array = new T[width][];

            for (int i = 0; i < width; i++)
                _Array[i] = new T[height];
        }

        public void Each(Func<int, int, T> _Callback)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    _Array[x][y] = _Callback(x, y);
        }

        public void Each(Action<int, int> _Callback)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    _Callback(x, y);
        }

        public void Each(Action<T> _Callback)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                     _Callback(_Array[x][y]);
        }

        public T this[int x, int y]
        {
            get { return _Array[x][y]; }
            set { _Array[x][y] = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    sb.Append(this[x, y].ToString()).Append(", ");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
