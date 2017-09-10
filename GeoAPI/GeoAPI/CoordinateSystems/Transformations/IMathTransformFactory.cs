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

using System.Collections.Generic;

namespace GeoAPI.CoordinateSystems.Transformations
{
    /// <summary>
    /// 创建数学变换。
    /// </summary>
    /// <remarks>
    /// <para>CT_MathTransformFactory是一个用于创建CT_MathTransform对象的低级
    /// 工厂。 许多高级GIS应用程序永远不需要直接使用CT_MathTransformFactory; 
    /// 他们可以使用CT_CoordinateTransformationFactory。 但是，
    /// CT_MathTransformFactory接口是在这里指定的，因为它可以直接用于希望转换
    /// 其他类型坐标（例如颜色坐标或图像像素坐标）的应用程序。</para>
    /// <para>以下注释假设相同的供应商实现了数学转换工厂接口和数学变换接口。</para>
    /// <para>数学变换是一个实际执行公式来协调值的工作的对象。 数学变换不知道
    /// 或关心坐标如何与现实世界中的位置相关。 这种缺乏语义使得实现
    /// CT_MathTransformFactory比其他方式更容易。</para>
    /// <para>例如CT_MathTransformFactory可以创建仿射数学变换。 仿射变换将矩阵
    /// 应用于坐标，而不知道它在做什么与现实世界有关。 因此，如果矩阵将Z值缩小
    /// 到1000倍，那么可以将米变换成毫米，或者将公里转换成米。</para>
    /// <para>因为数学变换具有较低的语义价值（但数学价值高），对于GIS应用程序如何
    /// 使用坐标系，或者这些坐标系如何与现实世界有关的程序员来说，可以实现
    /// CT_MathTransformFactory。</para>
    /// <para>数学变换的低语义内容也意味着它们对于与GIS坐标无关的应用程序将是有用
    /// 的。 例如，数学变换可用于映射不同颜色空间之间的颜色坐标，例如将（红色，
    /// 绿色，蓝色）颜色转换为（色调，亮度，饱和度）颜色。</para>
    /// <para>由于数学变换不知道其源和目标坐标系是什么意思，因此数学变换对象不必要
    /// 或希望保留其源和目标坐标系统上的信息。</para>
    /// </remarks>
    public interface IMathTransformFactory
    {
        /// <summary>
        /// 从矩阵创建仿射变换。
        /// </summary>
        /// <remarks>如果变换的输入维数为M，输出维数为N，则矩阵的大小为
        /// [N + 1] [M + 1]。 矩阵维数中的+1可以让矩阵进行移位以及旋转。 
        /// 矩阵的[M] [j]元素将是移动原点的第j个纵坐标。 对于i小于M，
        /// 矩阵的[i] [N]元素将为0，对于i，矩阵的[i]元素将为0，等于M.</remarks>
        /// <param name="matrix"></param>
        /// <returns></returns>
        IMathTransform CreateAffineTransform(double[,] matrix);

        /// <summary>
        /// 通过连接两个现有的转换来创建变换。 连接变换的作用方式与应用两个
        /// 变换相同。
        /// </summary>
        /// <remarks>第一个变换的输出空间的维度必须与第二个变换中的输入空间的
        /// 维度相匹配。 如果你想连接两个以上的变换，那么你可以反复使用这个
        /// 方法。</remarks>
        /// <param name="transform1"></param>
        /// <param name="transform2"></param>
        /// <returns></returns>
        IMathTransform CreateConcatenatedTransform(IMathTransform transform1, IMathTransform transform2);

        /// <summary>
        /// 创建一个已知文本字符串的数学变换。
        /// </summary>
        /// <param name="wkt"></param>
        /// <returns></returns>
        IMathTransform CreateFromWKT(string wkt);

        /// <summary>
        /// 从XML创建数学变换。
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        IMathTransform CreateFromXML(string xml);

        /// <summary>
        /// 从分类名称和参数创建变换。
        /// </summary>
        /// <remarks>
        /// 客户端必须确保所有线性参数以米为单位表示，所有角参数均以度数表示。 
        /// 此外，它们必须为制图投影变换提供“半主要”和“半最小”参数。
        /// </remarks>
        /// <param name="classification"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IMathTransform CreateParameterizedTransform(string classification, List<Parameter> parameters);

        /// <summary>
        /// 创建通过一个纵坐标子集到另一个变换的变换。
        /// </summary>
        /// <remarks>
        /// 这允许变换在纵坐标子集上操作。 例如，如果您有（Lat，Lon，Height）
        /// 坐标，则可能希望将高度值从米转换为英尺，而不会影响（纬度，Lon）值。 
        /// 如果要影响（Lat，Lon）值并单独保留Height值，则必须将坐标交替到
        /// （Height，Lat，Lon）。 你可以用仿射映射来做到这一点。
        /// </remarks>
        /// <param name="firstAffectedOrdinate"></param>
        /// <param name="subTransform"></param>
        /// <returns></returns>
        IMathTransform CreatePassThroughTransform(int firstAffectedOrdinate, IMathTransform subTransform);

        /// <summary>
        /// 测试参数是否有角度。 客户必须确保所有角度参数值都以度为单位。
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        bool IsParameterAngular(string parameterName);

        /// <summary>
        /// 测试参数是否为线性。 客户必须确保所有线性参数值以米为单位。
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        bool IsParameterLinear(string parameterName);
    }
}