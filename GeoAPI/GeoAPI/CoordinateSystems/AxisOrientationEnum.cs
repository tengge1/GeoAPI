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
    /// 轴方向。 一些坐标系使用非标准方向。 例如，南非电网的第一轴通常指向西，而
    /// 不是东。 这个信息与将南非网格坐标转换为经纬度的算法显然相关。
    /// </summary>
    public enum AxisOrientationEnum : short
    {
        /// <summary>
        /// 未知或未指定的轴方向。 这可以用于本地或拟合的坐标系。
        /// </summary>
        Other = 0,

        /// <summary>
        /// 增加纵坐标值向北。 这通常用于Grid Y坐标和纬度。
        /// </summary>
        North = 1,

        /// <summary>
        /// 增加纵坐标值向南。 这很少使用。
        /// </summary>
        South = 2,

        /// <summary>
        /// 增加纵坐标值向东。 这很少使用。
        /// </summary>
        East = 3,

        /// <summary>
        /// 向西增加坐标值。 这通常用于Grid X坐标和经度。
        /// </summary>
        West = 4,

        /// <summary>
        /// 增加纵坐标值上升。 这用于垂直坐标系。
        /// </summary>
        Up = 5,

        /// <summary>
        /// 增加纵坐标值下降。 这用于垂直坐标系。
        /// </summary>
        Down = 6
    }
}
