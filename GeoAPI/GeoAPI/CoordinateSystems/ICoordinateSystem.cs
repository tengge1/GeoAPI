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
    /// ��������ϵ�Ļ���
    /// </summary>
    /// <remarks>
    /// <para>����ϵ��һ����ѧ�ռ䣬�ռ��Ԫ�س�Ϊλ�á� ÿ��λ���������б������� 
    /// �б�ĳ��ȶ�Ӧ������ϵ�ĳߴ硣 ��ˣ���2D����ϵ�У�ÿ��λ���ɰ���2������
    /// ���б�������</para>
    /// <para>
    /// Ȼ����������ϵ�У����������е������б��Ӧ��λ�� - һЩ�б����������ϵ��
    /// ��֮�⡣ ���磬��2D��γ������ϵ�У��б�91,91������Ӧ��λ�á�</para>
    /// <para>
    /// һЩ����ϵҲ���д���ѧ�ռ䵽��ʵ�����е�λ�õ�ӳ�䡣 �����ھ�γ������ϵ�У�
    /// ��ѧλ�ã�γ�ȣ����ȣ���Ӧ�ڵ�������ϵ�һ��λ�á� ����ѧ�ռ䵽��ʵ�����
    /// λ�õ�ӳ���Ϊ��׼��</para>
    /// </remarks>
    public interface ICoordinateSystem : IInfo
    {

        /// <summary>
        /// ����ϵ�ĳߴ硣
        /// </summary>
        int Dimension { get; }

        /// <summary>
        /// ��ȡ����ϵ�гߴ����ϸ�ڡ�
        /// </summary>
        /// <param name="dimension">�ߴ�</param>
        /// <returns>����Ϣ</returns>
        AxisInfo GetAxis(int dimension);

        /// <summary>
        /// ��ȡ����ϵ�гߴ�ĵ�λ��
        /// </summary>
        IUnit GetUnits(int dimension);

        /// <summary>
        /// ��ȡ����ϵ��Ĭ�ϰ�Χ�С�
        /// </summary>
        /// <remarks>
        /// ��ȡ����ϵ��Ĭ�ϰ�Χ�С� �н������ϵӦ�÷����������С�߽�� �޽�����ϵ
        /// Ӧ�÷���һ�������ܴ�Ŀ���ʹ�õĿ� ���磬�Զ�Ϊ��λ�ľ�γ�ȵ�������ϵӦ��
        /// �ӣ�-180��-90������180,90������һ����һ����������ϵ���Դӣ�-r��-r�� -r��
        /// ����+ r��+ r��+ r������r�ǵ���Ľ��ư뾶��
        /// </remarks>
        double[] DefaultEnvelope { get; }
    }
}
