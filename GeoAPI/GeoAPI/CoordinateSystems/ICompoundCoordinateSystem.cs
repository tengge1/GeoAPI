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
    /// 两个坐标系（CRS）的集合。 其中之一通常是基于二维坐标系的CRS，例如具有水平基准
    /// 的地理或投影坐标系。 另一个是垂直CRS，它是具有垂直基准的一维坐标系。
    /// </summary>
    public interface ICompoundCoordinateSystem : ICoordinateSystem
    {
        /// <summary>
        /// 获得第一个子坐标系。
        /// </summary>
        ICoordinateSystem HeadCS { get; }

        /// <summary>
        /// 获得第二个子坐标系。
        /// </summary>
        ICoordinateSystem TailCS { get; }
    }
}
