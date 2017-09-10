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
    /// ��������任������任���͡�
    /// </summary>
    public enum TransformType : int
    {
        /// <summary>
        /// δ֪��δָ�����͵ı任��
        /// </summary>
        Other = 0,

        /// <summary>
        /// �任��ȡ���ڶ���Ĳ����� ���磬��ͼͶӰ��
        /// </summary>
        Conversion = 1,

        /// <summary>
        /// �任��ȡ���ھ��鵼���Ĳ����� �����׼�任��
        /// </summary>
        Transformation = 2,

        /// <summary>
        /// �任ȡ���ڶ���;��������
        /// </summary>
        ConversionAndTransformation = 3
    }
}
