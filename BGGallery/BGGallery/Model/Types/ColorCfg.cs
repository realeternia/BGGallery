using System;
using System.Collections.Generic;
using System.Drawing;

namespace BGGallery.Model.Types
{
    public class ColorCfg
    {
        public int Value { get; set; }

        public ColorCfg() { }

        public ColorCfg(Color c)
        {
            Value = c.ToArgb();
        }

        public Color ToColor()
        {
            return Color.FromArgb(Value);
        }

        public void Update(Color c)
        {
            Value = c.ToArgb();
        }

        public static ColorCfg FromColor(Color c)
        {
            var cfg = new ColorCfg(c);
            return cfg;
        }
    }
}
