using System;
using GeoAPI.Geometries;

namespace GeoAPI.IO
{
    /// <summary>
    /// 处理OGC几何类型声明的轻量级的类
    /// </summary>
    public struct GeometryType
    {
        /// <summary>
        /// 初始化此实例
        /// </summary>
        /// <param name =“geometryType”>描述<see cref =“GeometryType”/> </ param>的值
        public GeometryType(uint geometryType)
        {
            _geometrytype = geometryType;
        }

        /// <summary>
        /// 基于几何和一个“坐标”标志来初始化这个实例。
        /// </summary>
        /// <param name="geometry">几何。</param>
        /// <param name="ordinates">纵坐标标志。</param>
        public GeometryType(IGeometry geometry, Ordinates ordinates)
            : this(geometry.OgcGeometryType, ordinates, geometry.SRID >= 0)
        {
        }

        /// <summary>
        /// 基于<see cref =“OgcGeometryType”/>初始化此实例
        /// </summary>
        /// <param name="ogcGeometryType">OGC几何类型</param>
        public GeometryType(OgcGeometryType ogcGeometryType)
            : this(ogcGeometryType, Ordinates.XY, false)
        {

        }

        /// <summary>
        /// 根据<see cref =“OgcGeometryType”/>和SRID指示符初始化此实例
        /// </summary>
        /// <param name="ogcGeometryType">OGC几何类型</param>
        /// <param name="hasSrid">是否提供SRID的标志。</param>
        public GeometryType(OgcGeometryType ogcGeometryType, bool hasSrid)
            : this(ogcGeometryType, Ordinates.XY, hasSrid)
        {
        }

        /// <summary>
        /// 根据<see cref =“OgcGeometryType”/>和SRID指示符初始化此实例
        /// </summary>
        /// <param name="ogcGeometryType">OGC几何类型</param>
        /// <param name="ordinates">纵坐标标志。</param>
        /// <param name="hasSrid">是否提供SRID的标志。</param>
        public GeometryType(OgcGeometryType ogcGeometryType, Ordinates ordinates, bool hasSrid)
        {
            _geometrytype = (uint)ogcGeometryType;

            if ((ordinates & Ordinates.Z) != 0)
            {
                HasWkbZ = true;
                HasEwkbM = true;
            }

            if ((ordinates & Ordinates.M) != 0)
            {
                HasWkbZ = true;
                HasEwkbM = true;
            }

            HasEwkbSrid = hasSrid;
        }

        private uint _geometrytype;

        /// <summary>
        /// 获取或设置基本几何类型
        /// </summary>
        public OgcGeometryType BaseGeometryType
        {
            get
            {
                // 留下Ewkb标志
                var val = _geometrytype & 0xffffff;
                if (val > 2000) val -= 2000;
                if (val > 1000) val -= 1000;
                return (OgcGeometryType)val;
            }
            set
            {
                var ewkbFlags = _geometrytype & EwkbFlags;
                var newGeometryType = (uint)value;
                if (HasWkbZ) newGeometryType += 1000;
                if (HasWkbM) newGeometryType += 2000;
                _geometrytype = ewkbFlags | newGeometryType;
            }
        }

        /// <summary>
        /// 获得OGC知名二进制类型代码
        /// </summary>
        public int WkbGeometryType
        {
            get { return (int)(_geometrytype & 0x1ffffff); }
        }

        /// <summary>
        /// 获得PostGIS增强的知名二进制类型代码
        /// </summary>
        public int EwkbWkbGeometryType
        {
            get
            {
                return (int)((uint)BaseGeometryType | (_geometrytype & 0xfe000000));
            }
        }

        /// <summary>
        /// 获取或设置z坐标值是否与几何一起存储。
        /// </summary>
        public bool HasZ { get { return HasWkbZ | HasEwkbZ; } }

        /// <summary>
        /// 获取或设置坐标值是否与几何一起存储。
        /// </summary>
        public bool HasM { get { return HasWkbM | HasEwkbM; } }

        /// <summary>
        /// 获取SRID值是否与几何一起存储。
        /// </summary>
        public bool HasSrid { get { return HasEwkbSrid; } }

        /// <summary>
        /// 获取或设置z坐标值是否与几何一起存储。
        /// </summary>
        public bool HasWkbZ
        {
            get { return (_geometrytype / 1000) == 1; }
            set
            {
                if (value == HasWkbZ)
                    return;
                if (HasWkbZ)
                    _geometrytype -= 1000;
                else
                    _geometrytype += 1000;

            }
        }

        /// <summary>
        /// 获取或设置坐标值是否与几何一起存储。
        /// </summary>
        public bool HasWkbM
        {
            get { return (_geometrytype / 2000) == 2; }
            set
            {
                if (value == HasWkbM)
                    return;
                if (HasWkbM)
                    _geometrytype -= 2000;
                else
                    _geometrytype += 2000;

            }
        }

        #region PostGis EWKB/EWKT

        private const uint EwkbZFlag = 0x8000000;
        private const uint EwkbMFlag = 0x4000000;
        private const uint EwkbSridFlag = 0x2000000;

        private const uint EwkbFlags = EwkbZFlag | EwkbMFlag | EwkbSridFlag;

        /// <summary>
        /// 获取或设置坐标是否与几何一起存储。
        /// <para>PostGis EWKB格式。</para>
        /// </summary>
        public bool HasEwkbZ
        {
            get { return (_geometrytype & EwkbZFlag) == EwkbZFlag; }
            set
            {
                var gt = _geometrytype & (~EwkbZFlag);
                if (value)
                    gt = _geometrytype | EwkbZFlag;
                _geometrytype = gt;
            }
        }

        /// <summary>
        /// 获取或设置坐标是否与几何一起存储。
        /// <para>PostGis EWKB格式。</para>
        /// </summary>
        public bool HasEwkbM
        {
            get { return (_geometrytype & EwkbMFlag) == EwkbMFlag; }
            set
            {
                var gt = _geometrytype & (~EwkbMFlag);
                if (value)
                    gt = _geometrytype | EwkbMFlag;
                _geometrytype = gt;
            }
        }

        /// <summary>
        /// 获取或设置坐标是否与几何一起存储。
        /// <para>PostGis EWKB格式。</para>
        /// </summary>
        public bool HasEwkbSrid
        {
            get { return (_geometrytype & EwkbSridFlag) == EwkbSridFlag; }
            set
            {
                var gt = _geometrytype & (~EwkbSridFlag);
                if (value)
                    gt = _geometrytype | EwkbSridFlag;
                _geometrytype = gt;
            }
        }

        #endregion
    }
}