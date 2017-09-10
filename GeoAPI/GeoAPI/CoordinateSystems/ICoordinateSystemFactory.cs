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

namespace GeoAPI.CoordinateSystems
{
    /// <summary>
    /// �Ӽ򵥵Ķ����ֵ�������ӵĶ���
    /// </summary>
    /// <remarks>
    /// <para>ICoordinateSystemFactory����Ӧ�ó�������������
    /// <see cref =��ICoordinateSystemAuthorityFactory��/>����������ϵ�� ��������ǳ�
    /// ����Ȩ���Ĺ���������ʹ�á�</para>
    /// <para>����<see cref =��ICoordinateSystemAuthorityFactory��/>��������������׼��
    /// ����ϵ����<see cref =��ICoordinateSystemFactory��/>���������������⡱����ϵ��
    /// </para>
    /// <para>���磬EPSGȨ������ӵ��ʹ��NAD83��׼����������ƽ������ϵ�Ĵ��룬����Щ
    /// ����ϵͳʼ��ʹ���ס� EPSGû��ʹ��Ӣ�ߵ�λ��NAD83״̬ƽ������ϵ�Ĵ��롣 �ù���
    /// ����Ӧ�ó��򴴽������Ļ������ϵ��</para>
    /// </remarks>
    public interface ICoordinateSystemFactory
    {
        /// <summary>
        /// ����һ��<see cref =��ICompoundCoordinateSystem��/>��
        /// </summary>
        /// <param name="name">��������ϵ�����ơ�</param>
        /// <param name="head">ͷ����ϵ</param>
        /// <param name="tail">β����ϵ</param>
        /// <returns>��������ϵ</returns>
        ICompoundCoordinateSystem CreateCompoundCoordinateSystem(string name, ICoordinateSystem head, ICoordinateSystem tail);

        /// <summary>
        /// �Ӱ뾶ֵ����һ��<see cref =��IEllipsoid��/>��
        /// </summary>
        /// <seealso cref="CreateFlattenedSphere"/>
        /// <param name="name">��Բ������</param>
        /// <param name="semiMajorAxis"></param>
        /// <param name="semiMinorAxis"></param>
        /// <param name="linearUnit"></param>
        /// <returns>����</returns>
        IEllipsoid CreateEllipsoid(string name, double semiMajorAxis, double semiMinorAxis, ILinearUnit linearUnit);

        /// <summary>
        /// ����<see cref="IFittedCoordinateSystem"/>.
        /// </summary>
        /// <remarks>�������ϵ����ĵ�λ���ӻ�������ϵ�ĵ�λ�ƶϳ����� �������ӳ��
        /// ִ����ת�����κλ������������ͬ�ĵ�λ�� ���磬��lat_deg��lon_deg��
        /// height_feet��ϵͳ�����ڣ�lat��lon��ƽ������ת����Ϊ������Ӱ����ᶼ�Ƕ�����
        ///  ������Ӧ�����κ�����ƽ������ת������ϵ��</remarks>
        /// <param name="name">����ϵ����</param>
        /// <param name="baseCoordinateSystem">��������ϵ</param>
        /// <param name="toBaseWkt"></param>
        /// <param name="arAxes"></param>
        /// <returns>��������ϵ</returns>
        IFittedCoordinateSystem CreateFittedCoordinateSystem(string name, ICoordinateSystem baseCoordinateSystem, string toBaseWkt, List<AxisInfo> arAxes);

        /// <summary>
        /// ���� <see cref="IEllipsoid"/> ��һ����뾶����ƽ̹����
        /// </summary>
        /// <seealso cref="CreateEllipsoid"/>
        /// <param name="name">��Բ������</param>
        /// <param name="semiMajorAxis">������</param>
        /// <param name="inverseFlattening">��ƽ��</param>
        /// <param name="linearUnit">���Ե�λ</param>
        /// <returns>����</returns>
        IEllipsoid CreateFlattenedSphere(string name, double semiMajorAxis, double inverseFlattening, ILinearUnit linearUnit);


        /// <summary>
        /// ��XML�ַ�����������ϵ����
        /// </summary>
        /// <param name="xml">�ռ�������XML��ʾ</param>
        /// <returns>�����Ŀռ���������</returns>
        ICoordinateSystem CreateFromXml(string xml);

        /// <summary>
        /// ������������֪���ı���ʾ������һ���ռ�ο����� ������������
        /// <see cref =��IGeographicCoordinateSystem��/>��
        /// <see cref =��IProjectedCoordinateSystem��/>��
        /// </summary>
        /// <param name="WKT">���ڿռ�ο���������֪���ı���ʾ</param>
        /// <returns>The resulting spatial reference object</returns>
        ICoordinateSystem CreateFromWkt(string WKT);

        /// <summary>
        /// ����һ��<see cref =��IGeographicCoordinateSystem��/>��������Lat / Lon��Lon / Lat��
        /// </summary>
        /// <param name="name">��������ϵ������</param>
        /// <param name="angularUnit">�Ƕȵ�λ</param>
        /// <param name="datum">ˮƽ��׼</param>
        /// <param name="primeMeridian">����������</param>
        /// <param name="axis0">��һ��</param>
        /// <param name="axis1">�ڶ���</param>
        /// <returns>��������ϵ</returns>
        IGeographicCoordinateSystem CreateGeographicCoordinateSystem(string name, IAngularUnit angularUnit, IHorizontalDatum datum, IPrimeMeridian primeMeridian, AxisInfo axis0, AxisInfo axis1);

