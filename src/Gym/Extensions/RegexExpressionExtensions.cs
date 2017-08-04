namespace System.Text.RegularExpressions
{
    /// <summary>
    /// 表示提供常用的正则表达式验证的扩展。
    /// </summary>
    public static class RegexExpressionExtensions
    {
        /// <summary>
        /// 表示验证是否符合“Email 地址”的字符串正则表达式。
        /// </summary>
        public const string EMAIL_PATTERN = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        /// <summary>
        /// 表示验证是否符合“URL 地址”的字符串正则表达式。
        /// </summary>
        public const string URL_PATTERN = @"^((https|http|ftp|rtsp|mms)?:\/\/)[^\s]+";

        /// <summary>
        /// 表示验证是否符合“中文字符”的字符串正则表达式。
        /// </summary>
        public const string CHINESE_PATTERN = @"[\u4e00-\u9fa5]";

        /// <summary>
        /// 表示验证是否符合“国内手机号码”的字符串正则表达式。
        /// </summary>
        public const string CHINA_MOBILE_PATTERN = @"^0?(13|14|15|18)[0-9]{9}$";

        /// <summary>
        /// 表示验证是否符合“国内座机电话”的字符串正则表达式。
        /// </summary>
        public const string CHINA_PHONE_PATTERN = @"^\d{3}-\d{8}|\d{4}-\{7,8}$";

        /// <summary>
        /// 表示验证是否符合“国内邮政编码”的字符串正则表达式。
        /// </summary>
        public const string CHINA_POST_CODE_PATTERN = @"^[1-9]\d{5}(?!\d)$";

        /// <summary>
        /// 表示验证是否符合“中国居民身份证号码”的字符串正则表达式。
        /// </summary>
        public const string CHINESE_ID_NUMBER_PATTERN = @"^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$";

        /// <summary>
        /// 判断当前字符串是否匹配 <see cref="EMAIL_PATTERN"/> 表达式。
        /// </summary>
        /// <param name="value">输入的字符串。</param>
        /// <returns>如果成功匹配表达式，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsMatchEmail(this string value) => value.IsMatch(EMAIL_PATTERN);

        /// <summary>
        /// 判断当前字符串是否匹配 <see cref="URL_PATTERN"/> 表达式。
        /// </summary>
        /// <param name="value">输入的字符串。</param>
        /// <returns>如果成功匹配表达式，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsMatchUrl(this string value) => value.IsMatch(URL_PATTERN);

        /// <summary>
        /// 判断当前字符串是否匹配 <see cref="CHINESE_PATTERN"/> 表达式。
        /// </summary>
        /// <param name="value">输入的字符串。</param>
        /// <returns>如果成功匹配表达式，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsMatchChinese(this string value) => value.IsMatch(CHINESE_PATTERN);

        /// <summary>
        /// 判断当前字符串是否匹配 <see cref="CHINA_MOBILE_PATTERN"/> 表达式。
        /// </summary>
        /// <param name="value">输入的字符串。</param>
        /// <returns>如果成功匹配表达式，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsMatchChinaMobile(this string value) => value.IsMatch(CHINA_MOBILE_PATTERN);

        /// <summary>
        /// 判断当前字符串是否匹配 <see cref="CHINA_PHONE_PATTERN"/> 表达式。
        /// </summary>
        /// <param name="value">输入的字符串。</param>
        /// <returns>如果成功匹配表达式，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsMatchChinaPhone(this string value) => value.IsMatch(CHINA_PHONE_PATTERN);

        /// <summary>
        /// 判断当前字符串是否匹配 <see cref="CHINA_POST_CODE_PATTERN"/> 表达式。
        /// </summary>
        /// <param name="value">输入的字符串。</param>
        /// <returns>如果成功匹配表达式，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsMatchChinaPostCode(this string value) => value.IsMatch(CHINA_POST_CODE_PATTERN);

        /// <summary>
        /// 判断当前字符串是否匹配 <see cref="CHINESE_ID_NUMBER_PATTERN"/> 表达式。
        /// </summary>
        /// <param name="value">输入的字符串。</param>
        /// <returns>如果成功匹配表达式，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsMatchChineseIdNumber(this string value) => value.IsMatch(CHINESE_ID_NUMBER_PATTERN);
    }
}
