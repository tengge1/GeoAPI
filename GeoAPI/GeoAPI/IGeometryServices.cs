using System;
using System.Collections;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace GeoAPI
{
    /// <summary>
    /// 委托函数从给定的初始化字符串获取坐标系
    /// </summary>
    /// <param name="init">初始化字符串</param>
    /// <typeparam name="TCoordinateSystem">坐标系的类型。</typeparam>
    [Obsolete("Not used", true)]
    public delegate TCoordinateSystem GetCoordinateSystemDelegate<TCoordinateSystem>(string init);

    /// <summary>
    /// 用于提供对几何创建工具的访问的类的接口。
    /// </summary>
    public interface IGeometryServices
    {
        /// <summary>
        /// 获取默认的空间参考ID
        /// </summary>
        int DefaultSRID { get; }

        /// <summary>
        /// 获取或设置要使用的坐标序列工厂
        /// </summary>
        ICoordinateSequenceFactory DefaultCoordinateSequenceFactory { get; }

        /// <summary>
        /// 获取或设置默认精度模型
        /// </summary>
        IPrecisionModel DefaultPrecisionModel { get; }

        /// <summary>
        /// 基于给定的精度模型类型创建精度模型
        /// </summary>
        /// <returns>精密模型类型</returns>
        IPrecisionModel CreatePrecisionModel(PrecisionModels modelType);

        /// <summary>
        /// 基于给定精度模型创建精度模型。
        /// </summary>
        /// <returns>精密模型</returns>
        IPrecisionModel CreatePrecisionModel(IPrecisionModel modelType);

        /// <summary>
        /// 基于给定的比例因子创建精度模型。
        /// </summary>
        /// <param name="scale">比例因子</param>
        /// <returns>精密模型。</returns>
        IPrecisionModel CreatePrecisionModel(double scale);

        /// <summary>
        /// 创建一个新的几何工厂，使用<see cref =“DefaultPrecisionModel”/>，<see cref =“DefaultSRID”/>和<see cref =“DefaultCoordinateSequenceFactory”/>。
        /// </summary>
        /// <returns>几何工厂</returns>
        IGeometryFactory CreateGeometryFactory();

        /// <summary>
        /// 使用<see cref =“DefaultPrecisionModel”/>和<see cref =“DefaultCoordinateSequenceFactory”/>创建几何分数。
        /// </summary>
        /// <param name="srid"></param>
        /// <returns>几何工厂</returns>
        IGeometryFactory CreateGeometryFactory(int srid);

        /// <summary>
        /// 使用给定的<paramref name =“coordinateSequenceFactory”/>以及<see cref =“DefaultPrecisionModel”/>和<see cref =“DefaultSRID”/>创建几何工厂。
        /// </summary>
        /// <param name="coordinateSequenceFactory">要使用的坐标序列工厂。</param>
        /// <returns>几何工厂。</returns>
        IGeometryFactory CreateGeometryFactory(ICoordinateSequenceFactory coordinateSequenceFactory);

        /// <summary>
        /// 使用给定的<paramref name =“precisionModel”/>以及<see cref =“DefaultCoordinateSequenceFactory”/>和<see cref =“DefaultSRID”/>创建几何工厂。
        /// </summary>
        /// <param name="precisionModel">要使用的坐标序列工厂。</param>
        /// <returns>The geometry factory.</returns>
        IGeometryFactory CreateGeometryFactory(IPrecisionModel precisionModel);

        /// <summary>
        /// 使用给定的<paramref name =“precisionModel”/>以及<see cref =“DefaultCoordinateSequenceFactory”/>和<see cref =“DefaultSRID”/>创建几何工厂。
        /// </summary>
        /// <param name="precisionModel">要使用的坐标序列工厂。</param>
        /// <param name="srid">空间参考ID。</param>
        /// <returns>几何工厂。</returns>
        IGeometryFactory CreateGeometryFactory(IPrecisionModel precisionModel, int srid);

        /// <summary>
        /// 使用给定的<paramref name =“precisionModel”/>，<paramref name =“srid”/>和<paramref name =“coordinateSequenceFactory”/>创建几何工厂。
        /// </summary>
        /// <param name="precisionModel">The coordinate sequence factory to use.</param>
        /// <param name="srid">The spatial reference id.</param>
        /// <param name="coordinateSequenceFactory">The coordinate sequence factory.</param>
        /// <returns>The geometry factory.</returns>
        IGeometryFactory CreateGeometryFactory(IPrecisionModel precisionModel, int srid,
                                               ICoordinateSequenceFactory coordinateSequenceFactory);

        /// <summary>
        /// 从配置中读取配置
        /// </summary>
        void ReadConfiguration();

        /// <summary>
        /// 将当前配置写入配置
        /// </summary>
        void WriteConfiguration();
    }
}