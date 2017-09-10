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

using System;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace GeoAPI.CoordinateSystems.Transformations
{
    /// <summary>
    /// 转换多维坐标点。
    /// </summary>
    /// <remarks>
    /// 如果客户应用程序希望查询转换的源和目标坐标系，则应保持<see cref =“ICoordinateTransformation”/>接口，并且只要希望执行转换就使用包含的数学变换对象。
    /// </remarks>
    public interface IMathTransform
    {
        /// <summary>
        /// 获取输入点的维数。
        /// </summary>
        int DimSource { get; }

        /// <summary>
        /// 获取输出点的维数。
        /// </summary>
        int DimTarget { get; }

        /// <summary>
        /// 测试这个变换是否不移动任何点。
        /// </summary>
        /// <returns></returns>
        bool Identity();

        /// <summary>
        /// 获取这个对象的一个很好的文本表示。
        /// </summary>
        string WKT { get; }

        /// <summary>
        /// 获取此对象的XML表示。
        /// </summary>
        string XML { get; }

        /// <summary>
        /// 在某一点获得此变换的导数。 如果转换在该点没有明确定义的导数，
        /// 则该函数应该以通常的DCP方式失败。 该导数是该点上近似仿射映射
        /// 的非转换部分的矩阵。 矩阵将具有对应于源和目标坐标系的尺寸。 
        /// 如果输入维数为M，输出维数为N，则矩阵的大小为[M] [N]。 矩阵
        /// {elt [n] [m]：n = 0 ..（N-1）}的元素在输出空间中形成与第m个纵
        /// 坐标的小变化引起的位移平行的向量 的输入空间。
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        double[,] Derivative(double[] point);

        /// <summary>
        /// 获得变形的凸包。
        /// </summary>
        /// <remarks>
        /// <para>所提供的纵坐标被解释为一系列点，其在源空间中生成凸包。
        /// 返回的纵坐标表示输出空间中的凸包。 输出点的数量通常与输入点
        /// 的数量不同。 每个输入点应该在有效的域内（可以通过单独测试点的
        /// 域标记来检查）。 但是，输入点的凸包可能会超出有效域。 返回的
        /// 凸包应该包含源凸包和源域的交集的变换图像。</para>
        /// <para>凸包是坐标系中的一个形状，如果两个位置A和B在形状的内部，
        /// 那么在A和B之间的直线中的所有位置也都在形状内。 所以在3D中，立
        /// 方体和球体都是凸包。 凸包的其他不太明显的例子是直线和单点。 
        /// （单点是凸包，因为位置A和B必须都相同 - 即点本身，因此A和B之间的
        /// 直线的长度为零）</para>
        /// <para>不是凸包的形状的一些例子是甜甜圈和马蹄铁。</para>
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        List<double> GetCodomainConvexHull(List<double> points);

        /// <summary>
        /// 获取在凸包中分类域点的标志。
        /// </summary>
        /// <remarks>
        /// 所提供的纵坐标被解释为一系列点，其在源空间中生成凸包。 在概念上，
        /// 然后根据源域测试凸包中的每个（通常是无限的）点。 然后组合所有这些
        /// 测试的标志。 在实践中，不同转换的实现将使用不同的快捷方式来避免无
        /// 限次的测试。
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        DomainFlags GetDomainFlags(List<double> points);

        /// <summary>
        /// 创建此对象的逆变换。
        /// </summary>
        /// <remarks>如果转换不是一对一的，则此方法可能会失败。 然而，所有的
        /// 地图投影都应该成功。</remarks>
        /// <returns></returns>
        IMathTransform Inverse();

        /// <summary>
        /// 转换坐标点。 传递的参数点不应该被修改。
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        double[] Transform(double[] point);

        /// <summary>
        /// 转换一个坐标。 输入坐标保持不变。
        /// </summary>
        /// <param name="coordinate">要转换的坐标</param>
        /// <returns>变换的坐标</returns>
        [Obsolete("Use Coordinate Transform(Coordinate coordinate) instead.")]
        ICoordinate Transform(ICoordinate coordinate);

        /// <summary>
        /// 转换一个坐标。 输入坐标保持不变。
        /// </summary>
        /// <param name="coordinate">要转换的坐标</param>
        /// <returns>变换的坐标</returns>
        Coordinate Transform(Coordinate coordinate);

        /// <summary>
        /// 转换坐标点序数值列表。
        /// </summary>
        /// <remarks>
        /// 提供了这种方法来有效地转换许多点。 提供的序数值数组将包含压缩
        /// 的序数值。 例如，如果源维数为3，那么将以这个顺序（x0，y0，z0，
        /// x1，y1，z1 ...）打包序数。 传递的数组的大小必须是DimSource的
        /// 整数倍。 返回的序数值以类似的方式打包。 在一些DCP。 可以原位转
        /// 换序数，并且返回的数组可能与传递的数组相同。
        /// 所以任何客户端代码都不应该尝试重用传递的序数值（尽管它们可以
        /// 重用传递的数组）。 如果有任何问题，那么服务器实现会抛出异常。 
        /// 如果发生这种情况，客户端不应该对序数值的状态做任何假设。
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        IList<double[]> TransformList(IList<double[]> points);

        /// <summary>
        /// 转换坐标列表。
        /// </summary>
        /// <remarks>
        /// 提供了这种方法来有效地转换许多点。 提供的序数值数组将包含压缩的序数值。 
        /// 例如，如果源维数为3，那么将以这个顺序（x0，y0，z0，x1，y1，z1 ...）打包
        /// 序数。传递的数组的大小必须是DimSource的整数倍。返回的序数值以类似的方式
        /// 打包。 在一些DCP。 可以原位转换序数，并且返回的数组可能与传递的数组相同。
        /// 所以任何客户端代码都不应该尝试重用传递的序数值（尽管它们可以重用传递的
        /// 数组）。 如果有任何问题，那么服务器实现会抛出异常。 如果发生这种情况，
        /// 客户端不应该对序数值的状态做任何假设。
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        IList<Coordinate> TransformList(IList<Coordinate> points);

        /// <summary>
        /// 逆变换
        /// </summary>
        void Invert();

        /// <summary>
        /// 变换坐标序列。 输入坐标序列保持不变。
        /// </summary>
        /// <param name="coordinateSequence">要转换的坐标序列。</param>
        /// <returns>变换的坐标序列。</returns>
        ICoordinateSequence Transform(ICoordinateSequence coordinateSequence);
    }
}
