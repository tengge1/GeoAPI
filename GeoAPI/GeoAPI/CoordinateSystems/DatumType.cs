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
    /// 大地水准面模型衍生高度的垂直基准，也称为GPS导出高度。 这些高度是通过使用给定
    /// 的大地水准面波动模型（N）通过等式H = h-N由椭球高度（h）构建的正高度（H）的近
    /// 似值。
    /// </summary>
    public enum DatumType : int
    {
        /// <summary>
        /// 水平基准类型的最小可能值
        /// </summary>
        HD_Min = 1000,

        /// <summary>
        /// 未指定的水平基准类型。 使用此类型的水平基准不应使用Bursa Wolf参数向WGS84
        /// 提供转换。
        /// </summary>
        HD_Other = 1000,

        /// <summary>
        /// 这些基准点，例如ED50，NAD27和NAD83，被设计为支持椭圆体上的水平位置，而不
        /// 是3-D空间中的位置。 这些基准面主要是为了支持在有限程度的领域（如国家，地区
        /// 或大陆）中的一个位置的水平部分。
        /// </summary>
        HD_Classic = 1001,

        /// <summary>
        /// 地心学基准是全球范围内的“卫星时代”现代大地测量数据，如WGS84（用于GPS），
        /// PZ90（GLONASS中使用）和ITRF。 这些基准面被设计成支持位置的水平分量和位置的
        /// 垂直分量（通过椭圆高度）。 ITRF的区域实现，如ETRF，也包括在这一类。
        /// </summary>
        HD_Geocentric = 1002,

        /// <summary>
        /// 水平基准类型的最高值。
        /// </summary>
        HD_Max = 1999,

        /// <summary>
        /// 垂直基准类型的最低可能值。
        /// </summary>
        VD_Min = 2000,

        /// <summary>
        /// 未指定的垂直基准类型。
        /// </summary>
        VD_Other = 2000,

        /// <summary>
        /// 沿垂直线测量的正交高度的垂直基准。
        /// </summary>
        VD_Orthometric = 2001,

        /// <summary>
        /// 用于椭圆高度的垂直基准，沿水平原点定义中使用的椭圆体的法线测量。
        /// </summary>
        VD_Ellipsoidal = 2002,

        /// <summary>
        /// 大气中高度或高度的垂直基准。 这些是在气压计或气压高度计的帮助下获得的正高度
        /// 的近似值。 这些值通常以以下单位之一表示：米，英尺，毫巴（用于测量压力水平）
        /// 或θ值（用于测量位势高度的单位）。
        /// </summary>
        VD_AltitudeBarometric = 2003,

        /// <summary>
        /// 正常高度系统。
        /// </summary>
        VD_Normal = 2004,

        /// <summary>
        /// 大地水准面模型衍生高度的垂直基准，也称为GPS导出高度。 这些高度是通过使用给定
        /// 的大地水准面波动模型（N）通过等式H = h-N由椭球高度（h）构建的正高度（H）的近
        /// 似值。
        /// </summary>
        VD_GeoidModelDerived = 2005,

        /// <summary>
        /// 该属性用于支持需要在海平面以下深度测量的水文工程项目生成的基准集。 它通常被
        /// 称为水文或海洋基准。 通过使用回波探测等程序，在与地球重力场的实际等电位面垂直
        /// （大致）的方向上测量深度。
        /// </summary>
        VD_Depth = 2006,

        /// <summary>
        /// 垂直基准类型的最高可能值。
        /// </summary>
        VD_Max = 2999,

        /// <summary>
        /// 局部基准类型的最低可能值。
        /// </summary>
        LD_Min = 10000,

        /// <summary>
        /// 本地基准类型的最高可能值。
        /// </summary>
        LD_Max = 32767
    }
}
