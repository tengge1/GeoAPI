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
    /// 描述坐标变换。 此接口仅描述坐标变换，但实际上并不对点
    /// 进行变换操作。 要转换点，您必须使用数学变换。
    /// </summary>
    public interface ICoordinateTransformation
    {
        /// <summary>
        /// 源坐标系中域的人类可读描述。
        /// </summary>
        string AreaOfUse { get; }

        /// <summary>
        /// 定义转换和参数值的权限。
        /// </summary>
        /// <remarks>
        /// 管理局是一个维护权力机构代码定义的组织。 例如，欧洲石油调查组
        /// （EPSG）维护坐标系数据库和其他空间参照对象，其中每个对象都有一
        /// 个代号。 例如，WGS84 Lat / Lon坐标系的EPSG代码是？326？
        /// </remarks>
        string Authority { get; }

        /// <summary>
        /// 管理局用于识别转化的代码。 空字符串用于无代码。
        /// </summary>
        /// <remarks>AuthorityCode是由管理机构定义以引用特定空间参考对象的
        /// 紧凑字符串。 例如，欧洲调查组（EPSG）授权机构使用32位整数来引用
        /// 坐标系，因此所有的代码字符串都将由数位组成。 WGS84 Lat / Lon的
        /// EPSG代码是？326？</remarks>
        long AuthorityCode { get; }

        /// <summary>
        /// 获得数学变换。
        /// </summary>
        IMathTransform MathTransform { get; }

        /// <summary>
        /// 转换名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取供应商提供的备注。
        /// </summary>
        string Remarks { get; }

        /// <summary>
        /// 源坐标系。
        /// </summary>
        ICoordinateSystem SourceCS { get; }

        /// <summary>
        /// 目标坐标系。
        /// </summary>
        ICoordinateSystem TargetCS { get; }

        /// <summary>
        /// 语义类型的变换。 例如，基准变换或坐标转换。
        /// </summary>
        TransformType TransformType { get; }
    }
}
