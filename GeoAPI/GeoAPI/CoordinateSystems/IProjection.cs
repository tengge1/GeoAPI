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
    /// IProjection接口定义与投影对象一起存储的标准信息。 给定地理坐标系的椭球，投影对象
    /// 实现从地理坐标系到投影坐标系的坐标变换。 预期感兴趣的每个坐标变换，例如横向墨卡托，
    /// 兰伯特将被实现为co类型投影的COM类，支持IProjection接口。
    /// </summary>
    public interface IProjection : IInfo
    {
        /// <summary>
        /// 获取投影的参数数。
        /// </summary>
        int NumParameters { get; }

        /// <summary>
        /// 获取投影分类名称（例如“横向墨卡托”）。
        /// </summary>
        string ClassName { get; }

        /// <summary>
        /// 获取投影的索引参数。
        /// </summary>
        /// <param name="index">参数索引</param>
        /// <returns>第n个参数</returns>
        ProjectionParameter GetParameter(int index);

        /// <summary>
        /// 获取投影的命名参数。
        /// </summary>
        /// <remarks>参数名称不区分大小写</remarks>
        /// <param name="name">参数名称</param>
        /// <returns>参数或null（如果没有找到）</returns>
        ProjectionParameter GetParameter(string name);
    }
}
