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
    /// ���ˮ׼��ģ�������߶ȵĴ�ֱ��׼��Ҳ��ΪGPS�����߶ȡ� ��Щ�߶���ͨ��ʹ�ø���
    /// �Ĵ��ˮ׼�沨��ģ�ͣ�N��ͨ����ʽH = h-N������߶ȣ�h�����������߶ȣ�H���Ľ�
    /// ��ֵ��
    /// </summary>
    public enum DatumType : int
    {
        /// <summary>
        /// ˮƽ��׼���͵���С����ֵ
        /// </summary>
        HD_Min = 1000,

        /// <summary>
        /// δָ����ˮƽ��׼���͡� ʹ�ô����͵�ˮƽ��׼��Ӧʹ��Bursa Wolf������WGS84
        /// �ṩת����
        /// </summary>
        HD_Other = 1000,

        /// <summary>
        /// ��Щ��׼�㣬����ED50��NAD27��NAD83�������Ϊ֧����Բ���ϵ�ˮƽλ�ã�����
        /// ��3-D�ռ��е�λ�á� ��Щ��׼����Ҫ��Ϊ��֧�������޳̶ȵ���������ң�����
        /// ���½���е�һ��λ�õ�ˮƽ���֡�
        /// </summary>
        HD_Classic = 1001,

        /// <summary>
        /// ����ѧ��׼��ȫ��Χ�ڵġ�����ʱ�����ִ���ز������ݣ���WGS84������GPS����
        /// PZ90��GLONASS��ʹ�ã���ITRF�� ��Щ��׼�汻��Ƴ�֧��λ�õ�ˮƽ������λ�õ�
        /// ��ֱ������ͨ����Բ�߶ȣ��� ITRF������ʵ�֣���ETRF��Ҳ��������һ�ࡣ
        /// </summary>
        HD_Geocentric = 1002,

        /// <summary>
        /// ˮƽ��׼���͵����ֵ��
        /// </summary>
        HD_Max = 1999,

        /// <summary>
        /// ��ֱ��׼���͵���Ϳ���ֵ��
        /// </summary>
        VD_Min = 2000,

        /// <summary>
        /// δָ���Ĵ�ֱ��׼���͡�
        /// </summary>
        VD_Other = 2000,

        /// <summary>
        /// �ش�ֱ�߲����������߶ȵĴ�ֱ��׼��
        /// </summary>
        VD_Orthometric = 2001,

        /// <summary>
        /// ������Բ�߶ȵĴ�ֱ��׼����ˮƽԭ�㶨����ʹ�õ���Բ��ķ��߲�����
        /// </summary>
        VD_Ellipsoidal = 2002,

        /// <summary>
        /// �����и߶Ȼ�߶ȵĴ�ֱ��׼�� ��Щ������ѹ�ƻ���ѹ�߶ȼƵİ����»�õ����߶�
        /// �Ľ���ֵ�� ��Щֵͨ�������µ�λ֮һ��ʾ���ף�Ӣ�ߣ����ͣ����ڲ���ѹ��ˮƽ��
        /// ���ֵ�����ڲ���λ�Ƹ߶ȵĵ�λ����
        /// </summary>
        VD_AltitudeBarometric = 2003,

        /// <summary>
        /// �����߶�ϵͳ��
        /// </summary>
        VD_Normal = 2004,

        /// <summary>
        /// ���ˮ׼��ģ�������߶ȵĴ�ֱ��׼��Ҳ��ΪGPS�����߶ȡ� ��Щ�߶���ͨ��ʹ�ø���
        /// �Ĵ��ˮ׼�沨��ģ�ͣ�N��ͨ����ʽH = h-N������߶ȣ�h�����������߶ȣ�H���Ľ�
        /// ��ֵ��
        /// </summary>
        VD_GeoidModelDerived = 2005,

        /// <summary>
        /// ����������֧����Ҫ�ں�ƽ��������Ȳ�����ˮ�Ĺ�����Ŀ���ɵĻ�׼���� ��ͨ����
        /// ��Ϊˮ�Ļ����׼�� ͨ��ʹ�ûز�̽��ȳ������������������ʵ�ʵȵ�λ�洹ֱ
        /// �����£��ķ����ϲ�����ȡ�
        /// </summary>
        VD_Depth = 2006,

        /// <summary>
        /// ��ֱ��׼���͵���߿���ֵ��
        /// </summary>
        VD_Max = 2999,

        /// <summary>
        /// �ֲ���׼���͵���Ϳ���ֵ��
        /// </summary>
        LD_Min = 10000,

        /// <summary>
        /// ���ػ�׼���͵���߿���ֵ��
        /// </summary>
        LD_Max = 32767
    }
}
