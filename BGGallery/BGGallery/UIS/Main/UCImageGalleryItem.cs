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
        private Point parentPos;

        public UCImageGalleryItem()
        {
            InitializeComponent();

            DoubleBuffered = true;
            rjDropdownMenuRow.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuRow.MenuItemTextColor = Color.White;
            rjDropdownMenuRow.MenuItemHeight = 25;
        }

        public void Init(int id, string pat, Point pPoint)
        {
            itemId = id;
            path = pat;
            parentPos = pPoint;

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
            {
                PanelManager.Instance.ShowImageViewer(path);
            }
            else
            {
                rjDropdownMenuRow.Show(this, Width, 0);

            }
        }

        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Format("file://img/{0}/{1}", itemId, new FileInfo(path).Name));
        }

        private void toolStripMenuItemRename_Click(object sender, EventArgs e)
        {
            Point absoluteLocation = this.PointToScreen(new Point(0, 0));

            var inputBox = new InputTextBox();
            inputBox.OnCustomTextChanged = OnRename;

            PanelManager.Instance.ShowBlackPanel(inputBox, absoluteLocation.X, absoluteLocation.Y, 1);
            inputBox.Focus();
        }

        private void OnRename(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj))
                return;
            
            // 获取原始文件的目录  
            string directory = Path.GetDirectoryName(path);
            // 假设你知道文件的原始扩展名（例如 ".txt"），或者你可以从原始路径中提取它  
            string originalExtension = Path.GetExtension(path); // 这将获取 ".txt"  

            // 构建新的完整路径  
            // 如果 newNameWithoutExtension 已经包含了扩展名，你可以直接使用它并跳过下面的步骤  
            string newFileName = obj + originalExtension; // 例如 "newfile.txt"  
            string newPath = Path.Combine(directory, newFileName); // 例如 "C:\\path\\to\\newfile.txt"  

            File.Move(path, newPath);
            path = newPath;

        }
    }
}
