using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGGallery.Utils
{
    class BGDB
    {
        public static BGDB Instance = new BGDB();

        public CsvDb DB { get; private set; }

        public BGDB()
        {
            DB = CsvDb.Create("rolelist");
        }
    }
}
