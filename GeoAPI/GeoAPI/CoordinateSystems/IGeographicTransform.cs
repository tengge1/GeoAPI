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

using System.Collections.Generic;

namespace GeoAPI.CoordinateSystems
{
    /// <summary>
    /// IGOgraphicTransform接口在地理变换对象上实现，并在地理坐标系之间实现基准变换。
    /// </summary>
    public interface IGeographicTransform : IInfo
    {
        /// <summary>
        /// 获取或设置变换的源地理坐标系。
        /// </summary>
        IGeographicCoordinateSystem SourceGCS { get; set; }

        /// <summary>
        /// 获取或设置转换的目标地理坐标系。
        /// </summary>
        IGeographicCoordinateSystem TargetGCS { get; set; }

        /// <summary>
        /// 返回此地理变换参数的访问器接口。
        /// </summary>
        IParameterInfo ParameterInfo { get; }

        /// <summary>
        /// 将点阵列从源地理坐标系转换为目标地理坐标系。
        /// </summary>
        /// <param name="points">源地理坐标系中的点</param>
        /// <returns>目标地理坐标系中的点</returns>
        List<double[]> Forward(List<double[]> points);

        /// <summary>
        /// 将点阵列从目标地理坐标系转换为源地理坐标系。
        /// </summary>
        /// <param name="points">目标地理坐标系中的点</param>
        /// <returns>源地理坐标系中的点</returns>
        List<double[]> Inverse(List<double[]> points);
    }
}
