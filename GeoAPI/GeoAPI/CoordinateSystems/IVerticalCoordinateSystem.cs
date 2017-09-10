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
    /// 适用于垂直测量的一维坐标系。
    /// </summary>
    public interface IVerticalCoordinateSystem : ICoordinateSystem
    {
        /// <summary>
        /// 获取垂直基准，表示测量方法
        /// </summary>
        IVerticalDatum VerticalDatum { get; set; }

        /// <summary>
        /// 获取沿垂直轴使用的单位。
        /// </summary>
        ILinearUnit VerticalUnit { get; set; }
    }
}
