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
    /// 一个命名的投影参数值。
    /// </summary>
    /// <remarks>
    /// 参数值的线性单位与包含的投影坐标系的线性单位相匹配。 参数值的角度单位与投影坐标系
    /// 所基于的地理坐标系的角度单位相匹配。（请注意，这不同于<see cref =“Parameter”/>，
    /// 其中单位始终为米和度。）
    /// </remarks>
    [Serializable]
    public class ProjectionParameter
    {
        /// <summary>
        /// 初始化ProjectionParameter的一个实例
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数值</param>
        public ProjectionParameter(string name, double value)
        {
            _Name = name;
            _Value = value;
        }


        private string _Name;

        /// <summary>
        /// 参数名称。
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private double _Value;

        /// <summary>
        /// 参数值。
        /// 参数值的线性单位与包含的投影坐标系的线性单位相匹配。 参数值的角度单位与投影
        /// 坐标系所基于的地理坐标系的角度单位相匹配。
        /// </summary>
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        /// <summary>
        /// 返回在简单特征规范中定义的该对象的知名文本。
        /// </summary>
        public string WKT
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture.NumberFormat, "PARAMETER[\"{0}\", {1}]", Name, Value);
            }
        }

        /// <summary>
        /// 获取此对象的XML表示
        /// </summary>
        public string XML
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture.NumberFormat, "<CS_ProjectionParameter Name=\"{0}\" Value=\"{1}\"/>", Name, Value);
            }
        }

        /// <summary>
        /// 获取此类的文本表示的功能
        /// </summary>
        /// <returns>A textual representation of this envelope</returns>
        public override string ToString()
        {
            return string.Format("ProjectionParameter '{0}': {1}", Name, Value);
        }
    }
}
