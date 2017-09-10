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
using System.Globalization;

namespace GeoAPI.CoordinateSystems
{
    /// <summary>
    /// WGS84地理转换参数。 布尔-沃尔夫参数应适用于地心坐标，其中X轴指向本初子午线，
    /// Y轴指向东，Z轴指向北。
    /// </summary>
    /// <remarks>
    /// <para>这些参数可用于使用布尔狼变换近似从水平数据到WGS84基准的变换。 但是，
    /// 必须记住，这种转换只是近似的。 对于给定的水平基准，可以使用不同的布尔狼变换
    /// 来最小化不同区域的误差。</para>
    /// <para>如果DATUM子句包含TOWGS84子句，那么这应该是它的损失引用的变换，这通常是
    /// 在整个感兴趣区域（例如，包含的地理坐标系中的感兴趣区域）中给出广义近似的变换。
    /// </para>
    /// <para>有时，只定义前三个或六个参数。 在这种情况下，剩余的参数必须为零。 如果
    /// 只定义了三个参数，那么它们仍然可以插入到布尔-沃尔夫公式中，或者你可以选择一个捷径。
    /// 布尔-沃尔夫转型工作于地心坐标，因此您无法直接将其应用于地理坐标系。 如果只有三个
    /// 参数，那么您可以使用Molodenski或缩写的Molodenski公式。</para>
    /// <para>如果基准ToWgs84Parameters参数值为零，则接收应用程序可以假设写入应用程序
    /// 认为该数据大致等于WGS84。</para>
    /// </remarks>
    [Serializable]
    public class Wgs84ConversionInfo : IEquatable<Wgs84ConversionInfo>
    {
        private const double SEC_TO_RAD = 4.84813681109535993589914102357e-6;

        /// <summary>
        /// 使用默认参数（所有值= 0）初始化Wgs84ConversionInfo的实例
        /// </summary>
        public Wgs84ConversionInfo() : this(0, 0, 0, 0, 0, 0, 0, String.Empty) { }

        /// <summary>
        /// 初始化Wgs84ConversionInfo的一个实例
        /// </summary>
        /// <param name="dx">布尔-沃尔夫平移，以米为单位。</param>
        /// <param name="dy">布尔-沃尔夫平移，以米为单位。</param>
        /// <param name="dz">布尔-沃尔夫平移，以米为单位。</param>
        /// <param name="ex">布尔-沃尔夫旋转，以弧度为单位。</param>
        /// <param name="ey">布尔-沃尔夫旋转，以弧度为单位。</param>
        /// <param name="ez">布尔-沃尔夫旋转，以弧度为单位。</param>
        /// <param name="ppm">布尔-沃尔夫缩放，以百万分之一为单位。</param>
        public Wgs84ConversionInfo(double dx, double dy, double dz, double ex, double ey, double ez, double ppm)
            : this(dx, dy, dz, ex, ey, ez, ppm, String.Empty)
        { }

        /// <summary>
        /// 初始化Wgs84ConversionInfo的一个实例
        /// </summary>
        /// <param name="dx">布尔-沃尔夫平移，以米为单位。</param>
        /// <param name="dy">布尔-沃尔夫平移，以米为单位。</param>
        /// <param name="dz">布尔-沃尔夫平移，以米为单位。</param>
        /// <param name="ex">布尔-沃尔夫旋转，以弧度为单位。</param>
        /// <param name="ey">布尔-沃尔夫旋转，以弧度为单位。</param>
        /// <param name="ez">布尔-沃尔夫旋转，以弧度为单位。</param>
        /// <param name="ppm">布尔-沃尔夫缩放，以百万分之一为单位。</param>
        /// <param name="areaOfUse">这种变换的使用区域</param>
        public Wgs84ConversionInfo(double dx, double dy, double dz, double ex, double ey, double ez, double ppm, string areaOfUse)
        {
            Dx = dx; Dy = dy; Dz = dz;
            Ex = ex; Ey = ey; Ez = ez;
            Ppm = ppm;
            AreaOfUse = areaOfUse;
        }

        /// <summary>
        /// 布尔-沃尔夫平移，以米为单位。
        /// </summary>
        public double Dx;

        /// <summary>
        /// 布尔-沃尔夫平移，以米为单位。
        /// </summary>
        public double Dy;

        /// <summary>
        /// 布尔-沃尔夫平移，以米为单位。
        /// </summary>
        public double Dz;

        /// <summary>
        /// 布尔-沃尔夫旋转，以弧度为单位。
        /// </summary>
        public double Ex;

        /// <summary>
        /// 布尔-沃尔夫旋转，以弧度为单位。
        /// </summary>
        public double Ey;

        /// <summary>
        /// 布尔-沃尔夫旋转，以弧度为单位。
        /// </summary>
        public double Ez;

        /// <summary>
        /// 布尔-沃尔夫缩放，以百万分之一为单位。
        /// </summary>
        public double Ppm;

        /// <summary>
        /// 描述转换区域的人类可读文本。
        /// </summary>
        public string AreaOfUse;

