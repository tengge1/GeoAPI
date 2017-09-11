using System;

namespace GeoAPI.Geometries
{
    using ICloneable = System.ICloneable;

    /// <summary>
    /// 用于在二维笛卡尔平面上存储坐标的轻量级接口。
    /// </summary>
    [Obsolete("Use Coordinate class instead")]
    public interface ICoordinate :
        ICloneable,
        IComparable, IComparable<ICoordinate>, IEquatable<ICoordinate>
    {
        /// <summary>
        /// x坐标值
        /// </summary>
        double X { get; set; }

        /// <summary>
        /// y坐标值
        /// </summary>
        double Y { get; set; }

        /// <summary>
        /// z坐标值
        /// </summary>
        double Z { get; set; }

        /// <summary>
        /// 测量值
        /// </summary>
        double M { get; set; }

        /// <summary>
        /// 获取或设置所有纵坐标值
        /// </summary>
        ICoordinate CoordinateValue { get; set; }

        /// <summary>
        /// 获取或设置<see cref =“Ordinate”/>值<see cref =“ICoordinate”/>
        /// </summary>
        /// <param name="index">The <see cref="Ordinate"/> index</param>
        double this[Ordinate index] { get; set; }

        /// <summary>
        /// 计算与<paramref name =“other”/>坐标的二维距离。
        /// </summary>
        /// <param name="other">另一个坐标</param>
        /// <returns>与其他二维距离</returns>
        double Distance(ICoordinate other);

        /// <summary>
        /// 比较x和y坐标是否相等
        /// </summary>
        /// <param name="other">另一个坐标</param>
        /// <returns><c>如果这个坐标的x和y坐标和<参见paramref =“other”/> coordiante是相等的，则</ c>。</returns>
        bool Equals2D(ICoordinate other);

        /// <summary>
        /// 比较x，y和z坐标的等式
        /// </summary>
        /// <param name="other">另一个坐标</param>
        /// <returns>如果这个坐标的x-，y-和z-坐标和<参见paramref =“other”/> coordiante是相等的，那么<c> true </ c></returns>
        bool Equals3D(ICoordinate other);
    }
}
