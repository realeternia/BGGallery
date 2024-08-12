using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCMemChart : UserControl
    {
        private string chartName;
        public string[] XData;
        public float[] YData;

        private int barWidth;

        public UCMemChart()
        {
            InitializeComponent();
        }

        public void InitBars(string name, string[] xData , float[] yData)
        {
            chartName = name;
            XData = xData;
            YData = yData;

            barWidth = this.Width / (XData.Length * 5 / 4);  // 减去一些间距  
            if (barWidth > 30)
                barWidth = 30;
            if (barWidth < 12)
                barWidth = 12;
            int barSpacing = barWidth / 4;

            doubleBufferedPanel1.Width = (barWidth + barSpacing) * xData.Length + 30;
        }

        private void UCMemChart_Paint(object sender, PaintEventArgs e)
        {
            if (XData == null || YData == null || XData.Length != YData.Length)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawString(chartName, this.Font, Brushes.White, new PointF(5, 5));

            int barSpacing = barWidth / 4;
            int xStart = 20 + barSpacing;
            int maxY = (int)YData.Max();
            var heightTotal = Height - 20 - 20 - 20;

            for (int i = 0; i < XData.Length; i++)
            {
                int barHeight = (int)((YData[i] / (float)maxY) * (heightTotal - 2 * barSpacing)); // 减去顶部和底部的间距  
                Rectangle barRect = new Rectangle(xStart + i * (barWidth + barSpacing), heightTotal - barHeight - barSpacing + 20, barWidth, barHeight);

                g.FillRectangle(Brushes.Blue, barRect);

                // 绘制X轴标签（可选）  
                string label = XData[i];
                SizeF labelSize = g.MeasureString(label, this.Font);
                g.DrawString(label, this.Font, Brushes.White, new PointF(barRect.Left + (barRect.Width - labelSize.Width) / 2, heightTotal + 20 - barSpacing / 2 + 3));

                label = YData[i].ToString();
                labelSize = g.MeasureString(label, this.Font);
                g.DrawString(label, this.Font, Brushes.LawnGreen, new PointF(barRect.Left + (barRect.Width - labelSize.Width) / 2, barRect.Top - 20));
            }
        }
    }
}
