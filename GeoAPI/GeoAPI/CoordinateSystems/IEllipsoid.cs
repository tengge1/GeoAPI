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
    /// IEllipsoid接口定义了用椭圆体对象存储的标准信息。
    /// </summary>
    public interface IEllipsoid : IInfo
    {
        /// <summary>
        /// 获取或设置半长轴的值。
        /// </summary>
        double SemiMajorAxis { get; set; }

        /// <summary>
        /// 获取或设置半短轴的值。
        /// </summary>
        double SemiMinorAxis { get; set; }

        /// <summary>
        /// 获取或设置椭球的平坦常数的倒数值。
        /// </summary>
        double InverseFlattening { get; set; }

        /// <summary>
        /// 获取或设置轴单位的值。
        /// </summary>
        ILinearUnit AxisUnit { get; set; }

        /// <summary>
        /// 这个椭圆体的反向平坦度是否正确？ 一些椭圆体使用IVF作为定义值，并在询问时计算
        /// 极坐标半径。 其他椭圆体使用极坐标半径来计算IVF。 这种区别对于避免浮点舍入误差
        /// 很重要。
        /// </summary>
        bool IsIvfDefinitive { get; set; }
    }
}
