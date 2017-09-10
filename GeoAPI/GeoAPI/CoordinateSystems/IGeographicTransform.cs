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
    /// IGOgraphicTransform�ӿ��ڵ���任������ʵ�֣����ڵ�������ϵ֮��ʵ�ֻ�׼�任��
    /// </summary>
    public interface IGeographicTransform : IInfo
    {
        /// <summary>
        /// ��ȡ�����ñ任��Դ��������ϵ��
        /// </summary>
        IGeographicCoordinateSystem SourceGCS { get; set; }

        /// <summary>
        /// ��ȡ������ת����Ŀ���������ϵ��
        /// </summary>
        IGeographicCoordinateSystem TargetGCS { get; set; }

        /// <summary>
        /// ���ش˵���任�����ķ������ӿڡ�
        /// </summary>
        IParameterInfo ParameterInfo { get; }

        /// <summary>
        /// �������д�Դ��������ϵת��ΪĿ���������ϵ��
        /// </summary>
        /// <param name="points">Դ��������ϵ�еĵ�</param>
        /// <returns>Ŀ���������ϵ�еĵ�</returns>
        List<double[]> Forward(List<double[]> points);

        /// <summary>
        /// �������д�Ŀ���������ϵת��ΪԴ��������ϵ��
        /// </summary>
        /// <param name="points">Ŀ���������ϵ�еĵ�</param>
        /// <returns>Դ��������ϵ�еĵ�</returns>
        List<double[]> Inverse(List<double[]> points);
    }
}
