using System.Security.Cryptography;
using System.Text;

namespace System.Security
{
    /// <summary>
    /// 表示对安全性的扩展。
    /// </summary>
    public static class SecurityExtension
    {

        #region Cryptography
        /// <summary>
        /// 为当前字符串执行 MD5 的密码运算。
        /// </summary>
        /// <param name="value">要进行运算的字符串。</param>
        /// <returns>符合 MD5 哈希运算方式的字符串。</returns>
        /// <param name="encoding">字符的编码格式，若未 null ，则使用 UTF-8 编码规范。</param>
        /// <exception cref="ArgumentNullException">字符串不能为 null 。</exception>
        public static string CryptoForMD5(this string value, Encoding encoding = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return value.Cryptography(MD5.Create(), encoding);
        }

        /// <summary>
        /// 为当前字符串执行 SHA256 的密码运算。
        /// </summary>
        /// <param name="value">要进行运算的字符串。</param>
        /// <returns>符合 SHA256 哈希运算方式的字符串。</returns>
        /// <param name="encoding">字符的编码格式，若未 null ，则使用 UTF-8 编码规范。</param>
        /// <exception cref="ArgumentNullException">字符串不能为 null 。</exception>
        public static string CryptoForSHA256(this string value, Encoding encoding = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return value.Cryptography(SHA512.Create(), encoding);
        }

        /// <summary>
        /// 为当前字符串执行 SHA1 的密码运算。
        /// </summary>
        /// <param name="value">要进行运算的字符串。</param>
        /// <param name="encoding">字符的编码格式，若未 null ，则使用 UTF-8 编码规范。</param>
        /// <returns>符合 SHA1 哈希运算方式的字符串。</returns>
        /// <exception cref="ArgumentNullException">字符串不能为 null 。</exception>
        public static string CryptoForSHA1(this string value, Encoding encoding = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
                return value.Cryptography(SHA256.Create(), encoding);
        }

        /// <summary>
        /// 使用指定的 <see cref="HashAlgorithm"/> 算法提供者对当前字符串进行密码运算。
        /// </summary>
        /// <param name="value">字符串对象。</param>
        /// <param name="hashAlgorithm">一种 Hash 算法的 <see cref="HashAlgorithm"/> 实例。</param>
        /// <param name="encoding">字符的编码格式，若未 null ，则使用 UTF-8 编码规范。</param>
        /// <returns>符合指定 <see cref="HashAlgorithm"/> 算法进行哈希运算后的字符串。</returns>
        public static string Cryptography(this string value, HashAlgorithm hashAlgorithm, Encoding encoding = null)
        {
            using (hashAlgorithm)
            {
                var buffs = value.ToBytes(encoding);
                return BitConverter.ToString(hashAlgorithm.ComputeHash(buffs)).Replace("-", string.Empty);
            }
        }
        #endregion
    }
}
