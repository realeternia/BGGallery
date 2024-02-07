using System;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace BGGallery
{
    class ResLoader
    {
        static public Image Read(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                return Properties.Resources._null;

            try
            {
                var dts = path.Split('/');
                Assembly myAssembly = Assembly.LoadFrom("PicResource.dll");
                Stream myStream = myAssembly.GetManifestResourceStream(string.Format("PicResource.{0}.{1}", dts[0], dts[1]));
                if (myStream != null) return new Bitmap(myStream);
            }
            catch
            {
            }
            return Properties.Resources._null;
        }

        static public List<string> GetFileList(string folder)
        {
            try
            {
                Assembly myAssembly = Assembly.LoadFrom("PicResource.dll");
                Stream myStream = myAssembly.GetManifestResourceStream("PicResource.menu.txt");
                if (myStream != null)
                {
                    var sr = new StreamReader(myStream);
                    return new List<string>(sr.ReadToEnd().Split('\n')).FindAll(a => a.StartsWith(folder));
                }
            }
            catch
            {
              
            }
            return null;
        }
    }
}
