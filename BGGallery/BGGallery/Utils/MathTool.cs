using System;
using System.Collections.Generic;

namespace BGGallery.Utils
{
    public class MathTool
    {
        private static readonly Random r;
        static MathTool()
        {
            var seed = (int)DateTime.Now.Ticks;
            r = new Random(seed);
        }

        public static int GetDistance(System.Drawing.Point x, System.Drawing.Point y)
        {
            return GetDistance(x.X, x.Y, y.X, y.Y);
        }

        public static int GetDistance(int x1, int y1, int x2, int y2)
        {
            return (int)Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public static int GetRandom(int max)
        {
            return r.Next(max);
        }

        public static int GetRandom(int min, int max)
        {
            if (min == max)
                return min;
            return r.Next(min, max);
        }

        public static double GetRandom(double min, double max)
        {
            if (Math.Abs(max - min) < 0.001)
                return min;
            var val = r.NextDouble() * (max - min) + min;
            return val;
        }
        public static bool IsRandomInRange01(float num)
        {
            return GetRandom(0f, 1f) < num;
        }

        public static int GetSqrtMulti10(int value)
        {
            int[] datas = { 0, 10, 14, 17, 20, 22, 24, 26, 28, 30 };
            if (value < 0)
                return 0;
            if (value > 9)
                return datas[9];
            return datas[value];
        }

        public static int GetRound(int value, int checker)
        {
            if (value <= checker)
                return value;

            int small = value % checker;
            int rt = value - small;
            if (small > checker / 2)
            {
                rt += checker;
            }

            return rt;
        }

        public static bool ValueBetween(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static int RandomBetween(double value)
        {
            var floor = Math.Floor(value);
            if (GetRandom(1) >= value - floor)
                return (int)Math.Ceiling(value);
            return (int)floor;
        }
    }

}
