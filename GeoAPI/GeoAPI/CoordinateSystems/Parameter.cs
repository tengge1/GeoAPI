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

namespace GeoAPI.CoordinateSystems
{
    /// <summary>
    /// 命名参数值。
    /// </summary>
    [Serializable]
    public class Parameter
    {
        /// <summary>
        /// 创建参数的实例
        /// </summary>
        /// <remarks>单位始终为米或度。</remarks>
        /// <param name="name">参数名称</param>
        /// <param name="value">值</param>
        public Parameter(string name, double value)
        {
            _Name = name;
            _Value = value;
        }

        private string _Name;

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private double _Value;

        /// <summary>
        /// 参数值
        /// </summary>
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}
