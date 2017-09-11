namespace GeoAPI.Geometries
{
    /// <summary>
    /// 曲线接口
    /// </summary>
    public interface ICurve : IGeometry
    {
        /// <summary>
        /// 获取表示组成曲线的坐标序列的值
        /// </summary>
        ICoordinateSequence CoordinateSequence { get; }

        /// <summary>
        /// 获取一个表示曲线起始点的值
        /// </summary>
        IPoint StartPoint { get; }

        /// <summary>
        /// 获取一个表示曲线终点的值
        /// </summary>
        IPoint EndPoint { get; }

        /// <summary>
        /// 获取一个表示曲线关闭的值。
        /// In this case <see cref="StartPoint"/> an <see cref="EndPoint"/> are equal.
        /// </summary>
        bool IsClosed { get; }

        /// <summary>
        /// 得到一个值，表示曲线是一个环。
        /// </summary>
        bool IsRing { get; }
    }
}
