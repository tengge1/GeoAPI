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

namespace GeoAPI.CoordinateSystems.Transformations
{
    /// <summary>
    /// ָʾ��͹�����ǵ���Ĳ��ֵı�־
    /// </summary>
    /// <remarks>
    /// ��Щ��־������ϡ� ���磬ֵ3��Ӧ��<see cref =��Inside��/>
    /// ��<see cref =��Outside��/>����ϣ�����ζ��͹����ĳЩ������
    /// ���ڣ�������͹������֮�⡣
    /// </remarks>
    public enum DomainFlags : int
    {
        /// <summary>
        /// ͹���е�����һ�����ڱ任�����ڡ�
        /// </summary>
        Inside = 1,

        /// <summary>
        /// ͹���е�����һ�����ڱ任��֮�⡣
        /// </summary>
        Outside = 2,

        /// <summary>
        /// ͹���е�����һ�㲻���������Ρ�
        /// </summary>
        /// <remarks>
        /// ��Ϊһ�����ӣ�����һ�������Ȼع顱�任����������������
        /// �Կ����������ߵı仯�� �����ת�Ƕ���5�ȣ����
        /// ��Lat = 175��Lon = 0�����������任����Ϊ��λ�ڽ���+ 180 / -180��
        /// �ָ�������ߡ�
        /// </remarks>
        Discontinuous = 4
    }
}
