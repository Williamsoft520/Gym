using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gym.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            

            #region 判断字符串是否为空
            Console.WriteLine("".IsNullOrEmpty());
            Console.WriteLine(" ".IsNullOrWhiteSpace());
            #endregion

            #region 判断字符串是否符合指定正则表达式
            Console.WriteLine("123".IsMatch("^\\d+$"));
            #endregion

            #region 格式化字符串
            Console.WriteLine("{0} + {1} = {2}".StringFormat(1,2,1+2));
            Console.WriteLine("{0:c}".StringFormat(System.Globalization.CultureInfo.CurrentCulture, 10000_0000));
            #endregion

            #region base64string 互转
            Console.WriteLine("administrator".ToBase64String());
            Console.WriteLine("admin".ToBase64String().FromBase64String());
            #endregion

            #region 字节数组互转
            "admin".ToBytes()
                .FromBytes();

            #endregion

            #region 集合循环
            "1,2,3,4,5".Split(',').ForEach(item => Console.WriteLine(item));
            #endregion

            #region Substring 然后追加
            Console.WriteLine("aaaaaaaaaaaaa".Substring(0,5,"..."));
            #endregion

            #region 通用类型转换
            Console.WriteLine("1".To<int>());            
            Console.WriteLine("1234.3".To<decimal>());
            Console.WriteLine("a".To<int>(100));
            #endregion

            #region 常用正则表达式 using System.Text.RegularExptessions
            
            Console.WriteLine("15810657789".IsMatchChinaMobile());
            Console.WriteLine("http://www.baidu.com".IsMatchUrl());
            Console.WriteLine("abcd@ab.com".IsMatchEmail());
            Console.WriteLine("10116119900101154x".IsMatchChineseIdNumber());
            Console.WriteLine("100010".IsMatchChinaPostCode());
            #endregion

            #region 日期常用操作
            DateTime now = DateTime.Now;
            Console.WriteLine(now.DayOfWeekChineseString());
            Console.WriteLine(now.GetFirstInMonth());
            Console.WriteLine(now.GetLastInMonth());
            Console.WriteLine(now.ToChineseDateString());
            Console.WriteLine(now.ToChineseDateTimeString());
            #endregion

            #region 枚举操作
            Console.WriteLine(TestEnum.Test1.GetDescription());
            Console.WriteLine(TestEnum.Test2.GetDescription());
            Console.WriteLine(typeof(TestEnum).GetEnumItems().Select((k,v)=>$"{k.Key}:{k.Value}").Join("|"));
            #endregion

            #region Substring
            Console.WriteLine("abcdefg".Substring(0,"..."));
            Console.WriteLine("abcdefghijklmn".Substring(0,10,"..."));
            Console.WriteLine("abcdefghijklmn".Substring(0, 30, "..."));
            #endregion
        }
    }

    enum TestEnum
    {
        [Description("这个是枚举 Test 1")]
        Test1=1,
        Test2=2,
        Test3=3
    }
}