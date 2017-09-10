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
    /// 一个3D坐标系，起源于地球的中心。
    /// </summary>
    public interface IGeocentricCoordinateSystem : ICoordinateSystem
    {
        /// <summary>
        /// 返回HorizontalDatum。 水平数据用于确定地球中心在何处被认为是。 
        /// 所有坐标点将从地球的中心而不是表面测量。
        /// </summary>
        IHorizontalDatum HorizontalDatum { get; set; }

        /// <summary>
        /// 获取沿所有轴使用的单位。
        /// </summary>
        ILinearUnit LinearUnit { get; set; }

        /// <summary>
        /// 返回主子午线。
        /// </summary>
        IPrimeMeridian PrimeMeridian { get; set; }
    }
}
