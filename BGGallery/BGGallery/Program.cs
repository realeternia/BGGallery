using BGGallery.Utils;
using System;
using System.Windows.Forms;

namespace BGGallery
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            HLog.Start("log", LogTargets.File);
            HLog.DisableDebugLog = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
