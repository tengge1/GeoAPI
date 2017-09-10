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
    /// IPrimeMeridian接口定义与主子午线对象一起存储的标准信息。 任何主要子午线对象
    /// 必须实现此接口以及ISpatialReferenceInfo接口。
    /// </summary>
    public interface IPrimeMeridian : IInfo
    {
        /// <summary>
        /// 获取或设定主子午线的经度（相对于格林威治主子午线）。
        /// </summary>
        double Longitude { get; set; }

        /// <summary>
        /// 获取或设置AngularUnits。
        /// </summary>
        IAngularUnit AngularUnit { get; set; }
    }
}
