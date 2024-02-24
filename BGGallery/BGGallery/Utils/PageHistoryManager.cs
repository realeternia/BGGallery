using System;
using System.Collections.Generic;

namespace BGGallery.Utils
{
    class PageHistoryManager
    {
        public static PageHistoryManager Instance = new PageHistoryManager();

        private List<int> pageList = new List<int>();
        private int nowPos;

        public void Record(int pageId)
        {
            pageList.Add(pageId);
            if (pageList.Count > 10)
                pageList.RemoveAt(0);
            nowPos = pageList.Count - 1;
        }

        public int FindFormer()
        {
            if (nowPos > 0)
                nowPos--;
            if (nowPos < pageList.Count)
                return pageList[nowPos];
            return 0;
        }

        public int FindNext()
        {
            if (nowPos < pageList.Count - 1)
                nowPos++;
            if (nowPos >= 0)
                return pageList[nowPos];
            return 0;
        }
    }
}
