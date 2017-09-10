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
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace GeoAPI.CoordinateSystems.Transformations
{
    /// <summary>
    /// ת����ά����㡣
    /// </summary>
    /// <remarks>
    /// ����ͻ�Ӧ�ó���ϣ����ѯת����Դ��Ŀ������ϵ����Ӧ����<see cref =��ICoordinateTransformation��/>�ӿڣ�����ֻҪϣ��ִ��ת����ʹ�ð�������ѧ�任����
    /// </remarks>
    public interface IMathTransform
    {
        /// <summary>
        /// ��ȡ������ά����
        /// </summary>
        int DimSource { get; }

        /// <summary>
        /// ��ȡ������ά����
        /// </summary>
        int DimTarget { get; }

        /// <summary>
        /// ��������任�Ƿ��ƶ��κε㡣
        /// </summary>
        /// <returns></returns>
        bool Identity();

        /// <summary>
        /// ��ȡ��������һ���ܺõ��ı���ʾ��
        /// </summary>
        string WKT { get; }

        /// <summary>
        /// ��ȡ�˶����XML��ʾ��
        /// </summary>
        string XML { get; }

        /// <summary>
        /// ��ĳһ���ô˱任�ĵ����� ���ת���ڸõ�û����ȷ����ĵ�����
        /// ��ú���Ӧ����ͨ����DCP��ʽʧ�ܡ� �õ����Ǹõ��Ͻ��Ʒ���ӳ��
        /// �ķ�ת�����ֵľ��� ���󽫾��ж�Ӧ��Դ��Ŀ������ϵ�ĳߴ硣 
        /// �������ά��ΪM�����ά��ΪN�������Ĵ�СΪ[M] [N]�� ����
        /// {elt [n] [m]��n = 0 ..��N-1��}��Ԫ��������ռ����γ����m����
        /// �����С�仯�����λ��ƽ�е����� ������ռ䡣
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        double[,] Derivative(double[] point);

        /// <summary>
        /// ��ñ��ε�͹����
        /// </summary>
        /// <remarks>
        /// <para>���ṩ�������걻����Ϊһϵ�е㣬����Դ�ռ�������͹����
        /// ���ص��������ʾ����ռ��е�͹���� ����������ͨ���������
        /// ��������ͬ�� ÿ�������Ӧ������Ч�����ڣ�����ͨ���������Ե��
        /// ��������飩�� ���ǣ�������͹�����ܻᳬ����Ч�� ���ص�
        /// ͹��Ӧ�ð���Դ͹����Դ��Ľ����ı任ͼ��</para>
        /// <para>͹��������ϵ�е�һ����״���������λ��A��B����״���ڲ���
        /// ��ô��A��B֮���ֱ���е�����λ��Ҳ������״�ڡ� ������3D�У���
        /// ��������嶼��͹���� ͹����������̫���Ե�������ֱ�ߺ͵��㡣 
        /// ��������͹������Ϊλ��A��B���붼��ͬ - ���㱾�����A��B֮���
        /// ֱ�ߵĳ���Ϊ�㣩</para>
        /// <para>����͹������״��һЩ����������Ȧ����������</para>
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        List<double> GetCodomainConvexHull(List<double> points);

        /// <summary>
        /// ��ȡ��͹���з������ı�־��
        /// </summary>
        /// <remarks>
        /// ���ṩ�������걻����Ϊһϵ�е㣬����Դ�ռ�������͹���� �ڸ����ϣ�
        /// Ȼ�����Դ�����͹���е�ÿ����ͨ�������޵ģ��㡣 Ȼ�����������Щ
        /// ���Եı�־�� ��ʵ���У���ͬת����ʵ�ֽ�ʹ�ò�ͬ�Ŀ�ݷ�ʽ��������
        /// �޴εĲ��ԡ�
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        DomainFlags GetDomainFlags(List<double> points);

        /// <summary>
        /// �����˶������任��
        /// </summary>
        /// <remarks>���ת������һ��һ�ģ���˷������ܻ�ʧ�ܡ� Ȼ�������е�
        /// ��ͼͶӰ��Ӧ�óɹ���</remarks>
        /// <returns></returns>
        IMathTransform Inverse();

        /// <summary>
        /// ת������㡣 ���ݵĲ����㲻Ӧ�ñ��޸ġ�
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        double[] Transform(double[] point);

        /// <summary>
        /// ת��һ�����ꡣ �������걣�ֲ��䡣
        /// </summary>
        /// <param name="coordinate">Ҫת��������</param>
        /// <returns>�任������</returns>
        [Obsolete("Use Coordinate Transform(Coordinate coordinate) instead.")]
        ICoordinate Transform(ICoordinate coordinate);

        /// <summary>
        /// ת��һ�����ꡣ �������걣�ֲ��䡣
        /// </summary>
        /// <param name="coordinate">Ҫת��������</param>
        /// <returns>�任������</returns>
        Coordinate Transform(Coordinate coordinate);

        /// <summary>
        /// ת�����������ֵ�б�
        /// </summary>
        /// <remarks>
        /// �ṩ�����ַ�������Ч��ת�����㡣 �ṩ������ֵ���齫����ѹ��
        /// ������ֵ�� ���磬���Դά��Ϊ3����ô�������˳��x0��y0��z0��
        /// x1��y1��z1 ...����������� ���ݵ�����Ĵ�С������DimSource��
        /// �������� ���ص�����ֵ�����Ƶķ�ʽ����� ��һЩDCP�� ����ԭλת
        /// �����������ҷ��ص���������봫�ݵ�������ͬ��
        /// �����κοͻ��˴��붼��Ӧ�ó������ô��ݵ�����ֵ���������ǿ���
        /// ���ô��ݵ����飩�� ������κ����⣬��ô������ʵ�ֻ��׳��쳣�� 
        /// �����������������ͻ��˲�Ӧ�ö�����ֵ��״̬���κμ��衣
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        IList<double[]> TransformList(IList<double[]> points);

        /// <summary>
        /// ת�������б�
        /// </summary>
        /// <remarks>
        /// �ṩ�����ַ�������Ч��ת�����㡣 �ṩ������ֵ���齫����ѹ��������ֵ�� 
        /// ���磬���Դά��Ϊ3����ô�������˳��x0��y0��z0��x1��y1��z1 ...�����
        /// ���������ݵ�����Ĵ�С������DimSource�������������ص�����ֵ�����Ƶķ�ʽ
        /// ����� ��һЩDCP�� ����ԭλת�����������ҷ��ص���������봫�ݵ�������ͬ��
        /// �����κοͻ��˴��붼��Ӧ�ó������ô��ݵ�����ֵ���������ǿ������ô��ݵ�
        /// ���飩�� ������κ����⣬��ô������ʵ�ֻ��׳��쳣�� ����������������
        /// �ͻ��˲�Ӧ�ö�����ֵ��״̬���κμ��衣
        /// </remarks>
        /// <param name="points"></param>
        /// <returns></returns>
        IList<Coordinate> TransformList(IList<Coordinate> points);

        /// <summary>
        /// ��任
        /// </summary>
        void Invert();

        /// <summary>
        /// �任�������С� �����������б��ֲ��䡣
        /// </summary>
        /// <param name="coordinateSequence">Ҫת�����������С�</param>
        /// <returns>�任���������С�</returns>
        ICoordinateSequence Transform(ICoordinateSequence coordinateSequence);
    }
}
