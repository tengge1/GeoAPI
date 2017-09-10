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
    /// IEllipsoid�ӿڶ���������Բ�����洢�ı�׼��Ϣ��
    /// </summary>
    public interface IEllipsoid : IInfo
    {
        /// <summary>
        /// ��ȡ�����ð볤���ֵ��
        /// </summary>
        double SemiMajorAxis { get; set; }

        /// <summary>
        /// ��ȡ�����ð�����ֵ��
        /// </summary>
        double SemiMinorAxis { get; set; }

        /// <summary>
        /// ��ȡ�����������ƽ̹�����ĵ���ֵ��
        /// </summary>
        double InverseFlattening { get; set; }

        /// <summary>
        /// ��ȡ�������ᵥλ��ֵ��
        /// </summary>
        ILinearUnit AxisUnit { get; set; }

        /// <summary>
        /// �����Բ��ķ���ƽ̹���Ƿ���ȷ�� һЩ��Բ��ʹ��IVF��Ϊ����ֵ������ѯ��ʱ����
        /// ������뾶�� ������Բ��ʹ�ü�����뾶������IVF�� ����������ڱ��⸡���������
        /// ����Ҫ��
        /// </summary>
        bool IsIvfDefinitive { get; set; }
    }
}
