using System;
using GeoAPI.Geometries;

namespace GeoAPI.IO
{
    /// <summary>
    /// ����OGC������������������������
    /// </summary>
    public struct GeometryType
    {
        /// <summary>
        /// ��ʼ����ʵ��
        /// </summary>
        /// <param name =��geometryType��>����<see cref =��GeometryType��/> </ param>��ֵ
        public GeometryType(uint geometryType)
        {
            _geometrytype = geometryType;
        }

        /// <summary>
        /// ���ڼ��κ�һ�������ꡱ��־����ʼ�����ʵ����
        /// </summary>
        /// <param name="geometry">���Ρ�</param>
        /// <param name="ordinates">�������־��</param>
        public GeometryType(IGeometry geometry, Ordinates ordinates)
            : this(geometry.OgcGeometryType, ordinates, geometry.SRID >= 0)
        {
        }

        /// <summary>
        /// ����<see cref =��OgcGeometryType��/>��ʼ����ʵ��
        /// </summary>
        /// <param name="ogcGeometryType">OGC��������</param>
        public GeometryType(OgcGeometryType ogcGeometryType)
            : this(ogcGeometryType, Ordinates.XY, false)
        {

        }

        /// <summary>
        /// ����<see cref =��OgcGeometryType��/>��SRIDָʾ����ʼ����ʵ��
        /// </summary>
        /// <param name="ogcGeometryType">OGC��������</param>
        /// <param name="hasSrid">�Ƿ��ṩSRID�ı�־��</param>
        public GeometryType(OgcGeometryType ogcGeometryType, bool hasSrid)
            : this(ogcGeometryType, Ordinates.XY, hasSrid)
        {
        }

        /// <summary>
        /// ����<see cref =��OgcGeometryType��/>��SRIDָʾ����ʼ����ʵ��
        /// </summary>
        /// <param name="ogcGeometryType">OGC��������</param>
        /// <param name="ordinates">�������־��</param>
        /// <param name="hasSrid">�Ƿ��ṩSRID�ı�־��</param>
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
        /// ��ȡ�����û�����������
        /// </summary>
        public OgcGeometryType BaseGeometryType
        {
            get
            {
                // ����Ewkb��־
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
        /// ���OGC֪�����������ʹ���
        /// </summary>
        public int WkbGeometryType
        {
            get { return (int)(_geometrytype & 0x1ffffff); }
        }

        /// <summary>
        /// ���PostGIS��ǿ��֪�����������ʹ���
        /// </summary>
        public int EwkbWkbGeometryType
        {
            get
            {
                return (int)((uint)BaseGeometryType | (_geometrytype & 0xfe000000));
            }
        }

        /// <summary>
        /// ��ȡ������z����ֵ�Ƿ��뼸��һ��洢��
        /// </summary>
        public bool HasZ { get { return HasWkbZ | HasEwkbZ; } }

        /// <summary>
        /// ��ȡ����������ֵ�Ƿ��뼸��һ��洢��
        /// </summary>
        public bool HasM { get { return HasWkbM | HasEwkbM; } }

        /// <summary>
        /// ��ȡSRIDֵ�Ƿ��뼸��һ��洢��
        /// </summary>
        public bool HasSrid { get { return HasEwkbSrid; } }

        /// <summary>
        /// ��ȡ������z����ֵ�Ƿ��뼸��һ��洢��
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
        /// ��ȡ����������ֵ�Ƿ��뼸��һ��洢��
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
        /// ��ȡ�����������Ƿ��뼸��һ��洢��
        /// <para>PostGis EWKB��ʽ��</para>
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
        /// ��ȡ�����������Ƿ��뼸��һ��洢��
        /// <para>PostGis EWKB��ʽ��</para>
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
        /// ��ȡ�����������Ƿ��뼸��һ��洢��
        /// <para>PostGis EWKB��ʽ��</para>
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