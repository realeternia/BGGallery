using System;
using System.Drawing;

namespace BGGallery.Utils
{
    public static class ColorClassifier
    {
        public enum ColorSeries
        {
            Red,
            Yellow,
            Green,
            Blue,
            Purple,
            Gray,
       //     Brown,
        }
        public static ColorSeries ClassifyColor(Color color)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;

            int maxComponent = Math.Max(Math.Max(red, green), blue);
            int minComponent = Math.Min(Math.Min(red, green), blue);

            int delta = maxComponent - minComponent;

            double hue = 0;

            if (delta != 0)
            {
                if (maxComponent == red)
                {
                    hue = (green - blue) / (double)delta;
                }
                else if (maxComponent == green)
                {
                    hue = 2 + (blue - red) / (double)delta;
                }
                else
                {
                    hue = 4 + (red - green) / (double)delta;
                }
            }

            hue *= 60;

            if (hue < 0)
            {
                hue += 360;
            }

            if (delta < 30)
            {
                return ColorSeries.Gray;
            }
            if (hue >= 0 && hue <= 20 || hue >= 340 && hue <= 360)
            {
                return ColorSeries.Red;
            }
            else if (hue > 20 && hue <= 70)
            {
                return ColorSeries.Yellow;
            }
            else if (hue > 70 && hue <= 170)
            {
                return ColorSeries.Green;
            }
            else if (hue > 170 && hue <= 260)
            {
                return ColorSeries.Blue;
            }
            else if (hue > 260 && hue <= 320)
            {
                return ColorSeries.Purple;
            }
            else
            {
                return ColorSeries.Red;
              //  return ColorSeries.Brown;
            }
        }
    }

}
