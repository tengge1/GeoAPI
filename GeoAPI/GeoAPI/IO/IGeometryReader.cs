using System.IO;
using GeoAPI.Geometries;

namespace GeoAPI.IO
{
    /// <summary>
    /// 用于输入/解析<see cref =“IGeometry”/>实例的接口。
    /// </summary>
    /// <typeparam name="TSource">要读取的源的类型。</typeparam>
    public interface IGeometryReader<TSource> : IGeometryIOSettings
    {
        ///// <summary>
        ///// 获取或设置用于创建解析几何的几何工厂
        ///// </summary>
        //[Obsolete]
        //IGeometryFactory Factory { get; set; }

        /*
        /// <summary>
        /// 获取坐标序列工厂
        /// </summary>
        ICoordinateSequenceFactory CoordinateSequenceFactory { get; }

        /// <summary>
        /// 获得精确模型
        /// </summary>
        IPrecisionModel PrecisionModel { get; }
         */

        /// <summary>
        /// 从<typeparamref name =“TSource”/>读取几何表示形式到<c>几何</ c>。
        /// </summary>
        /// <param name="source">
        /// 从中读取几何的来源
        /// <para>对于WKT <typeparamref name =“TSource”/>是<c> string </ c>，</para>
        /// <para>对于WKB <typeparamref name =“TSource”/>是<c> byte [] </ c>，</para>
        /// </param>
        /// <returns>
        /// A <c>Geometry</c>
        /// </returns>
        IGeometry Read(TSource source);

        /// <summary>
        /// 从<see cref =“Stream”/>读取几何表示到<c>几何</ c>。
        /// </summary>
        /// <param name="stream">要读取的流。</param>
        /// <c>几何</ c>
        IGeometry Read(Stream stream);

        /// <summary>
        /// 获取或设置是否固定无效线性环
        /// </summary>
        bool RepairRings { get; set; }

    }

    /// <summary>
    /// <see cref =“IGeometry”/>实例的文本输入接口。
    /// </summary>
    public interface ITextGeometryReader : IGeometryReader<string>
    {
    }

    /// <summary>
    /// <see cref =“IGeometry”/>实例的二进制输入接口。
    /// </summary>
    public interface IBinaryGeometryReader : IGeometryReader<byte[]>
    {
    }
}