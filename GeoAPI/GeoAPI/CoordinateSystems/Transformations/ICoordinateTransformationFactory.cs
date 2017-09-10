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
    /// 创建坐标变换。
    /// </summary>
    public interface ICoordinateTransformationFactory
    {
        /// <summary>
        /// 创建两个坐标系之间的转换。
        /// </summary>
        /// <remarks>
        /// 该方法将检查坐标系，以构建它们之间的转换。 如果找不到坐标系之间的
        /// 路径，使用DCP的正常失败行为（例如抛出异常），则此方法可能会失败。</remarks>
        /// <param name="sourceCS">源坐标系</param>
        /// <param name="targetCS">目标坐标系</param>
        /// <returns></returns>
        ICoordinateTransformation CreateFromCoordinateSystems(ICoordinateSystem sourceCS, ICoordinateSystem targetCS);
    }
}
