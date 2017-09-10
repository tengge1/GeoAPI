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

namespace GeoAPI.CoordinateSystems
{
    /// <summary>
    /// 使用代码创建空间参考对象。
    /// </summary>
    /// <remarks>
    ///  规则由外部机构维护。 一个常见的机构是EPSG，它也用于GeoTIFF标准和SharpMap。
    /// </remarks>
    public interface ICoordinateSystemAuthorityFactory
    {
        /// <summary>
        /// 返回此工厂的管理局名称（例如“EPSG”或“POSC”）。
        /// </summary>
        string Authority { get; }

        /// <summary>
        /// 返回与给定代码相对应的投影坐标系对象。
        /// </summary>
        /// <param name="code">识别码。</param>
        /// <returns>具有给定代码的投影坐标系对象。</returns>
        IProjectedCoordinateSystem CreateProjectedCoordinateSystem(long code);

        /// <summary>
        /// 返回与给定代码相对应的地理坐标系对象。
        /// </summary>
        /// <param name="code">识别码。</param>
        /// <returns>具有给定代码的地理坐标系对象。</returns>
        IGeographicCoordinateSystem CreateGeographicCoordinateSystem(long code);

        /// <summary>
        /// 返回与给定代码相对应的水平数据对象。
        /// </summary>
        /// <param name="code">识别码。</param>
        /// <returns>具有给定代码的水平基准面对象。</returns>
        IHorizontalDatum CreateHorizontalDatum(long code);

        /// <summary>
        /// 返回与给定代码相对应的椭圆体对象。
        /// </summary>
        /// <param name="code">识别码。</param>
        /// <returns>具有给定代码的椭圆体对象。</returns>
        IEllipsoid CreateEllipsoid(long code);

        /// <summary>
        /// 返回与给定代码相对应的主子午线对象。
        /// </summary>
        /// <param name="code">识别码。</param>
        /// <returns>具有给定代码的主子午线对象。</returns>
        IPrimeMeridian CreatePrimeMeridian(long code);

        /// <summary>
        /// 返回与给定代码相对应的线性单位对象。
        /// </summary>
        /// <param name="code">识别码。</param>
        /// <returns>具有给定代码的线性单位对象。</returns>
        ILinearUnit CreateLinearUnit(long code);

        /// <summary>
        /// 返回与给定代码相对应的<see cref =“IAngularUnit”>角度单位</ see>对象。
        /// </summary>
        /// <param name="code">识别码。</param>
        /// <returns>给定代码的角度单位对象。</returns>
        IAngularUnit CreateAngularUnit(long code);

        /// <summary>
        /// Creates a <see cref="IVerticalDatum"/> from a code.
        /// </summary>
        /// <param name="code">管理局代码</param>
        /// <returns>给定代码的垂直基准</returns>
        IVerticalDatum CreateVerticalDatum(long code);

        /// <summary>
        /// 从代码创建一个<see cref =“IVerticalCoordinateSystem”>垂直坐标系</ see>。
        /// </summary>
        /// <param name="code">管理局代码</param>
        /// <returns></returns>
        IVerticalCoordinateSystem CreateVerticalCoordinateSystem(long code);

        /// <summary>
        /// 从代码创建一个3D坐标系。
        /// </summary>
        /// <param name="code">管理局代码</param>
        /// <returns>给定代码的复合坐标系</returns>
        ICompoundCoordinateSystem CreateCompoundCoordinateSystem(long code);

        /// <summary>
        /// 从代码创建一个<see cref =“IHorizontalCoordinateSystem”>水平坐标系统</ see>。
        /// 水平坐标系可以是地理或投影。
        /// </summary>
        /// <param name="code">管理局代码</param>
        /// <returns>给定代码的水平坐标系</returns>
        IHorizontalCoordinateSystem CreateHorizontalCoordinateSystem(long code);

        /// <summary>
        /// 获取对应于代码的对象的描述。
        /// </summary>
        string DescriptionText { get; }

        /// <summary>
        /// 从WKT名称获取大地水准面代码。
        /// </summary>
        /// <remarks>
        ///  在WKT水平基准的OGC定义中，大地水准面由引用的字符串引用，用作键值。 
        /// 该方法将键值字符串转换为该权限所识别的代码。
        /// </remarks>
        /// <param name="wkt"></param>
        /// <returns></returns>
        string GeoidFromWktName(string wkt);

        /// <summary>
        /// 获取大地水准面的WKT名称。
        /// </summary>
        /// <remarks>
        ///  在WKT水平基准的OGC定义中，大地水准面由引用的字符串引用，用作键值。 
        /// 该方法从大地水准面代码获取OGC WKT键值。
        /// </remarks>
        /// <param name="geoid"></param>
        /// <returns></returns>
        string WktGeoidName(string geoid);
    }
}
