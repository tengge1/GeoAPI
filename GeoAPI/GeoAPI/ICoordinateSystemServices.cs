using System;
// Copyright 2013-2015 - Felix Obermaier (www.ivv-aachen.de)
// Copyright 2015      - Spartaco Giubbolini
//
// This file is part of GeoAPI.
// GeoAPI is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// GeoAPI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;

namespace GeoAPI
{
    /// <summary>
    /// �ṩ������ϵ��ת�����ߵķ��ʵ���Ľӿڡ�
    /// </summary>
    public interface ICoordinateSystemServices
    {
        /// <summary>
        /// ͨ��<paramref name =��srid��/>��ʶ����������ϵ
        /// </summary>
        /// <param name="srid">����ϵ�ĳ�ʼ��</param>
        /// <returns>����ϵ��</returns>
        ICoordinateSystem GetCoordinateSystem(int srid);

        /// <summary>
        /// ͨ��<paramref name =��authority��/>��<paramref name =��code��/>��������ϵ��
        /// </summary>
        /// <param name="authority">����ϵ�����</param>
        /// <param name="code">ͨ��<paramref name =��authority��/>���������ϵ�Ĵ��롣</param>
        /// <returns>����ϵ��</returns>
        ICoordinateSystem GetCoordinateSystem(string authority, long code);

        /// <summary>
        /// ��ȡ������ϵ���Ա����ʵı�ʶ���ķ�����
        /// </summary>
        /// <param name="authority">���������</param>
        /// <param name="authorityCode">��<paramref name =��authority��/>����Ĵ���</param>
        /// <returns>��ʶ����<value> null </value></returns>
        int? GetSRID(string authority, long authorityCode);

        /// <summary>
        /// �������ʶ������������ռ�ο�ϵͳ֮�䴴������任�ķ���
        /// </summary>
        /// <remarks>����<see cref =������ת����KoordinatenSystem��KoordinatenSystem����/>�ı���������</remarks>
        /// <param name="sourceSrid">Դ�ռ�ο�ϵͳ�ı�ʶ����</param>
        /// <param name="targetSrid">Ŀ��ռ�ο�ϵͳ�ı�ʶ����</param>
        /// <returns>������ܴ���ת����������任<value> null </ value>��</returns>
        ICoordinateTransformation CreateTransformation(int sourceSrid, int targetSrid);

        /// <summary>
        /// �������ռ�ο�ϵͳ֮�䴴������任�ķ���
        /// </summary>
        /// <param name="source">Դ�ռ�ο�ϵ��</param>
        /// <param name="target">Ŀ��ռ�ο�ϵ��</param>
        /// <returns>������ܴ���ת����������任<value> null </ value>��</returns>
        ICoordinateTransformation CreateTransformation(ICoordinateSystem source, ICoordinateSystem target);
    }
}