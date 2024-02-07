using System.Windows.Forms;

namespace BGGallery.UIS
{
    public class DoubleBufferedListView : ListView
    {
        public DoubleBufferedListView()
        {
            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            //  this.DoubleBuffered = true;

            ColumnClick += DoubleBufferedListView_ColumnClick;
        }

        private void DoubleBufferedListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (ListViewItemSorter == null || ListViewItemSorter.GetType() != typeof(ListViewColumnSorter))
                ListViewItemSorter = new ListViewColumnSorter();

            ListView lv = sender as ListView;
            // 检查点击的列是不是现在的排序列.
            if (e.Column == (lv.ListViewItemSorter as ListViewColumnSorter).SortColumn)
            {
                // 重新设置此列的排序方法.
                if ((lv.ListViewItemSorter as ListViewColumnSorter).Order == SortOrder.Ascending)
                {
                    (lv.ListViewItemSorter as ListViewColumnSorter).Order = SortOrder.Descending;
                }
                else
                {
                    (lv.ListViewItemSorter as ListViewColumnSorter).Order = SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                (lv.ListViewItemSorter as ListViewColumnSorter).SortColumn = e.Column;
                (lv.ListViewItemSorter as ListViewColumnSorter).Order = SortOrder.Ascending;
            }

            // 用新的排序方法对ListView排序
            ((ListView)sender).Sort();
        }

        public void RecoverOrder()
        {
            if (ListViewItemSorter == null || ListViewItemSorter.GetType() != typeof(ListViewTagSorter))
            {
                ListViewItemSorter = new ListViewTagSorter();
            }
            Sort();
        }
    }

    /// <summary>
    /// 继承自IComparer
    /// </summary>
    public class ListViewColumnSorter : System.Collections.IComparer
    {
        /// <summary>
        /// 指定按照哪个列排序
        /// </summary>
        private int ColumnToSort;

        /// <summary>
        /// 指定排序的方式
        /// </summary>
        private SortOrder OrderOfSort;

        /// <summary>
        /// 声明CaseInsensitiveComparer类对象
        /// </summary>
        private System.Collections.CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ListViewColumnSorter()
        {
            // 默认按第一列排序
            ColumnToSort = 0;
            // 排序方式为不排序
            OrderOfSort = SortOrder.None;
            // 初始化CaseInsensitiveComparer类对象
            ObjectCompare = new System.Collections.CaseInsensitiveComparer();
        }

        /// <summary>
        /// 重写IComparer接口.
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
            // 将比较对象转换为ListViewItem对象
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            string xText = listviewX.SubItems[ColumnToSort].Text;
            string yText = listviewY.SubItems[ColumnToSort].Text;
            int xInt, yInt;
            if (int.TryParse(xText, out xInt) && int.TryParse(yText, out yInt)) //是否全为数字
            {
                //比较数字
                compareResult = CompareInt(xInt, yInt);
            }
            else
            {
                //比较对象
                compareResult = ObjectCompare.Compare(xText, yText);
            }

            // 根据上面的比较结果返回正确的比较结果
            if (OrderOfSort == SortOrder.Ascending)
            {
                // 因为是正序排序，所以直接返回结果
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // 如果是反序排序，所以要取负值再返回
                return -compareResult;
            }
            else
            {
                // 如果相等返回0
                return 0;
            }
        }

        /// <summary>
        /// 比较两个数字的大小
        /// </summary>
        /// <param name="ipx">要比较的第一个对象</param>
        /// <param name="ipy">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        private int CompareInt(int x, int y)
        {
            if (x > y)
            {
                return 1;
            }
            else if (x < y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取或设置按照哪一列排序.
        /// </summary>
        public int SortColumn
        {
            set { ColumnToSort = value; }
            get { return ColumnToSort; }
        }

        /// <summary>
        /// 获取或设置排序方式.
        /// </summary>
        public SortOrder Order
        {
            set { OrderOfSort = value; }
            get { return OrderOfSort; }
        }
    }

    public class ListViewTagSorter : System.Collections.IComparer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ListViewTagSorter()
        {

        }

        /// <summary>
        /// 重写IComparer接口.
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        public int Compare(object x, object y)
        {
            ListViewItem listviewX, listviewY;
            // 将比较对象转换为ListViewItem对象
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            var xText = listviewX.Tag.ToString();
            var yText = listviewY.Tag.ToString();
            int xInt, yInt;
            if (int.TryParse(xText, out xInt) && int.TryParse(yText, out yInt)) //是否全为数字
            {
                //比较数字
                return xInt - yInt;
            }
            else
            {
                //比较对象
                return xText.CompareTo(yText);
            }
        }
    }
}
