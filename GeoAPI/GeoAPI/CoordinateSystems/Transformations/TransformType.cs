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
    /// 用于坐标变换的语义变换类型。
    /// </summary>
    public enum TransformType : int
    {
        /// <summary>
        /// 未知或未指定类型的变换。
        /// </summary>
        Other = 0,

        /// <summary>
        /// 变换仅取决于定义的参数。 例如，地图投影。
        /// </summary>
        Conversion = 1,

        /// <summary>
        /// 变换仅取决于经验导出的参数。 例如基准变换。
        /// </summary>
        Transformation = 2,

        /// <summary>
        /// 变换取决于定义和经验参数。
        /// </summary>
        ConversionAndTransformation = 3
    }
}
