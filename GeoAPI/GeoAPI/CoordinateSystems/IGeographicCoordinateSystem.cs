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
    ///IGeographicCoordinateSystem接口是IGeodeticSpatialReference的子类，并定义了
    /// 与地理坐标系对象存储的标准信息。
    /// </summary>
    public interface IGeographicCoordinateSystem : IHorizontalCoordinateSystem
    {
        /// <summary>
        /// 获取或设置地理坐标系的角度单位。
        /// </summary>
        IAngularUnit AngularUnit { get; set; }

        /// <summary>
        /// 获取或设置地理坐标系的主子午线。
        /// </summary>
        IPrimeMeridian PrimeMeridian { get; set; }

        /// <summary>
        /// 获取WGS84坐标的可用转换次数。
        /// </summary>
        int NumConversionToWGS84 { get; }

        /// <summary>
        /// 获取有关转换为WGS84的详细信息。
        /// </summary>
        Wgs84ConversionInfo GetWgs84ConversionInfo(int index);
    }
}
