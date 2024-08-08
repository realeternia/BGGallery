using System;
using System.Collections.Generic;
using System.Drawing;

namespace BGGallery.Model.Types
{
    public class TextColorCfg
    {
        public string Text { get; set; }
        public ColorCfg Color { get; set; }

        public TextColorCfg() { }

        public TextColorCfg(string t, Color c)
        {
            Text = t;
            Color = ColorCfg.FromColor(c);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
