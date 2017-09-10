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
    /// �᷽�� һЩ����ϵʹ�÷Ǳ�׼���� ���磬�Ϸǵ����ĵ�һ��ͨ��ָ������������
    /// ���� �����Ϣ�뽫�Ϸ���������ת��Ϊ��γ�ȵ��㷨��Ȼ��ء�
    /// </summary>
    public enum AxisOrientationEnum : short
    {
        /// <summary>
        /// δ֪��δָ�����᷽�� ��������ڱ��ػ���ϵ�����ϵ��
        /// </summary>
        Other = 0,

        /// <summary>
        /// ����������ֵ�򱱡� ��ͨ������Grid Y�����γ�ȡ�
        /// </summary>
        North = 1,

        /// <summary>
        /// ����������ֵ���ϡ� �����ʹ�á�
        /// </summary>
        South = 2,

        /// <summary>
        /// ����������ֵ�򶫡� �����ʹ�á�
        /// </summary>
        East = 3,

        /// <summary>
        /// ������������ֵ�� ��ͨ������Grid X����;��ȡ�
        /// </summary>
        West = 4,

        /// <summary>
        /// ����������ֵ������ �����ڴ�ֱ����ϵ��
        /// </summary>
        Up = 5,

        /// <summary>
        /// ����������ֵ�½��� �����ڴ�ֱ����ϵ��
        /// </summary>
        Down = 6
    }
}
