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
    /// 所有坐标系的基类
    /// </summary>
    /// <remarks>
    /// <para>坐标系是一个数学空间，空间的元素称为位置。 每个位置由数字列表描述。 
    /// 列表的长度对应于坐标系的尺寸。 因此，在2D坐标系中，每个位置由包含2个数字
    /// 的列表描述。</para>
    /// <para>
    /// 然而，在坐标系中，并不是所有的数字列表对应于位置 - 一些列表可能在坐标系的
    /// 域之外。 例如，在2D经纬度坐标系中，列表（91,91）不对应于位置。</para>
    /// <para>
    /// 一些坐标系也具有从数学空间到现实世界中的位置的映射。 所以在经纬度坐标系中，
    /// 数学位置（纬度，经度）对应于地球表面上的一个位置。 从数学空间到现实世界的
    /// 位置的映射称为基准。</para>
    /// </remarks>
    public interface ICoordinateSystem : IInfo
    {

        /// <summary>
        /// 坐标系的尺寸。
        /// </summary>
        int Dimension { get; }

        /// <summary>
        /// 获取坐标系中尺寸的轴细节。
        /// </summary>
        /// <param name="dimension">尺寸</param>
        /// <returns>轴信息</returns>
        AxisInfo GetAxis(int dimension);

        /// <summary>
        /// 获取坐标系中尺寸的单位。
        /// </summary>
        IUnit GetUnits(int dimension);

        /// <summary>
        /// 获取坐标系的默认包围盒。
        /// </summary>
        /// <remarks>
        /// 获取坐标系的默认包围盒。 有界的坐标系应该返回其域的最小边界框。 无界坐标系
        /// 应该返回一个尽可能大的可能使用的框。 例如，以度为单位的经纬度地理坐标系应该
        /// 从（-180，-90）到（180,90）返回一个框，一个地心坐标系可以从（-r，-r， -r）
        /// 到（+ r，+ r，+ r）其中r是地球的近似半径。
        /// </remarks>
        double[] DefaultEnvelope { get; }
    }
}
