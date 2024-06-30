using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace BGGallery.Utils
{
    class ImageBook
    {
        class ImageInfo {
            public Image BMP;
            public DateTime AccessTime;
        }

        public static ImageBook Instance = new ImageBook();
        private Dictionary<string, ImageInfo> imgDict = new Dictionary<string, ImageInfo>();

        public Image Load(string url)
        {
            if (imgDict.TryGetValue(url, out var rtImg))
            {
                rtImg.AccessTime = DateTime.Now;
                return rtImg.BMP;
            }

            LazyClean();

            if (!File.Exists(url))
                return null;

            var fs = new FileStream(url, FileMode.Open);
            var img = new Bitmap(fs);
            //var wid = Math.Min(250, img.Width);
            //var het = img.Height * wid / img.Width;
            imgDict[url] = new ImageInfo { BMP = img, AccessTime = DateTime.Now };
            fs.Close();
            return imgDict[url].BMP;
        }

        private DateTime lastCheckTime;
        private void LazyClean()
        {
            if (imgDict.Count < 30)
                return;

            var nowTime = DateTime.Now;
            if ((nowTime - lastCheckTime).TotalSeconds < 60)
                return;

            lastCheckTime = nowTime;

            var checkExpire = 300;
            if (imgDict.Count > 50)
                checkExpire = 120; //升级
            else if (imgDict.Count > 100)
                checkExpire = 60; //升级

            var toRemove = new List<string>();
            
            foreach (var img in imgDict)
            {
                if ((nowTime - img.Value.AccessTime).TotalSeconds >= checkExpire)
                    toRemove.Add(img.Key);
            }

            foreach (var str in toRemove)
            {
                imgDict[str].BMP.Dispose();
                imgDict.Remove(str);
            }
            HLog.Info("LazyClean remove={0} total={1}", toRemove.Count, imgDict.Count);
        }
    }
}
