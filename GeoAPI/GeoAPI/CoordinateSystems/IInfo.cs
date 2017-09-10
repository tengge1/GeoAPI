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
    /// ISpatialReferenceInfo�ӿڶ�����ռ�ο�����һ��洢�ı�׼��Ϣ�� �ýӿ�
    /// ��������ϵͳ�е����ռ�ο�����
    /// </summary>
    public interface IInfo
    {
        /// <summary>
        /// ��ȡ�����ö�������ơ�
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ��ȡ�����ô˶���Ĺ�������ƣ����磬POSC�Ǿ�����Ȩ�ض���ݴ���ı�׼���� 
        /// ��������Զ�����󣬷���CUSTOM��
        /// </summary>
        string Authority { get; }

        /// <summary>
        /// ��ȡ�����ö���Ĺ�����ض�ʶ����
        /// </summary>
        long AuthorityCode { get; }

        /// <summary>
        /// ��ȡ�����ö���ı�����
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// ��ȡ�����ö������д��
        /// </summary>
        string Abbreviation { get; }

        /// <summary>
        /// ��ȡ�����ö�����ṩ���ṩ�ı�ע��
        /// </summary>
        string Remarks { get; }

        /// <summary>
        /// ���ش˼������淶�ж���Ĵ˿ռ�ο������֪���ı���
        /// </summary>
        string WKT { get; }

        /// <summary>
        /// ��ȡ�˶����XML��ʾ��
        /// </summary>
        string XML { get; }

        /// <summary>
        /// ����ʵ����ֵ�Ƿ������һ��ʵ����ֵ��
        /// ����������ϵ�Ĳ������ڱȽϡ� ���ƣ���д��Ȩ�ޣ������ͱ�ע�ڱȽ��б����ԡ�
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>��������Ϊ��</returns>
        bool EqualParams(object obj);
    }
}
