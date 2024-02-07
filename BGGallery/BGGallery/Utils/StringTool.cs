namespace BGGallery.Utils
{
    class StringTool
    {
        public static int CountSubstring(string input, string substring)
        {
            int count = 0;
            int index = input.IndexOf(substring);

            while (index != -1)
            {
                count++;
                index = input.IndexOf(substring, index + substring.Length);
            }

            return count;
        }
    }
}