        /// <summary>
        /// ����Բ���Bursa-World��������<see cref =��IHorizontalDatum��/>��
        /// </summary>
        /// <remarks>
        /// ���ڴ˷�������һ��Bursa-Wolf��������˴��������ݽ�ʼ����WGS84�й�ϵ�� 
        /// ���Ҫ����һ����WGS84�޹ص�ˮƽ��׼�������ָ��<see cref =��DatumType��>
        ///  horizontalDatumType </see> <see cref =��DatumType.HD_Other��/>����ͨ��
        /// WKT��������
        /// </remarks>
        /// <param name="name">��Բ������</param>
        /// <param name="datumType">��׼����</param>
        /// <param name="ellipsoid">����</param>
        /// <param name="toWgs84">Wgs84ת������</param>
        /// <returns>ˮƽ��׼</returns>
        IHorizontalDatum CreateHorizontalDatum(string name, DatumType datumType, IEllipsoid ellipsoid, Wgs84ConversionInfo toWgs84);

        /// <summary>
        /// ����һ��<see cref =��ILocalCoordinateSystem��>�ֲ�����ϵ</ see>��
        /// </summary>
        /// <remarks>
        /// �ֲ�����ϵ�ĳߴ��������еĴ�Сȷ���� �����Ὣ������ͬ�ĵ�λ�����Ҫʹ��
        /// ��ϵ�λ��������ϵ�������ʹ�ò�ͬ�ľֲ�����ϵ���и�������ϵ��
        /// </remarks>
        /// <param name="name">�ֲ�����ϵ������</param>
        /// <param name="datum">��������</param>
        /// <param name="unit">��λ</param>
        /// <param name="axes">����Ϣ</param>
        /// <returns>�ֲ�����ϵ</returns>
        ILocalCoordinateSystem CreateLocalCoordinateSystem(string name, ILocalDatum datum, IUnit unit, List<AxisInfo> axes);

        /// <summary>
        /// ����һ��<see cref =��ILocalDatum��/>��
        /// </summary>
        /// <param name="name">��׼����</param>
        /// <param name="datumType">��׼����</param>
        /// <returns></returns>
        ILocalDatum CreateLocalDatum(string name, DatumType datumType);

        /// <summary>
        /// ����ڸ������Σ�����һ��<see cref =��IPrimeMeridian��/>��
        /// </summary>
        /// <param name="name">ԭ����������</param>
        /// <param name="angularUnit">�Ƕȵ�λ</param>
        /// <param name="longitude">����</param>
        /// <returns>����������</returns>
        IPrimeMeridian CreatePrimeMeridian(string name, IAngularUnit angularUnit, double longitude);

        /// <summary>
        /// ʹ��ͶӰ���󴴽�<see cref =��IProjectedCoordinateSystem��/>��
        /// </summary>
        /// <param name="name">ͶӰ����ϵ������</param>
        /// <param name="gcs">��������ϵ</param>
        /// <param name="projection">ͶӰ</param>
        /// <param name="linearUnit">���Ե�λ</param>
        /// <param name="axis0">����</param>
        /// <param name="axis1">����</param>
        /// <returns>ͶӰ����ϵ</returns>
        IProjectedCoordinateSystem CreateProjectedCoordinateSystem(string name, IGeographicCoordinateSystem gcs, IProjection projection, ILinearUnit linearUnit, AxisInfo axis0, AxisInfo axis1);

        /// <summary>
        /// ����һ��<see cref =��IProjection��/>��
        /// </summary>
        /// <param name="name">ͶӰ����</param>
        /// <param name="wktProjectionClass">ͶӰ��</param>
        /// <param name="Parameters">ͶӰ����</param>
        /// <returns>ͶӰ</returns>
        IProjection CreateProjection(string name, string wktProjectionClass, List<ProjectionParameter> Parameters);

        /// <summary>
        /// ��<see cref =��IVerticalDatum��>��׼</ see>��<see cref =��ILinearUnit��>���Ե�λ</ see>����<see cref =��IVerticalCoordinateSystem��/>��
        /// </summary>
        /// <param name="name">��ֱ����ϵ������</param>
        /// <param name="datum">��ֱ��׼</param>
        /// <param name="verticalUnit">��Ԫ</param>
        /// <param name="axis">����Ϣ</param>
        /// <returns>��ֱ����ϵ</returns>
        IVerticalCoordinateSystem CreateVerticalCoordinateSystem(string name, IVerticalDatum datum, ILinearUnit verticalUnit, AxisInfo axis);

        /// <summary>
        /// ��ö������ֵ����һ��<see cref =��IVerticalDatum��/>��
        /// </summary>
        /// <param name="name">��׼����</param>
        /// <param name="datumType">��׼����</param>
        /// <returns>��ֱ��׼</returns>	
        IVerticalDatum CreateVerticalDatum(string name, DatumType datumType);
    }
}
