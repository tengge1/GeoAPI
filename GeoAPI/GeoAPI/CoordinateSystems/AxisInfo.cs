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
    /// 轴的细节。 这用于标记轴，并指示方向。
    /// </summary>
	[Serializable]
    public class AxisInfo
    {
        /// <summary>
        /// 初始化AxisInfo的新实例。
        /// </summary>
        /// <param name="name">轴名称</param>
        /// <param name="orientation">轴方向</param>
        public AxisInfo(string name, AxisOrientationEnum orientation)
        {
            _Name = name;
            _Orientation = orientation;
        }

        private string _Name;

        /// <summary>
        /// 可读名称。 可能的值为X，Y，Long，Lat或任何其他短字符串。
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private AxisOrientationEnum _Orientation;

        /// <summary>
        /// 获取枚举的方向值。
        /// </summary>
        public AxisOrientationEnum Orientation
        {
            get { return _Orientation; }
            set { _Orientation = value; }
        }

        /// <summary>
        /// 返回在简单特征规范中定义的该对象的知名文本。
        /// </summary>
        public string WKT
        {
            get
            {
                return String.Format("AXIS[\"{0}\", {1}]", Name, Orientation.ToString().ToUpperInvariant());
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
                    "<CS_AxisInfo Name=\"{0}\" Orientation=\"{1}\"/>", Name, Orientation.ToString()).ToUpperInvariant();
            }
        }
    }
}
