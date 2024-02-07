using BGGallery.Utils;
using System.Collections.Generic;
using System.Drawing;

namespace BGGallery.Model
{
    class BGCatalogInfo
    {
        //全局唯一id
        public int Id { get; set; }
        public string Name { get; set; }
        public int Offset { get; set; }

        private static Color[] ColorArray;

        public List<BGColumnInfo> Columns = new List<BGColumnInfo>();

        static BGCatalogInfo()
        {
            ColorArray = new Color[ColorTool.DarkColorTable.Count];
            ColorTool.DarkColorTable.Values.CopyTo(ColorArray, 0);
        }

        public int AddColumn(string title)
        {
            BGBook.Instance.ColumnIndex++;
            Offset++;
            var cInfo = new BGColumnInfo();
            cInfo.Id = BGBook.Instance.ColumnIndex;
            cInfo.Title = title;
            cInfo.BgColor = ColorArray[Offset % ColorArray.Length].ToArgb();
            Columns.Add(cInfo);

            return cInfo.Id;
        }

        public BGColumnInfo GetColumn(int id)
        {
            return Columns.Find(a => a.Id == id);
        }

        public BGColumnInfo RemoveColumn(int id)
        {
            var itm = Columns.Find(a => a.Id == id);
            Columns.Remove(itm);
            return itm;
        }
    }
}
