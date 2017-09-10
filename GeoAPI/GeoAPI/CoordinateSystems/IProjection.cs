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
    /// IProjection�ӿڶ�����ͶӰ����һ��洢�ı�׼��Ϣ�� ������������ϵ������ͶӰ����
    /// ʵ�ִӵ�������ϵ��ͶӰ����ϵ������任�� Ԥ�ڸ���Ȥ��ÿ������任���������ī���У�
    /// �����ؽ���ʵ��Ϊco����ͶӰ��COM�֧࣬��IProjection�ӿڡ�
    /// </summary>
    public interface IProjection : IInfo
    {
        /// <summary>
        /// ��ȡͶӰ�Ĳ�������
        /// </summary>
        int NumParameters { get; }

        /// <summary>
        /// ��ȡͶӰ�������ƣ����硰����ī���С�����
        /// </summary>
        string ClassName { get; }

        /// <summary>
        /// ��ȡͶӰ������������
        /// </summary>
        /// <param name="index">��������</param>
        /// <returns>��n������</returns>
        ProjectionParameter GetParameter(int index);

        /// <summary>
        /// ��ȡͶӰ������������
        /// </summary>
        /// <remarks>�������Ʋ����ִ�Сд</remarks>
        /// <param name="name">��������</param>
        /// <returns>������null�����û���ҵ���</returns>
        ProjectionParameter GetParameter(string name);
    }
}
