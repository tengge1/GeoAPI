using System;

namespace GeoAPI.Operation.Buffer
{
    /// <summary>
    /// ������ʽ��
    /// </summary>
    [Obsolete("Use EndCapStyle instead.")]
    public enum BufferStyle
    {
        /// <summary> 
        /// ָ��һ��Բ�λ�������ñendCapStyle��Ĭ�ϣ���
        /// </summary>/
        CapRound = 1,

        /// <summary> 
        /// ָ��һ���Խӣ���ƽ�棩�л�������ñendCapStyle��
        /// </summary>
        CapButt = 2,

        /// <summary>
        /// ָ��һ�������߻�������ñendCapStyle��
        /// </summary>
        CapSquare = 3,
    }
}
