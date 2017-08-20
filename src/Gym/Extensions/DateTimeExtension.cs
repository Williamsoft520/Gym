using System.Globalization;
using static System.DayOfWeek;

namespace System
{
    /// <summary>
    /// 表示为 <see cref="DateTime"/> 实例的扩展。
    /// </summary>
    public static class DateTimeExtension
    {
        #region DayOfWeekChineseString
        /// <summary>
        /// 获取当前时间对象所表示的日期是星期几的中文字符串。
        /// </summary>
        /// <example>
        /// <c>
        /// //假设为现在是 2016-8-8
        /// DateTime.Now.DayOfWeekChineseString(); //输出 星期一
        /// </c>
        /// </example>
        /// <param name="dateTime">指定日期</param>
        /// <param name="prefix">中文字符串前缀，可以是 周/星期。</param>
        /// <returns>星期几的中文字符串。</returns>
        public static string DayOfWeekChineseString(this DateTime dateTime, string prefix = "星期")
        {
            switch (dateTime.DayOfWeek)
            {
                case Monday:
                    return "{0}一".StringFormat(prefix);
                case Tuesday:
                    return "{0}二".StringFormat(prefix);
                case Wednesday:
                    return "{0}三".StringFormat(prefix);
                case Thursday:
                    return "{0}四".StringFormat(prefix);
                case Friday:
                    return "{0}五".StringFormat(prefix);
                case Saturday:
                    return "{0}六".StringFormat(prefix);
                default:
                    return "{0}日".StringFormat(prefix);
            }
        }

        #endregion

        #region ToChineseDateString
        /// <summary>
        /// 当前时间转换为中国日期字符串。
        /// </summary>
        /// <param name="dateTime">被扩展的实例。</param>
        /// <returns>中文的日期字符串</returns>
        public static string ToChineseDateString(this DateTime dateTime) => dateTime.ToString("yyyy年MM月dd日");

        /// <summary>
        /// 当前时间转换为符合中国的日期时间字符串。
        /// </summary>
        /// <param name="dateTime">被扩展的实例。</param>
        /// <returns>中文的日期字符串</returns>
        public static string ToChineseDateTimeString(this DateTime dateTime) => dateTime.ToString("yyyy年MM月dd日 HH:mm:ss");


        #endregion

        /// <summary>
        /// 获取当前时间在本月的第一天的时间实例。
        /// </summary>
        /// <param name="datetime">当前时间实例。</param>
        /// <returns>一个当前时间实例所在月份的第一天的完整时间实例，时间从0时0分0秒开始。</returns>
        public static DateTime GetFirstInMonth(this DateTime datetime)
            => new DateTime(datetime.Year, datetime.Month, 1, 0, 0, 0);

        /// <summary>
        /// 获取当前时间在本月的最后一天的时间实例。
        /// </summary>
        /// <param name="datetime">当前时间实例。</param>
        /// <returns>一个当前时间实例所在月份的最后一天的完整时间实例，时间截止到23时59分59秒。</returns>
        public static DateTime GetLastInMonth(this DateTime datetime)
        {
            var currentMonth = datetime.Month;
            var currentYear = datetime.Year;
            if (currentMonth == 12)
            {
                return new DateTime(currentYear, currentMonth, 31, 23, 59, 59);
            }

            return new DateTime(currentYear, currentMonth,
                    new DateTime(currentYear, currentMonth + 1, 1).AddSeconds(-1).Day, 23, 59, 59
                    );
        }
    }
}
