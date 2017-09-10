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
    /// IProjectedCoordinateSystem接口定义与投影坐标系对象一起存储的标准信息。 使用
    /// 地理坐标系对象和定义从地理坐标系到投影坐标系的坐标变换的投影对象来定义投影
    /// 坐标系。 通过将ProjectedCoordinateSystem实例与属于不同Projection COM类（横向
    /// 墨卡托和Albers）的投影实例相关联，单个ProjectedCoordinateSystem COM类的实例可
    /// 用于建模不同的投影坐标系（例如UTM Zone 10，Albers）。
    /// </summary>
    public interface IProjectedCoordinateSystem : IHorizontalCoordinateSystem
    {
        /// <summary>
        /// 获取或设置与投影坐标系相关联的地理坐标系。
        /// </summary>
        IGeographicCoordinateSystem GeographicCoordinateSystem { get; set; }

        /// <summary>
        /// 获取或设置投影坐标系的线性（投影）单位。
        /// </summary>
        ILinearUnit LinearUnit { get; set; }

        /// <summary>
        /// 获取或设置投影坐标系的投影。
        /// </summary>
        IProjection Projection { get; set; }
    }
}