        /// <summary>
        /// 仿射布尔 - 沃尔夫矩阵变换
        /// </summary>
        /// <remarks>
        /// <para>坐标从一个地理坐标系转换为另一个地理坐标系（通常被称为“基准变换”）
        /// 通常作为三个变换的隐含连接进行：</para>
        /// <para>[地理到地心>>地心到地心]地心到地理</para>
        /// <para>
        /// 连续变换的中间部分，从地心到地心，通常被描述为简单的7参数赫尔默特变换，以
        /// 矩阵形式表示，具有7个参数，称为“布尔 - 沃尔夫”公式：<br/>
        /// <code>
        ///  S = 1 + Ppm/1000000
        ///  [ Xt ]    [     S   -Ez*S   +Ey*S   Dx ]  [ Xs ]
        ///  [ Yt ]  = [ +Ez*S       S   -Ex*S   Dy ]  [ Ys ]
        ///  [ Zt ]    [ -Ey*S   +Ex*S       S   Dz ]  [ Zs ]
        ///  [ 1  ]    [     0       0       0    1 ]  [ 1  ]
        /// </code><br/>
        /// 这些参数通常指的是定义从源坐标系到目标坐标系的变换，其中（XS，YS，ZS）是
        /// 源地心坐标系中点的坐标，（XT，YT，ZT）是 目标地心坐标系中点的坐标。 但是
        /// 这并不能唯一地定义参数。 通常认为公式中隐含的参数的定义也不是这样。 然而，
        /// 与“位置向量变换”惯例相一致的以下定义是常用的勘察实践：
        /// </para>	
        /// <para>（dX，dY，dZ）：平移向量，被添加到源坐标系中的点位置向量，以便从源系统转换为目标系统; 也是：目标坐标系中源坐标系原点的坐标</para>
        /// <para>（RX，RY，RZ）：要应用于点矢量的旋转。 符号约定使得当从该轴的正方向从
        /// 笛卡尔坐标系的原点观察时，围绕轴的正旋转被定义为位置矢量的顺时针旋转;
        /// 例如 仅从源系统到目标系统的Z轴的正旋转将导致目标系统中的点的较大经度值。 尽管
        /// 旋转角度可以以任何角度测量单位引用，但如此处给出的公式要求以弧度提供角度。</para>
        /// <para>: 对源坐标系中的位置矢量进行刻度校正，以便在目标坐标系中获得正确的刻度。
        ///  M =（1 + dS * 10-6），其中dS是以百万分之几表示的刻度校正。</para>
        /// <para><see href="http://www.posc.org/Epicentre.2_2/DataModel/ExamplesofUsage/eu_cs35.html"/> 来解释布尔-沃尔夫转换</para>
        /// </remarks>
        /// <returns></returns>
        public double[] GetAffineTransform()
        {
            double RS = 1 + Ppm * 0.000001;
            return new double[7] { RS, Ex * SEC_TO_RAD * RS, Ey * SEC_TO_RAD * RS, Ez * SEC_TO_RAD * RS, Dx, Dy, Dz };
            /*return new double[3,4] {
                { RS,				-Ez*SEC_TO_RAD*RS,	+Ey*SEC_TO_RAD*RS,	Dx} ,
                { Ez*SEC_TO_RAD*RS,	RS,					-Ex*SEC_TO_RAD*RS,	Dy} ,
                { -Ey*SEC_TO_RAD*RS,Ex*SEC_TO_RAD*RS,	RS,					Dz}
            };*/
        }

        /// <summary>
        /// 返回此对象的Well Known Text（WKT）。
        /// </summary>
        /// <remarks>该对象的WKT格式为：
        /// <code> TOWGS84 [dx，dy，dz，ex，ey，ez，ppm] </ code>
        /// </remarks>
        /// <returns>WKT表示</returns>
        public string WKT
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture.NumberFormat,
                    "TOWGS84[{0}, {1}, {2}, {3}, {4}, {5}, {6}]",
                    Dx, Dy, Dz, Ex, Ey, Ez, Ppm);
            }
        }

        /// <summary>
        /// 获取此对象的XML表示
        /// </summary>
        public string XML
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture.NumberFormat,
                    "<CS_WGS84ConversionInfo Dx=\"{0}\" Dy=\"{1}\" Dz=\"{2}\" Ex=\"{3}\" Ey=\"{4}\" Ez=\"{5}\" Ppm=\"{6}\" />",
                    Dx, Dy, Dz, Ex, Ey, Ez, Ppm);
            }
        }

        /// <summary>
        /// 返回此对象的Well Known Text（WKT）。
        /// </summary>
        /// <remarks>该对象的WKT格式为：
        /// <code> TOWGS84 [dx，dy，dz，ex，ey，ez，ppm] </ code>
        /// </remarks>
        /// <returns>WKT表示</returns>
        public override string ToString()
        {
            return WKT;
        }

        /// <summary>
        /// 所有7个参数值的返回值为0.0
        /// </summary>
        /// <returns></returns>
        public bool HasZeroValuesOnly
        {
            get
            {
                return !(Dx != 0 || Dy != 0 || Dz != 0 || Ex != 0 || Ey != 0 || Ez != 0 || Ppm != 0);
            }
        }

        /// <summary>
        /// 指示当前对象是否等于同一类型的另一个对象。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Wgs84ConversionInfo);
        }

        /// <summary>
        /// 返回指定对象的哈希码
        /// </summary>
        /// <returns>指定对象的哈希码</returns>
        public override int GetHashCode()
        {
            return Dx.GetHashCode() ^ Dy.GetHashCode() ^ Dz.GetHashCode() ^
                Ex.GetHashCode() ^ Ey.GetHashCode() ^ Ez.GetHashCode() ^
                Ppm.GetHashCode();
        }

        /// <summary>
        /// 检查此实例的值是否等于另一个实例的值。 仅用于坐标系的参数用于比较。名称，
        /// 缩写，权限，别名和备注在比较中被忽略。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if equal</returns>
        public bool Equals(Wgs84ConversionInfo obj)
        {
            if (obj == null)
                return false;
            return obj.Dx == this.Dx && obj.Dy == this.Dy && obj.Dz == this.Dz &&
                obj.Ex == this.Ex && obj.Ey == this.Ey && obj.Ez == this.Ez && obj.Ppm == this.Ppm;
        }
    }
}

