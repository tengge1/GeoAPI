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
    /// IParameterInfo接口提供了一个接口，通过该接口，投影坐标系或投影的客户端
    /// 可以设置投影的参数。 它提供了一个通用接口，用于发现参数的名称和默认值，
    /// 以及设置和获取参数值。 该接口的子类可以提供投影特定的参数访问方法。
    /// </summary>
    public interface IParameterInfo
    {
        /// <summary>
        /// 获取预期的参数数量。
        /// </summary>
        int NumParameters { get; }

        /// <summary>
        /// 返回此投影的默认参数。
        /// </summary>
        /// <returns></returns>
        Parameter[] DefaultParameters();

        /// <summary>
        /// 获取或设置为此投影设置的参数。
        /// </summary>
        List<Parameter> Parameters { get; set; }

        /// <summary>
        /// 通过名称获取参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Parameter GetParameterByName(string name);
    }
}
