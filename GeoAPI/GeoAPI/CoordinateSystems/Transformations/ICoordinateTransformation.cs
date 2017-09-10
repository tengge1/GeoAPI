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
    /// ��������任�� �˽ӿڽ���������任����ʵ���ϲ����Ե�
    /// ���б任������ Ҫת���㣬������ʹ����ѧ�任��
    /// </summary>
    public interface ICoordinateTransformation
    {
        /// <summary>
        /// Դ����ϵ���������ɶ�������
        /// </summary>
        string AreaOfUse { get; }

        /// <summary>
        /// ����ת���Ͳ���ֵ��Ȩ�ޡ�
        /// </summary>
        /// <remarks>
        /// �������һ��ά��Ȩ���������붨�����֯�� ���磬ŷ��ʯ�͵�����
        /// ��EPSG��ά������ϵ���ݿ�������ռ���ն�������ÿ��������һ
        /// �����š� ���磬WGS84 Lat / Lon����ϵ��EPSG�����ǣ�326��
        /// </remarks>
        string Authority { get; }

        /// <summary>
        /// ���������ʶ��ת���Ĵ��롣 ���ַ��������޴��롣
        /// </summary>
        /// <remarks>AuthorityCode���ɹ�����������������ض��ռ�ο������
        /// �����ַ����� ���磬ŷ�޵����飨EPSG����Ȩ����ʹ��32λ����������
        /// ����ϵ��������еĴ����ַ�����������λ��ɡ� WGS84 Lat / Lon��
        /// EPSG�����ǣ�326��</remarks>
        long AuthorityCode { get; }

        /// <summary>
        /// �����ѧ�任��
        /// </summary>
        IMathTransform MathTransform { get; }

        /// <summary>
        /// ת������
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ��ȡ��Ӧ���ṩ�ı�ע��
        /// </summary>
        string Remarks { get; }

        /// <summary>
        /// Դ����ϵ��
        /// </summary>
        ICoordinateSystem SourceCS { get; }

        /// <summary>
        /// Ŀ������ϵ��
        /// </summary>
        ICoordinateSystem TargetCS { get; }

        /// <summary>
        /// �������͵ı任�� ���磬��׼�任������ת����
        /// </summary>
        TransformType TransformType { get; }
    }
}
