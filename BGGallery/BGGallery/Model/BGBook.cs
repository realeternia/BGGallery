using BGGallery.Model;
using System.Collections.Generic;

namespace BGGallery
{
    //数据存储类
    class BGBook
    {
        public static BGBook Instance = new BGBook();

        public List<BGCatalogInfo> CatalogInfos = new List<BGCatalogInfo>();

        public List<BGItemInfo> Items = new List<BGItemInfo>();

        public int CatalogIndex = 1;
        public int ColumnIndex = 100001;
        public int ItemIndex = 200001;
        public BGBookCfg Cfg = new BGBookCfg();

        public BGCatalogInfo AddCatalog()
        {
            var newCatalog = new BGCatalogInfo { Id = CatalogIndex, Name = "" };
            CatalogIndex++;
            newCatalog.AddColumn("");
            CatalogInfos.Add(newCatalog);

            return newCatalog;
        }

        public BGCatalogInfo DeleteCatalog(int id)
        {
            var target = CatalogInfos.Find(a => a.Id == id);
            if (target == null)
                return null;
            CatalogInfos.Remove(target);

            return target;
        }

        public BGCatalogInfo GetCatalog(int id)
        {
            return CatalogInfos.Find(i => i.Id == id);
        }

        public List<BGItemInfo> GetItemsByCatalog(int catalogId)
        {
            var results = new List<BGItemInfo>();
            foreach (var item in Items)
                if (item.CatalogId == catalogId)
                    results.Add(item);

            return results;
        }
        public List<BGItemInfo> GetItemsByColumn(int colId)
        {
            var results = new List<BGItemInfo>();
            foreach (var item in Items)
                if (item.ColumnId == colId)
                    results.Add(item);

            return results;
        }

        public BGItemInfo GetItemByNickname(string nkName)
        {
            foreach (var item in Items)
            {
                if (item.NickName == nkName)
                {
                    return item;
                }
            }
            return null;
        }

        public List<BGItemInfo> FindItemInfosByTag(string tag, string revTag = "")
        {
            List<BGItemInfo> rts = new List<BGItemInfo>();
            foreach (var item in Items)
            {
                if (item.HasTag(tag) && (string.IsNullOrEmpty(revTag) || !item.HasTag(revTag)))
                {
                    rts.Add(item);
                }
            }
            return rts;
        }
        public void MoveItem(BGItemInfo itm, int checkId, bool afterNode)
        {
            Items.Remove(itm);

            int off = 0;
            foreach (var pickItem in Items)
            {
                if (pickItem.Id == checkId)
                    break;
                off++;
            }

            if (afterNode)
                off++;

            if (off < Items.Count)
                Items.Insert(off, itm);
            else
                Items.Add(itm);
        }
        public BGItemInfo AddItem(string title, int catalog, int column)
        {
            Instance.ItemIndex++;
            var itmInfo = new BGItemInfo();
            itmInfo.Id = Instance.ItemIndex;
            itmInfo.Title = title;
            itmInfo.CatalogId = catalog;
            itmInfo.ColumnId = column;
            Items.Add(itmInfo);

            return itmInfo;
        }
        public BGItemInfo GetItem(int id)
        {
            return Items.Find(a => a.Id == id);
        }

        public BGItemInfo RemoveItem(int id)
        {
            var itm = Items.Find(a => a.Id == id);
            Items.Remove(itm);
            return itm;
        }

    }
}
