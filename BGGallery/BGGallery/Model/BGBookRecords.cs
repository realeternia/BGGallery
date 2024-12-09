using System.Collections.Generic;

namespace BGGallery.Model
{
    internal class BGBookRecords
    {
        internal class PlayRecords
        {
            public int Id { get; set; }
            public int GameId { get; set; }
            public uint BeginTime { get; set; }
            public string LastTime { get; set; }
            public string Details { get; set; }
        }

        public List<PlayRecords> Records = new List<PlayRecords>();
        public int MaxId = 1001;

        public int GetNextId()
        {
            MaxId++;
            return MaxId;
        }
    }
}
