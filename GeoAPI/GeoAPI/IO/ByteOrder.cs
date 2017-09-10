namespace GeoAPI.IO
{
    /// <summary>
    /// 字节顺序
    /// </summary>
    public enum ByteOrder : byte
    {
        /// <summary>
        /// 大尾端
        /// </summary>
        BigEndian = 0x00,

        /// <summary>
        /// 小尾端
        /// </summary>
        LittleEndian = 0x01,
    }
}