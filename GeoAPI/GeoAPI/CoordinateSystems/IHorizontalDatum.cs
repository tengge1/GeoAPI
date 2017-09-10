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
    /// 用于测量地球表面位置的程序。
    /// </summary>
    public interface IHorizontalDatum : IDatum
    {
        /// <summary>
        /// 获取或设置基准面的椭圆体。
        /// </summary>
        IEllipsoid Ellipsoid { get; set; }

        /// <summary>
        /// 获得Bursa Wolf转换为WGS84的首选参数。 7个返回的值对应于以米
        /// 为单位的（dx，dy，dz），（ex，ey，ez）为弧秒，scaling为百万分之一。
        /// </summary>
        Wgs84ConversionInfo Wgs84Parameters { get; set; }
    }
}
