using System;
using System.Collections.Generic;

namespace ProjectCyborg
{
    /// <summary>
    /// Bi-dimensional grid to store values, works like arrays (even with array-like accessors), but accepts negative indexes.
    /// </summary>
    public class Grid2<T>
    {
        /// <summary>
        /// This is where the data is stored.
        /// </summary>
        Dictionary<Point2, T> content = new Dictionary<Point2, T>();

        /// <summary>
        /// The starting point of the grid (the top-left corner).
        /// </summary>
        public Point2 From { get; }

        /// <summary>
        /// The size of the grid (both X and Y).
        /// </summary>
        public Point2 Size { get; }

        /// <summary>
        /// The width of the grid.
        /// </summary>
        public int Width { get { return Size.X; } }

        /// <summary>
        /// The height of the grid.
        /// </summary>
        public int Height { get { return Size.Y; } }

        /// <summary>
        /// The ending point of the grid (the bottom-right corner).
        /// </summary>
        public Point2 To { get { return From + Size - new Point2(1, 1); } }

        public Grid2(Point2 from, Point2 size, T def = default(T))
        {
            From = from;
            Size = size;
            Fill(def);
        }

        public Grid2(int fromX, int fromY, int width, int height, T def = default(T))
        {
            From = new Point2(fromX, fromY);
            Size = new Point2(width, height);
            Fill(def);
        }

        public void Fill(T value)
        {
            for (var X = From.X; X <= To.X; X++)
            {
                for (var Y = From.Y; Y <= To.Y; Y++)
                {
                    Set(new Point2(X, Y), value);
                }
            }
        }

        void Set(Point2 p, T value)
        {
            if (content.ContainsKey(p))
            {
                content[p] = value;
            }
            else
            {
                content.Add(p, value);
            }
        }

        T Get(Point2 p)
        {
            if (content.ContainsKey(p))
            {
                return content[p];
            }
            else
            {
                throw new Exception("[Grid2] The entry " + p + " doesn't exist.");
            }
        }

        public T this[int x, int y]
        {
            get
            {
                var p = new Point2(x, y);
                return Get(p);
            }

            set
            {
                var p = new Point2(x, y);
                Set(p, value);
            }
        }
        public T this[Point2 p]
        {
            get
            {
                //var p = new Point2(x, y);
                return Get(p);
            }

            set
            {
                //var p = new Point2(x, y);
                Set(p, value);
            }
        }
    }
}
