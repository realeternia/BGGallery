using System;

namespace BGGallery.Utils
{
    public class TimeTool
    {
        static DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        public static DateTime UnixTimeToDateTime(uint sec)
        {
            return start.AddSeconds(sec);
        }

        public static uint DateTimeToUnixTime(DateTime time)
        {
            return (uint)(time - start).TotalSeconds;
        }

        public static int GetDayDiffer(DateTime time1, DateTime time2)
        {
            var ckTime1 = new DateTime(time1.Year, time1.Month, time1.Day);
            var ckTime2 = new DateTime(time2.Year, time2.Month, time2.Day);
            return (int)(ckTime1 - ckTime2).TotalDays;
        }

        public static int GetWeek(DateTime dt)
        {
            DateTime time = Convert.ToDateTime(dt.ToString("yyyy") + "-01-01");
            TimeSpan ts = dt - time;
            int iii = (int)time.DayOfWeek;
            int day = int.Parse(ts.TotalDays.ToString("F0"));
            if (iii == 0)
            {
                day--;
            }
            else
            {
                day = day - (7 - iii) - 1;
            }

            int week = (day + 7) / 7 + 1;
            return week;
        }

        public static string FormatTime(DateTime time)
        {
            return time.ToString("yyyy/MM/dd HH时");
        }

        public static DateTime ParseTime(string str)
        {
            var timeInfos = str.Replace('/', ' ').Replace("时", "").Split(' ');
            var nowDate = new DateTime(int.Parse(timeInfos[0]), int.Parse(timeInfos[1]), int.Parse(timeInfos[2]), int.Parse(timeInfos[3]), 0, 0);

            return nowDate;
        }

        public static string GetTimeAgo(DateTime inputDateTime)
        {
            TimeSpan timeDifference = DateTime.Now - inputDateTime;

            if (timeDifference.TotalHours < 24)
            {
                return "一天内";
            }
            else if (timeDifference.TotalDays < 7)
            {
                return $"{(int)timeDifference.TotalDays}天前";
            }
            else if (timeDifference.TotalDays < 30)
            {
                int weeks = (int)(timeDifference.TotalDays / 7);
                return $"{weeks}周前";
            }
            else if (timeDifference.TotalDays < 365)
            {
                int months = (int)(timeDifference.TotalDays / 30);
                return $"{months}月前";
            }
            else
            {
                return "一年内";
            }
        }
    }
}