using System;
// Copyright 2013-2015 - Felix Obermaier (www.ivv-aachen.de)
// Copyright 2015      - Spartaco Giubbolini
//
// This file is part of GeoAPI.
// GeoAPI is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// GeoAPI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;

namespace GeoAPI
{
    /// <summary>
    /// 提供对坐标系和转换工具的访问的类的接口。
    /// </summary>
    public interface ICoordinateSystemServices
    {
        /// <summary>
        /// 通过<paramref name =“srid”/>标识符返回坐标系
        /// </summary>
        /// <param name="srid">坐标系的初始化</param>
        /// <returns>坐标系。</returns>
        ICoordinateSystem GetCoordinateSystem(int srid);

        /// <summary>
        /// 通过<paramref name =“authority”/>和<paramref name =“code”/>返回坐标系。
        /// </summary>
        /// <param name="authority">坐标系管理局</param>
        /// <param name="code">通过<paramref name =“authority”/>分配给坐标系的代码。</param>
        /// <returns>坐标系。</returns>
        ICoordinateSystem GetCoordinateSystem(string authority, long code);

        /// <summary>
        /// 获取该坐标系可以被访问的标识符的方法。
        /// </summary>
        /// <param name="authority">管理局名称</param>
        /// <param name="authorityCode">由<paramref name =“authority”/>分配的代码</param>
        /// <returns>标识符或<value> null </value></returns>
        int? GetSRID(string authority, long authorityCode);

        /// <summary>
        /// 在由其标识符定义的两个空间参考系统之间创建坐标变换的方法
        /// </summary>
        /// <remarks>这是<see cref =“创建转换（KoordinatenSystem，KoordinatenSystem）”/>的便利函数。</remarks>
        /// <param name="sourceSrid">源空间参考系统的标识符。</param>
        /// <param name="targetSrid">目标空间参考系统的标识符。</param>
        /// <returns>如果不能创建转换，则坐标变换<value> null </ value>。</returns>
        ICoordinateTransformation CreateTransformation(int sourceSrid, int targetSrid);

        /// <summary>
        /// 在两个空间参考系统之间创建坐标变换的方法
        /// </summary>
        /// <param name="source">源空间参考系。</param>
        /// <param name="target">目标空间参考系。</param>
        /// <returns>如果不能创建转换，则坐标变换<value> null </ value>。</returns>
        ICoordinateTransformation CreateTransformation(ICoordinateSystem source, ICoordinateSystem target);
    }
}