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

namespace GeoAPI.CoordinateSystems.Transformations
{
    /// <summary>
    /// 指示由凸包覆盖的域的部分的标志
    /// </summary>
    /// <remarks>
    /// 这些标志可以组合。 例如，值3对应于<see cref =“Inside”/>
    /// 和<see cref =“Outside”/>的组合，这意味着凸包的某些部分在
    /// 域内，而部分凸包在域之外。
    /// </remarks>
    public enum DomainFlags : int
    {
        /// <summary>
        /// 凸包中的至少一个点在变换的域内。
        /// </summary>
        Inside = 1,

        /// <summary>
        /// 凸包中的至少一个点在变换域之外。
        /// </summary>
        Outside = 2,

        /// <summary>
        /// 凸包中的至少一点不会连续变形。
        /// </summary>
        /// <remarks>
        /// 作为一个例子，考虑一个“经度回归”变换，它调整经度坐标
        /// 以考虑主子午线的变化。 如果旋转是东方5度，则点
        /// （Lat = 175，Lon = 0）不会连续变换，因为它位于将以+ 180 / -180度
        /// 分割的子午线。
        /// </remarks>
        Discontinuous = 4
    }
}
