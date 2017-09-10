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
    /// 计算其他数量的一组数量。（基准）
    /// </summary>
    /// <remarks>
    /// 对于OGC抽象模型，它可以被定义为具有坐标的地球上的一组真实点。 例如，
    /// 数据可以被认为是完全定义坐标系相对于地球的起点和方向的一组参数。 描述
    /// 坐标系与某些预定物理位置（如质心）和物理方向（如旋转轴）的关系的文本
    /// 描述和/或一组参数。 基准面的定义还可以包括时间行为（例如坐标轴方向的变化率）。
    /// </remarks>
    public interface IDatum : IInfo
    {
        /// <summary>
        /// 获取或设置基准的类型为枚举代码。
        /// </summary>
        DatumType DatumType { get; set; }
    }
}
