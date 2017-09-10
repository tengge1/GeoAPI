// Copyright 2005, 2006 - Morten Nielsen (www.iter.dk)
//
// This file is part of SharpMap.
// SharpMap is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// SharpMap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System.Collections.Generic;

namespace GeoAPI.CoordinateSystems
{
    /// <summary>
    /// 从简单的对象或值构建复杂的对象。
    /// </summary>
    /// <remarks>
    /// <para>ICoordinateSystemFactory允许应用程序制作不能由
    /// <see cref =“ICoordinateSystemAuthorityFactory”/>创建的坐标系。 这个工厂非常
    /// 灵活，而权威的工厂更容易使用。</para>
    /// <para>所以<see cref =“ICoordinateSystemAuthorityFactory”/>可用于制作“标准”
    /// 坐标系，而<see cref =“ICoordinateSystemFactory”/>可用于制作“特殊”坐标系。
    /// </para>
    /// <para>例如，EPSG权威机构拥有使用NAD83基准的美国国家平面坐标系的代码，但这些
    /// 坐标系统始终使用米。 EPSG没有使用英尺单位的NAD83状态平面坐标系的代码。 该工厂
    /// 允许应用程序创建这样的混合坐标系。</para>
    /// </remarks>
    public interface ICoordinateSystemFactory
    {
        /// <summary>
        /// 创建一个<see cref =“ICompoundCoordinateSystem”/>。
        /// </summary>
        /// <param name="name">复合坐标系的名称。</param>
        /// <param name="head">头坐标系</param>
        /// <param name="tail">尾坐标系</param>
        /// <returns>复合坐标系</returns>
        ICompoundCoordinateSystem CreateCompoundCoordinateSystem(string name, ICoordinateSystem head, ICoordinateSystem tail);

        /// <summary>
        /// 从半径值创建一个<see cref =“IEllipsoid”/>。
        /// </summary>
        /// <seealso cref="CreateFlattenedSphere"/>
        /// <param name="name">椭圆体名称</param>
        /// <param name="semiMajorAxis"></param>
        /// <param name="semiMinorAxis"></param>
        /// <param name="linearUnit"></param>
        /// <returns>椭球</returns>
        IEllipsoid CreateEllipsoid(string name, double semiMajorAxis, double semiMinorAxis, ILinearUnit linearUnit);

        /// <summary>
        /// 创建<see cref="IFittedCoordinateSystem"/>.
        /// </summary>
        /// <remarks>拟合坐标系中轴的单位将从基座坐标系的单位推断出来。 如果仿射映射
        /// 执行旋转，则任何混合轴必须具有相同的单位。 例如，（lat_deg，lon_deg，
        /// height_feet）系统可以在（lat，lon）平面中旋转，因为两个受影响的轴都是度数。
        ///  但您不应该在任何其他平板上旋转该坐标系。</remarks>
        /// <param name="name">坐标系名称</param>
        /// <param name="baseCoordinateSystem">基本坐标系</param>
        /// <param name="toBaseWkt"></param>
        /// <param name="arAxes"></param>
        /// <returns>合适坐标系</returns>
        IFittedCoordinateSystem CreateFittedCoordinateSystem(string name, ICoordinateSystem baseCoordinateSystem, string toBaseWkt, List<AxisInfo> arAxes);

        /// <summary>
        /// 创建 <see cref="IEllipsoid"/> 从一个大半径，反平坦化。
        /// </summary>
        /// <seealso cref="CreateEllipsoid"/>
        /// <param name="name">椭圆体名称</param>
        /// <param name="semiMajorAxis">半主轴</param>
        /// <param name="inverseFlattening">反平整</param>
        /// <param name="linearUnit">线性单位</param>
        /// <returns>椭球</returns>
        IEllipsoid CreateFlattenedSphere(string name, double semiMajorAxis, double inverseFlattening, ILinearUnit linearUnit);


        /// <summary>
        /// 从XML字符串创建坐标系对象。
        /// </summary>
        /// <param name="xml">空间索引的XML表示</param>
        /// <returns>产生的空间索引对象</returns>
        ICoordinateSystem CreateFromXml(string xml);

        /// <summary>
        /// 给出它众所周知的文本表示，创建一个空间参考对象。 输出对象可以是
        /// <see cref =“IGeographicCoordinateSystem”/>或
        /// <see cref =“IProjectedCoordinateSystem”/>。
        /// </summary>
        /// <param name="WKT">用于空间参考的众所周知的文本表示</param>
        /// <returns>The resulting spatial reference object</returns>
        ICoordinateSystem CreateFromWkt(string WKT);

