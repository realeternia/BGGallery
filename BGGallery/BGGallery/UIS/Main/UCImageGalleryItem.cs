using BGGallery.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BGGallery.UIS.Main
{
    public partial class UCImageGalleryItem : UserControl
    {
        private int itemId;
        private string path;
        private float scale;
        public UCImageGalleryItem()
        {
            InitializeComponent();

            DoubleBuffered = true;
        }

        public void Init(int id, string pat)
        {
            itemId = id;
            path = pat;

            var img = ImageBook.Instance.Load(path);
            if (img == null)
                return;

            var clientSize = new Size(Width, Height - 30);
            var imgSize = img.Size;

            // 计算缩放比例
            scale = Math.Min((float)clientSize.Width / imgSize.Width, (float)clientSize.Height / imgSize.Height);

            // 计算绘制的矩形
            int drawWidth = (int)(imgSize.Width * scale);

            Width = drawWidth + 10; //左右5的间距
        }

        private void UCImageGalleryItem_Paint(object sender, PaintEventArgs e)
        {
            var img = ImageBook.Instance.Load(path);
            if (img == null)
                return;

            var clientSize = new Size(Width, Height - 25);
            var imgSize = img.Size;

            // 计算绘制的矩形
            int drawWidth = (int)(imgSize.Width * scale);
            int drawHeight = (int)(imgSize.Height * scale);
            int drawX = (clientSize.Width - drawWidth) / 2;
            int drawY = (clientSize.Height - drawHeight) / 2;

            e.Graphics.DrawImage(img, drawX, drawY + 5, drawWidth, drawHeight);

            if(isMouseIn)
            {
                using (var b = new SolidBrush(Color.FromArgb(50, Color.White)))
                    e.Graphics.FillRectangle(b, drawX, drawY + 5, drawWidth, drawHeight);
            }

            var fInfo = new FileInfo(path);
            var fileName = fInfo.Name.Replace(".jpg", "");

            if (fileName.StartsWith("IMG"))
            {
                fileName = fileName.Replace("IMG_", "");
                DateTime? takenDate = GetImageTakenDate(path);
                if (takenDate != null)
                {
                    e.Graphics.DrawString(takenDate.Value.ToString("yyyy年MM月dd日"), Font, Brushes.DimGray, 5 + 5 + 1, 5 + 5 + 1);
                    e.Graphics.DrawString(takenDate.Value.ToString("yyyy年MM月dd日"), Font, Brushes.White, 5 + 5, 5 + 5);
                }
            }

            var wd = e.Graphics.MeasureString(fileName, Font).Width;
            e.Graphics.DrawString(fileName, Font, Brushes.White, (Width - wd) / 2, Height - 22);
        }

        static DateTime? GetImageTakenDate(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            {
                PropertyItem propItem = image.GetPropertyItem(0x9003); // 0x9003 是拍摄日期的标识符

                if (propItem != null)
                {
                    // 解码拍摄日期的字节数组
                    string dateTaken = Encoding.UTF8.GetString(propItem.Value).Trim('\0');

                    // 将日期字符串转换为 DateTime
                    if (DateTime.TryParseExact(dateTaken, "yyyy:MM:dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                    {
                        return result;
                    }
                }

                return null;
            }
        }

        private bool isMouseIn;
        private void UCImageGalleryItem_MouseEnter(object sender, EventArgs e)
        {
            isMouseIn = true;
            Invalidate();
        }

        private void UCImageGalleryItem_MouseLeave(object sender, EventArgs e)
        {
            isMouseIn = false;
            Invalidate();
        }

        private void UCImageGalleryItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                PanelManager.Instance.ShowImageViewer(path);
            else
                Clipboard.SetText(string.Format("file://img/{0}/{1}", itemId, new FileInfo(path).Name));
        }
    }
}
