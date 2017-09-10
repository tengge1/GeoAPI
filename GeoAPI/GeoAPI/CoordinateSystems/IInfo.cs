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
    /// ISpatialReferenceInfo接口定义与空间参考对象一起存储的标准信息。 该接口
    /// 被重用于系统中的许多空间参考对象。
    /// </summary>
    public interface IInfo
    {
        /// <summary>
        /// 获取或设置对象的名称。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取或设置此对象的管理局名称，例如，POSC是具有授权特定身份代码的标准对象。 
        /// 如果这是自定义对象，返回CUSTOM。
        /// </summary>
        string Authority { get; }

        /// <summary>
        /// 获取或设置对象的管理局特定识别码
        /// </summary>
        long AuthorityCode { get; }

        /// <summary>
        /// 获取或设置对象的别名。
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// 获取或设置对象的缩写。
        /// </summary>
        string Abbreviation { get; }

        /// <summary>
        /// 获取或设置对象的提供者提供的备注。
        /// </summary>
        string Remarks { get; }

        /// <summary>
        /// 返回此简单特征规范中定义的此空间参考对象的知名文本。
        /// </summary>
        string WKT { get; }

        /// <summary>
        /// 获取此对象的XML表示。
        /// </summary>
        string XML { get; }

        /// <summary>
        /// 检查此实例的值是否等于另一个实例的值。
        /// 仅用于坐标系的参数用于比较。 名称，缩写，权限，别名和备注在比较中被忽略。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>如果相等则为真</returns>
        bool EqualParams(object obj);
    }
}