        /// <summary>
        /// 创建一个<see cref =“IGeographicCoordinateSystem”/>，可以是Lat / Lon或Lon / Lat。
        /// </summary>
        /// <param name="name">地理坐标系的名称</param>
        /// <param name="angularUnit">角度单位</param>
        /// <param name="datum">水平基准</param>
        /// <param name="primeMeridian">本初子午线</param>
        /// <param name="axis0">第一轴</param>
        /// <param name="axis1">第二轴</param>
        /// <returns>地理坐标系</returns>
        IGeographicCoordinateSystem CreateGeographicCoordinateSystem(string name, IAngularUnit angularUnit, IHorizontalDatum datum, IPrimeMeridian primeMeridian, AxisInfo axis0, AxisInfo axis1);

        /// <summary>
        /// 从椭圆体和Bursa-World参数创建<see cref =“IHorizontalDatum”/>。
        /// </summary>
        /// <remarks>
        /// 由于此方法包含一组Bursa-Wolf参数，因此创建的数据将始终与WGS84有关系。 
        /// 如果要创建一个与WGS84无关的水平基准，则可以指定<see cref =“DatumType”>
        ///  horizontalDatumType </see> <see cref =“DatumType.HD_Other”/>，或通过
        /// WKT创建它。
        /// </remarks>
        /// <param name="name">椭圆体名称</param>
        /// <param name="datumType">基准类型</param>
        /// <param name="ellipsoid">椭球</param>
        /// <param name="toWgs84">Wgs84转换参数</param>
        /// <returns>水平基准</returns>
        IHorizontalDatum CreateHorizontalDatum(string name, DatumType datumType, IEllipsoid ellipsoid, Wgs84ConversionInfo toWgs84);

        /// <summary>
        /// 创建一个<see cref =“ILocalCoordinateSystem”>局部坐标系</ see>。
        /// </summary>
        /// <remarks>
        /// 局部坐标系的尺寸由轴阵列的大小确定。 所有轴将具有相同的单位。如果要使用
        /// 混合单位制作坐标系，则可以使用不同的局部坐标系进行复合坐标系。
        /// </remarks>
        /// <param name="name">局部坐标系的名称</param>
        /// <param name="datum">本地数据</param>
        /// <param name="unit">单位</param>
        /// <param name="axes">轴信息</param>
        /// <returns>局部坐标系</returns>
        ILocalCoordinateSystem CreateLocalCoordinateSystem(string name, ILocalDatum datum, IUnit unit, List<AxisInfo> axes);

        /// <summary>
        /// 创建一个<see cref =“ILocalDatum”/>。
        /// </summary>
        /// <param name="name">基准名称</param>
        /// <param name="datumType">基准类型</param>
        /// <returns></returns>
        ILocalDatum CreateLocalDatum(string name, DatumType datumType);

        /// <summary>
        /// 相对于格林威治，创建一个<see cref =“IPrimeMeridian”/>。
        /// </summary>
        /// <param name="name">原子午线名称</param>
        /// <param name="angularUnit">角度单位</param>
        /// <param name="longitude">经度</param>
        /// <returns>本初子午线</returns>
        IPrimeMeridian CreatePrimeMeridian(string name, IAngularUnit angularUnit, double longitude);

        /// <summary>
        /// 使用投影对象创建<see cref =“IProjectedCoordinateSystem”/>。
        /// </summary>
        /// <param name="name">投影坐标系的名称</param>
        /// <param name="gcs">地理坐标系</param>
        /// <param name="projection">投影</param>
        /// <param name="linearUnit">线性单位</param>
        /// <param name="axis0">主轴</param>
        /// <param name="axis1">次轴</param>
        /// <returns>投影坐标系</returns>
        IProjectedCoordinateSystem CreateProjectedCoordinateSystem(string name, IGeographicCoordinateSystem gcs, IProjection projection, ILinearUnit linearUnit, AxisInfo axis0, AxisInfo axis1);

        /// <summary>
        /// 创建一个<see cref =“IProjection”/>。
        /// </summary>
        /// <param name="name">投影名称</param>
        /// <param name="wktProjectionClass">投影类</param>
        /// <param name="Parameters">投影参数</param>
        /// <returns>投影</returns>
        IProjection CreateProjection(string name, string wktProjectionClass, List<ProjectionParameter> Parameters);

        /// <summary>
        /// 从<see cref =“IVerticalDatum”>基准</ see>和<see cref =“ILinearUnit”>线性单位</ see>创建<see cref =“IVerticalCoordinateSystem”/>。
        /// </summary>
        /// <param name="name">垂直坐标系的名称</param>
        /// <param name="datum">垂直基准</param>
        /// <param name="verticalUnit">单元</param>
        /// <param name="axis">轴信息</param>
        /// <returns>垂直坐标系</returns>
        IVerticalCoordinateSystem CreateVerticalCoordinateSystem(string name, IVerticalDatum datum, ILinearUnit verticalUnit, AxisInfo axis);

        /// <summary>
        /// 从枚举类型值创建一个<see cref =“IVerticalDatum”/>。
        /// </summary>
        /// <param name="name">基准名称</param>
        /// <param name="datumType">基准类型</param>
        /// <returns>垂直基准</returns>	
        IVerticalDatum CreateVerticalDatum(string name, DatumType datumType);
    }
}
