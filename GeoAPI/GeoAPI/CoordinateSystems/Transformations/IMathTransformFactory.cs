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

using System.Collections.Generic;

namespace GeoAPI.CoordinateSystems.Transformations
{
    /// <summary>
    /// ������ѧ�任��
    /// </summary>
    /// <remarks>
    /// <para>CT_MathTransformFactory��һ�����ڴ���CT_MathTransform����ĵͼ�
    /// ������ ���߼�GISӦ�ó�����Զ����Ҫֱ��ʹ��CT_MathTransformFactory; 
    /// ���ǿ���ʹ��CT_CoordinateTransformationFactory�� ���ǣ�
    /// CT_MathTransformFactory�ӿ���������ָ���ģ���Ϊ������ֱ������ϣ��ת��
    /// �����������꣨������ɫ�����ͼ���������꣩��Ӧ�ó���</para>
    /// <para>����ע�ͼ�����ͬ�Ĺ�Ӧ��ʵ������ѧת�������ӿں���ѧ�任�ӿڡ�</para>
    /// <para>��ѧ�任��һ��ʵ��ִ�й�ʽ��Э��ֵ�Ĺ����Ķ��� ��ѧ�任��֪��
    /// ����������������ʵ�����е�λ����ء� ����ȱ������ʹ��ʵ��
    /// CT_MathTransformFactory��������ʽ�����ס�</para>
    /// <para>����CT_MathTransformFactory���Դ���������ѧ�任�� ����任������
    /// Ӧ�������꣬����֪��������ʲô����ʵ�����йء� ��ˣ��������Zֵ��С
    /// ��1000������ô���Խ��ױ任�ɺ��ף����߽�����ת�����ס�</para>
    /// <para>��Ϊ��ѧ�任���нϵ͵������ֵ������ѧ��ֵ�ߣ�������GISӦ�ó������
    /// ʹ������ϵ��������Щ����ϵ�������ʵ�����йصĳ���Ա��˵������ʵ��
    /// CT_MathTransformFactory��</para>
    /// <para>��ѧ�任�ĵ���������Ҳ��ζ�����Ƕ�����GIS�����޹ص�Ӧ�ó���������
    /// �ġ� ���磬��ѧ�任������ӳ�䲻ͬ��ɫ�ռ�֮�����ɫ���꣬���罫����ɫ��
    /// ��ɫ����ɫ����ɫת��Ϊ��ɫ�������ȣ����Ͷȣ���ɫ��</para>
    /// <para>������ѧ�任��֪����Դ��Ŀ������ϵ��ʲô��˼�������ѧ�任���󲻱�Ҫ
    /// ��ϣ��������Դ��Ŀ������ϵͳ�ϵ���Ϣ��</para>
    /// </remarks>
    public interface IMathTransformFactory
    {
        /// <summary>
        /// �Ӿ��󴴽�����任��
        /// </summary>
        /// <remarks>����任������ά��ΪM�����ά��ΪN�������Ĵ�СΪ
        /// [N + 1] [M + 1]�� ����ά���е�+1�����þ��������λ�Լ���ת�� 
        /// �����[M] [j]Ԫ�ؽ����ƶ�ԭ��ĵ�j�������ꡣ ����iС��M��
        /// �����[i] [N]Ԫ�ؽ�Ϊ0������i�������[i]Ԫ�ؽ�Ϊ0������M.</remarks>
        /// <param name="matrix"></param>
        /// <returns></returns>
        IMathTransform CreateAffineTransform(double[,] matrix);

        /// <summary>
        /// ͨ�������������е�ת���������任�� ���ӱ任�����÷�ʽ��Ӧ������
        /// �任��ͬ��
        /// </summary>
        /// <remarks>��һ���任������ռ��ά�ȱ�����ڶ����任�е�����ռ��
        /// ά����ƥ�䡣 ������������������ϵı任����ô����Է���ʹ�����
        /// ������</remarks>
        /// <param name="transform1"></param>
        /// <param name="transform2"></param>
        /// <returns></returns>
        IMathTransform CreateConcatenatedTransform(IMathTransform transform1, IMathTransform transform2);

        /// <summary>
        /// ����һ����֪�ı��ַ�������ѧ�任��
        /// </summary>
        /// <param name="wkt"></param>
        /// <returns></returns>
        IMathTransform CreateFromWKT(string wkt);

        /// <summary>
        /// ��XML������ѧ�任��
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        IMathTransform CreateFromXML(string xml);

        /// <summary>
        /// �ӷ������ƺͲ��������任��
        /// </summary>
        /// <remarks>
        /// �ͻ��˱���ȷ���������Բ�������Ϊ��λ��ʾ�����нǲ������Զ�����ʾ�� 
        /// ���⣬���Ǳ���Ϊ��ͼͶӰ�任�ṩ������Ҫ���͡�����С��������
        /// </remarks>
        /// <param name="classification"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IMathTransform CreateParameterizedTransform(string classification, List<Parameter> parameters);

        /// <summary>
        /// ����ͨ��һ���������Ӽ�����һ���任�ı任��
        /// </summary>
        /// <remarks>
        /// ������任���������Ӽ��ϲ����� ���磬������У�Lat��Lon��Height��
        /// ���꣬�����ϣ�����߶�ֵ����ת��ΪӢ�ߣ�������Ӱ�죨γ�ȣ�Lon��ֵ�� 
        /// ���ҪӰ�죨Lat��Lon��ֵ����������Heightֵ������뽫���꽻�浽
        /// ��Height��Lat��Lon���� ������÷���ӳ����������һ�㡣
        /// </remarks>
        /// <param name="firstAffectedOrdinate"></param>
        /// <param name="subTransform"></param>
        /// <returns></returns>
        IMathTransform CreatePassThroughTransform(int firstAffectedOrdinate, IMathTransform subTransform);

        /// <summary>
        /// ���Բ����Ƿ��нǶȡ� �ͻ�����ȷ�����нǶȲ���ֵ���Զ�Ϊ��λ��
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        bool IsParameterAngular(string parameterName);

        /// <summary>
        /// ���Բ����Ƿ�Ϊ���ԡ� �ͻ�����ȷ���������Բ���ֵ����Ϊ��λ��
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        bool IsParameterLinear(string parameterName);
    }
}