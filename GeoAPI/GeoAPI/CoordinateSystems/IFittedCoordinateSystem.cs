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
    /// 位于另一个坐标系中的坐标系。 拟合的坐标系可以旋转和移动，或使用任何其他
    /// 数学变换将其自身注入基坐标系。
    /// </summary>
    public interface IFittedCoordinateSystem : ICoordinateSystem
    {
        /// <summary>
        /// 获取基坐标系。
        /// </summary>
        ICoordinateSystem BaseCoordinateSystem { get; }

        /// <summary>
        /// 获取已知的数学变换文本到基坐标系。 该拟合坐标系的尺寸由数学变换的
        /// 源维度决定。 变换在该坐标系的域中应该是一对一的，基坐标系的维数必须
        /// 至少与该坐标系的尺寸一样大。
        /// </summary>
        /// <returns></returns>
        string ToBase();
    }
}
