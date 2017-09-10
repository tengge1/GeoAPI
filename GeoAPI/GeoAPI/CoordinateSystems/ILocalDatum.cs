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
    /// 本地数据 如果两个本地数据对象具有相同的基准类型和名称，那么它们可以被认为
    /// 是相等的。 这意味着坐标可以在两个不同的局部坐标系之间进行转换，只要它们基于
    /// 相同的局部基准。
    /// </summary>
    public interface ILocalDatum : IDatum { }
}
