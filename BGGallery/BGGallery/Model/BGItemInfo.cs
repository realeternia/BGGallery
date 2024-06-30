using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BGGallery.Model
{
    public class BGItemInfo
    {
        public int Id { get; set; } //同文件存储路径
        public int Type { get; set; } //0 默认
        public string Title { get; set; }
        public string NickName { get; set; } //别名
        public string Tag { get; set; }
        public string Icon { get; set; }
        public string Parm { get; set; } //额外数据
        public int CatalogId { get; set; } 
        public int ColumnId { get; set; }
        public string BuyInfo { get; set; } //别名
        public int Star { get; set; }
        public int StarNewbie { get; set; }

        public List<string> Expansions { get; set; }

        private bool isDirty;

        public bool GetAndResetDirty()
        {
            var v = isDirty;
            isDirty = false;
            return v;
        }

        public void SetTag(string tag1)
        {
            if (tag1 == Tag)
                return;

            var oldTags = (Tag ?? "").Split(',');
            var newTags = (tag1 ?? "").Split(',');

            Tag = tag1;

            var newTagsNotInOld = newTags.Except(oldTags).ToArray();
            var oldTagsNotInNew = oldTags.Except(newTags).ToArray();

            foreach (var tagNotInOld in newTagsNotInOld)
                OnTagAdd(tagNotInOld);

            foreach (var tagNotInNew in oldTagsNotInNew)
                OnTagRemoved(tagNotInNew);
        }
        public string GetPath(int expId)
        {
            var fullPath = string.Format("{0}/{1}{2}.rtf", ENV.SaveDir, Id, expId > 0 ? "_" + expId : "");
            if (IsEncrypt())
                fullPath = fullPath.Replace(".rtf", ".rz");
            return fullPath;
        }

        public string GetCatalog() { return BGBook.Instance.CatalogInfos.Find(a => a.Id == CatalogId).Name; }
        public string GetColumn()
        {
            foreach (var catalog in BGBook.Instance.CatalogInfos)
            {
                var result = catalog.Columns.Find(a => a.Id == ColumnId);
                if (result != null)
                    return result.Title;
            }
            return null;
        }

        public void SetParm(string key, string v)
        {
            if (Parm == null)
                Parm = "";
            List<string> infos = new List<string>();
            var items = Parm.Split('|');
            foreach(var item in items)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                var isMatch = item.StartsWith(key);
                if (!isMatch)
                    infos.Add(item);
            }
            if (v != "0")
                infos.Add(string.Format("{0}:{1}", key, v));
            Parm = string.Join("|", infos);
        }

        public List<Tuple<string, string>> GetParmList()
        {
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();
            if (string.IsNullOrEmpty(Parm))
                return results;

            var items = Parm.Split('|');
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                var itInfo = item.Split(':');
                results.Add(new Tuple<string, string>(itInfo[0], itInfo[1]));
            }
            return results;
        }

        public string GetParm(string sname)
        {
            if (string.IsNullOrEmpty(Parm))
                return "";

            var items = Parm.Split('|');
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                
                var itInfo = item.Split(':');
                if (itInfo[0] == sname)
                    return itInfo[1];
            }
            return "";
        }

        public DateTime GetCreateTime()
        {
            return new FileInfo(string.Format("{0}/{1}.{2}", ENV.SaveDir, Id, IsEncrypt() ? "rz" : "rtf")).CreationTime;
        }
        public DateTime GetModifyTime()
        {
            return new FileInfo(string.Format("{0}/{1}.{2}", ENV.SaveDir, Id, IsEncrypt() ? "rz" : "rtf")).LastWriteTime;
        }
        public long GetFileLength()
        {
            var path = string.Format("{0}/{1}.{2}", ENV.SaveDir, Id, IsEncrypt() ? "rz" : "rtf");
            if (!File.Exists(path))
                return 0;
            return new FileInfo(path).Length;
        }
        public int GetImageCount()
        {
            if (!Directory.Exists(ENV.ImgDir + Id))
                return 0;
            return Directory.GetFiles(ENV.ImgDir + Id).Length;
        }

        public bool IsEncrypt()
        {
            return HasTag("加密");
        }

        public void AddTag(string tagName)
        {
            if (Tag != null && Tag.Contains(tagName))
                return;

            OnTagAdd(tagName);
            if (Tag == null || Tag.Length == 0)
                Tag = tagName;
            else
                Tag += "," + tagName;
        }

        public bool HasTag(string s)
        {
            if (Tag == null)
                return false;
            return Tag.Contains(s);
        }
        private void OnTagAdd(string tag)
        {
            if (tag == "加密")
            {
                isDirty = true;
                File.Delete(string.Format("{0}/{1}.rtf", ENV.SaveDir, Id));
            }
        }

        private void OnTagRemoved(string tag)
        {
            if (tag == "加密")
            {
                isDirty = true;
                File.Delete(string.Format("{0}/{1}.rz", ENV.SaveDir, Id));
            }
        }
    }
}
