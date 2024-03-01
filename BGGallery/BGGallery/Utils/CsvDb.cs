using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BGGallery.Utils
{
    class CsvDb
    {
        private List<string> headers = new List<string>();
        private List<string[]> rows = new List<string[]>();

        public static CsvDb Create(string name)
        {
            int itemId = 0;
            if(int.TryParse(name, out var s))
            {
                itemId = s;
            }
            else
            {
                var findItem = BGBook.Instance.GetItemByNickname(name);
                if (findItem != null)
                    itemId = findItem.Id;
            }

            if (itemId == 0)
                return null;

            CsvDb db = new CsvDb();
            var fileStr = RtfModifier.ReadRtfPlainText(itemId);
            db.ParseCsvText(fileStr);

            return db;
        }

        private void ParseCsvText(string csvText)
        {
            using (StringReader reader = new StringReader(csvText))
            {
                // 读取头部
                if (reader.Peek() != -1)
                {
                    string headerLine = reader.ReadLine();
                    headers.AddRange(headerLine.Split('\t'));
                }

                // 读取行数据
                while (reader.Peek() != -1)
                {
                    string rowLine = reader.ReadLine();
                    string[] fields = rowLine.Split('\t');
                    rows.Add(fields);
                }
            }
        }

        public string GetValueByKey(string key, string header)
        {
            int keyIndex = headers.IndexOf(header);
            if (keyIndex == -1)
            {
                throw new ArgumentException($"Header '{header}' not found.");
            }

            foreach (string[] row in rows)
            {
                if (row.Length > keyIndex && row[0] == key)
                {
                    return row[keyIndex];
                }
            }

            throw new ArgumentException($"Key '{key}' not found.");
        }

        public List<string> GetValuesByHeader(string header)
        {
            int headerIndex = headers.IndexOf(header);
            if (headerIndex == -1)
            {
                throw new ArgumentException($"Header '{header}' not found.");
            }

            List<string> values = new List<string>();
            foreach (string[] row in rows)
            {
                if (row.Length > headerIndex)
                {
                    values.Add(row[headerIndex]);
                }
            }

            return values;
        }

        public List<string> GetValuesByHeader(string header, string orderByHeader, Func<string, string, int> stringComparer)
        {
            int headerIndex = headers.IndexOf(header);
            int orderByHeaderIndex = headers.IndexOf(orderByHeader);

            if (headerIndex == -1)
            {
                throw new ArgumentException($"Header '{header}' not found.");
            }

            if (orderByHeaderIndex == -1)
            {
                throw new ArgumentException($"Order by header '{orderByHeader}' not found.");
            }

            List<string[]> sortedRows = rows.OrderBy(row =>
            {
                if (row.Length > orderByHeaderIndex)
                {
                    return row[orderByHeaderIndex];
                }
                else
                {
                    return null; // Or handle the case where the value is not present in the row.
                }
            }, Comparer<string>.Create((x, y) => stringComparer(x, y))).ToList();

            List<string> values = sortedRows.Select(row =>
            {
                if (row.Length > headerIndex)
                {
                    return row[headerIndex];
                }
                else
                {
                    return null; // Or handle the case where the value is not present in the row.
                }
            }).ToList();

            return values;
        }
    }
}
