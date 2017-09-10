using System;

namespace GeoAPI.Operation.Buffer
{
    /// <summary>
    /// 缓冲样式。
    /// </summary>
    [Obsolete("Use EndCapStyle instead.")]
    public enum BufferStyle
    {
        /// <summary> 
        /// 指定一个圆形缓冲区端帽endCapStyle（默认）。
        /// </summary>/
        CapRound = 1,

        /// <summary> 
        /// 指定一个对接（或平面）行缓冲区端帽endCapStyle。
        /// </summary>
        CapButt = 2,

        /// <summary>
        /// 指定一个方形线缓冲区端帽endCapStyle。
        /// </summary>
        CapSquare = 3,
    }
}
