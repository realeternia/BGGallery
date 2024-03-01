namespace BGGallery.Utils
{
    class CsvDbHouse
    {
        public static CsvDbHouse Instance = new CsvDbHouse();

        public CsvDb DB { get; private set; }

        public CsvDbHouse()
        {
            DB = CsvDb.Create("rolelist");
        }
    }
}
