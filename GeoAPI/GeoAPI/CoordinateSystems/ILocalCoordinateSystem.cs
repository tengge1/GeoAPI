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
    /// 一个地方坐标系，与世界关系不确定。
    /// </summary>
    /// <remarks>通常，局部坐标系不能与其他坐标系相关。 但是，如果支持该接口的两个
    /// 对象具有相同的尺寸，轴，单位和数据，则允许客户端代码假设两个坐标系相同。 
    /// 这允许来自共同来源（例如CAD系统）的多个数据集被覆盖。 此外，坐标转换（CT）
    /// 包的一些实现可以具有用于关联本地基准的机制。（例如，从实际测量中创建和维护
    /// 的转换数据库）
    /// </remarks>
    public interface ILocalCoordinateSystem : ICoordinateSystem
    {
        /// <summary>
        /// 获取或设置本地基准
        /// </summary>
        ILocalDatum LocalDatum { get; set; }
    }
}
