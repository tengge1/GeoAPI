using System;

// Ref: http://www.yortondotnet.com/2009/11/tryparse-for-compact-framework.html

namespace GeoAPI
{
    /// <summary>
    /// 提供方法来解析简单的值类型，而不会抛出格式异常。
    /// </summary>
    internal static class ValueParser
    {
        /// <summary>
        /// 尝试将指定样式和文化特定格式的数字的字符串表示形式转换为等效的双精度浮点数。
        /// </summary>
        /// <param name="s">要尝试解析的字符串。</param>
        /// <param name="style">
        /// 表示<paramref name =“s”/>的允许格式的<see cref =“System.Globalization.NumberStyles”/>值的按位组合。
        /// </param>
        /// <param name="provider">
        /// 一个<see cref =“System.IFormatProvider”/>提供有关<paramref name =“s”/>的文化特定格式化信息。
        /// </param>
        /// <param name="result">解析字符串的结果，如果解析失败，则返回0。</param>
        /// <returns>一个布尔值，指示解析是否成功。</returns>
        /// <remarks>如果解析失败，则返回结果参数中的0。</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s")]
        public static bool TryParse(string s, System.Globalization.NumberStyles style, IFormatProvider provider, out double result)
        {
            bool retVal = false;
            retVal = double.TryParse(s, style, provider, out result);
            try
            {
                result = double.Parse(s, style, provider);
                retVal = true;
            }
            catch (FormatException) { result = 0; }
            catch (InvalidCastException) { result = 0; }

            return retVal;
        }
    }
}
