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
    /// ���ϸ�ڡ� �����ڱ���ᣬ��ָʾ����
    /// </summary>
	[Serializable]
    public class AxisInfo
    {
        /// <summary>
        /// ��ʼ��AxisInfo����ʵ����
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="orientation">�᷽��</param>
        public AxisInfo(string name, AxisOrientationEnum orientation)
        {
            _Name = name;
            _Orientation = orientation;
        }

        private string _Name;

        /// <summary>
        /// ���ǿɶ����ơ� ���ܵ�ֵΪX��Y��Long��Lat���κ��������ַ�����
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private AxisOrientationEnum _Orientation;

        /// <summary>
        /// ��ȡö�ٵķ���ֵ��
        /// </summary>
        public AxisOrientationEnum Orientation
        {
            get { return _Orientation; }
            set { _Orientation = value; }
        }

        /// <summary>
        /// �����ڼ������淶�ж���ĸö����֪���ı���
        /// </summary>
        public string WKT
        {
            get
            {
                return String.Format("AXIS[\"{0}\", {1}]", Name, Orientation.ToString().ToUpperInvariant());
            }
        }

        /// <summary>
        /// ��ȡ�˶����XML��ʾ
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
