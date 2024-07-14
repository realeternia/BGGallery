using System;
using System.Collections.Generic;

namespace BGGallery.Utils
{
    class TagsInfoManager
    {
        public static HashSet<string> Tags = new HashSet<string>();

        public static void Init()
        {
            foreach(var memoItem in BGGallery.BGBook.Instance.Items)
            {
                if (string.IsNullOrWhiteSpace(memoItem.TagInfo))
                    continue;
                var tagsInfo = memoItem.TagInfo.Split(',');
                foreach (var tag in tagsInfo)
                    Tags.Add(tag);
            }
        }

        public static void Add(string tag)
        {
            Tags.Add(tag);
        }
    }
}
