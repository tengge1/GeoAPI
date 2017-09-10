using System.IO;
using GeoAPI.Geometries;

namespace GeoAPI.IO
{
    /// <summary>
    /// 几何阅读器或写入器接口的基本接口。
    /// </summary>
    public interface IGeometryIOSettings
    {
        /// <summary>
        /// 获取或设置是否必须处理SpatialReference ID。
        /// </summary>
        bool HandleSRID { get; set; }

        /// <summary>
        /// 获取和<see cref =“Ordinates”/>标志，指示可以处理哪些纵坐标。
        /// </summary>
        /// <remarks>
        /// 该标志必须始终至少返回<see cref =“Ordinates.XY”/>。
        /// </remarks>
        Ordinates AllowedOrdinates { get; }

        /// <summary>
        /// 获取和设置<see cref =“Ordinates”/>标志，指示应处理哪些纵坐标。
        /// </summary>
        /// <remarks>
        /// 始终处理<see cref =“Ordinates”/>标志，其余的都是二进制的，并且使用<see cref =“AllowedOrdinates”/>进行编辑。
        /// </remarks>
        Ordinates HandleOrdinates { get; set; }
    }

    /// <summary>
    /// <see cref =“IGeometry”/>实例的二进制输出接口。
    /// </summary>
    /// <typeparam name="TSink">要输出的输出类型。</typeparam>
    public interface IGeometryWriter<TSink> : IGeometryIOSettings
    {
        /// <summary>
        /// 写入给定几何的二进制表示。
        /// </summary>
        /// <param name="geometry">几何</param>
        /// <returns><paramref name =“geometry”/>的二进制表示</returns>
        TSink Write(IGeometry geometry);

        /// <summary>
        /// 写入给定几何的二进制表示。
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="stream"></param>
        void Write(IGeometry geometry, Stream stream);
    }

    /// <summary>
    /// <see cref =“IGeometry”/>实例的二进制输出接口。
    /// </summary>
    public interface IBinaryGeometryWriter : IGeometryWriter<byte[]>
    {
        /// <summary>
        /// 获取或设置所需的<see cref =“ByteOrder”/>
        /// </summary>
        ByteOrder ByteOrder { get; set; }
    }

    /// <summary>
    /// <see cref =“IGeometry”/>实例的文本输出接口。
    /// </summary>
    public interface ITextGeometryWriter : IGeometryWriter<string>
    {
    }

}