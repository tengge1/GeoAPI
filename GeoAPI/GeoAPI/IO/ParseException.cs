using System;
#if HAS_SYSTEM_APPLICATIONEXCEPTION
using ApplicationException = System.ApplicationException;
#else
using ApplicationException = System.Exception;
#endif

namespace GeoAPI.IO
{
    /// <summary>
    /// ���������ⷢ��ʱ����<c> WKTReader </ c>�׳���
    /// </summary>
    public class ParseException : ApplicationException
    {
        /// <summary>
        /// ʹ�ø�������ϸ��Ϣ����һ��<c> ParseException </ c>��
        /// </summary>
        /// <param name="message">���<c> ParseException </ c>��������</param>
        public ParseException(String message) : base(message) { }

        /// <summary>
        /// ��<c> e </ c>����ϸ��Ϣ����һ��<c> ParseException </ c>��
        /// </summary>
        /// <param name="e">��<c> WKTReader </ c>���ڽ���һ��������֪���ı��ַ���ʱ�������쳣��</param>
        public ParseException(Exception e) : this(e.ToString(), e) { }

        /// <summary>
        /// ʹ��<paramref name =��innerException��/>����ϸ��Ϣ����һ��<c> ParseException </ c>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException">�ڲ��쳣</param>
        public ParseException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
