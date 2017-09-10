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
    /// һ��������ͶӰ����ֵ��
    /// </summary>
    /// <remarks>
    /// ����ֵ�����Ե�λ�������ͶӰ����ϵ�����Ե�λ��ƥ�䡣 ����ֵ�ĽǶȵ�λ��ͶӰ����ϵ
    /// �����ڵĵ�������ϵ�ĽǶȵ�λ��ƥ�䡣����ע�⣬�ⲻͬ��<see cref =��Parameter��/>��
    /// ���е�λʼ��Ϊ�׺Ͷȡ���
    /// </remarks>
    [Serializable]
    public class ProjectionParameter
    {
        /// <summary>
        /// ��ʼ��ProjectionParameter��һ��ʵ��
        /// </summary>
        /// <param name="name">��������</param>
        /// <param name="value">����ֵ</param>
        public ProjectionParameter(string name, double value)
        {
            _Name = name;
            _Value = value;
        }


        private string _Name;

        /// <summary>
        /// �������ơ�
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private double _Value;

        /// <summary>
        /// ����ֵ��
        /// ����ֵ�����Ե�λ�������ͶӰ����ϵ�����Ե�λ��ƥ�䡣 ����ֵ�ĽǶȵ�λ��ͶӰ
        /// ����ϵ�����ڵĵ�������ϵ�ĽǶȵ�λ��ƥ�䡣
        /// </summary>
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        /// <summary>
        /// �����ڼ������淶�ж���ĸö����֪���ı���
        /// </summary>
        public string WKT
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture.NumberFormat, "PARAMETER[\"{0}\", {1}]", Name, Value);
            }
        }

        /// <summary>
        /// ��ȡ�˶����XML��ʾ
        /// </summary>
        public string XML
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture.NumberFormat, "<CS_ProjectionParameter Name=\"{0}\" Value=\"{1}\"/>", Name, Value);
            }
        }

        /// <summary>
        /// ��ȡ������ı���ʾ�Ĺ���
        /// </summary>
        /// <returns>A textual representation of this envelope</returns>
        public override string ToString()
        {
            return string.Format("ProjectionParameter '{0}': {1}", Name, Value);
        }
    }
}
