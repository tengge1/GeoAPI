using System;
using ApplicationException = System.Exception;

namespace GeoAPI.IO
{
    /// <summary>
    /// 当解析问题发生时，由<c> WKTReader </ c>抛出。
    /// </summary>
    public class ParseException : ApplicationException
    {
        /// <summary>
        /// 使用给定的详细消息创建一个<c> ParseException </ c>。
        /// </summary>
        /// <param name="message">这个<c> ParseException </ c>的描述。</param>
        public ParseException(String message) : base(message) { }

        /// <summary>
        /// 用<c> e </ c>的详细信息创建一个<c> ParseException </ c>。
        /// </summary>
        /// <param name="e">当<c> WKTReader </ c>正在解析一个众所周知的文本字符串时发生的异常。</param>
        public ParseException(Exception e) : this(e.ToString(), e) { }

        /// <summary>
        /// 使用<paramref name =“innerException”/>的详细消息创建一个<c> ParseException </ c>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException">内部异常</param>
        public ParseException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
