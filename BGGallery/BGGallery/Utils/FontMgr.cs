using System.Drawing;
using System.Drawing.Text;

namespace BGGallery.Utils
{
    class FontMgr
    {
        private static PrivateFontCollection privateFontCollection = new PrivateFontCollection();
        public static void Init()
        {
            privateFontCollection.AddFontFile("方正兰亭特黑简体.ttf");
        }

        public static Font GetFont(float size)
        {
            return new Font(privateFontCollection.Families[0], size);
        }
    }
}
