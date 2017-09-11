using System;
using GeoAPI.Operation.Buffer;

namespace GeoAPI.Geometries
{
    using ICloneable = System.ICloneable;

    /// <summary>  
    /// 基本实现<c>几何</ c>的界面。
    /// </summary>
    public interface IGeometry : ICloneable, IComparable, IComparable<IGeometry>, IEquatable<IGeometry>
    {
        ///<summary>
        /// 基本实现<c>几何</ c>的基类。
        ///</summary>
        IGeometryFactory Factory { get; }

        ///<summary>
        /// <see cref =“IPrecisionModel”/>用于创建这个的<see cref =“Factory”/>。
        ///</summary>
        IPrecisionModel PrecisionModel { get; }

        /// <summary>
        /// 获取空间索引ID
        /// </summary>
        int SRID { get; set; }

        /// <summary>
        /// 获取几何类型
        /// </summary>
        string GeometryType { get; }

        /// <summary>
        /// 获取OGC几何类型
        /// </summary>
        OgcGeometryType OgcGeometryType { get; }

        /// <summary>
        /// 获取此几何的面积（如果适用），否则<c> 0d </ c>
        /// </summary>
        /// <remarks>在IGeometry中移动了一个<see cref =“ISurface”/>方法</remarks>
        double Area { get; }

        /// <summary>
        /// 获取此几何图形的长度（如果适用），否则<c> 0d </ c>
        /// </summary>
        /// <remarks>在IGeometry中移动<see cref =“ICurve”/>方法</remarks>
        double Length { get; }

        /// <summary>
        /// 获取构成该几何的几何体数
        /// </summary>
        /// <remarks>
        /// 在IGeometry中移动了一个<see cref =“IGeometryCollection”/>方法
        /// </remarks>
        int NumGeometries { get; }

        /// <summary>
        /// 获取构成该几何的坐标数
        /// </summary>
        /// <remarks>将<see cref =“ILineString”/>方法移动到IGeometry</remarks>
        int NumPoints { get; }

        /// <summary>
        /// 获取边界几何
        /// </summary>
        IGeometry Boundary { get; }

        /// <summary>
        /// 获取边界的<see cref =“Dimension”/>
        /// </summary>
        Dimension BoundaryDimension { get; }

        /// <summary>
        /// 获得几何的质心
        /// </summary>
        /// <remarks>在IGeometry中移动了一个<see cref =“ISurface”/>属性</remarks>
        IPoint Centroid { get; }

        ///<summary>
        /// Gets a <see cref="Coordinate"/> that is guaranteed to be part of the geometry, usually the first.
        ///</summary>
        Coordinate Coordinate { get; }

        ///<summary>
        /// Gets an array of <see cref="Coordinate"/>s that make up this geometry.
        ///</summary>
        Coordinate[] Coordinates { get; }

        ///<summary>
        /// Gets an array of <see cref="T:System.Double"/> ordinate values.
        ///</summary>
        Double[] GetOrdinates(Ordinate ordinate);

        /// <summary>
        /// Gets the <see cref="Dimension"/> of this geometry
        /// </summary>
        Dimension Dimension { get; set; }

        /// <summary>
        /// Gets the envelope this <see cref="IGeometry"/> would fit into.
        /// </summary>
        IGeometry Envelope { get; }

        /// <summary>
        /// Gets the envelope this <see cref="IGeometry"/> would fit into.
        /// </summary>
        Envelope EnvelopeInternal { get; }

        /// <summary>
        /// Gets a point that is ensured to lie inside this geometry.
        /// </summary>
        IPoint InteriorPoint { get; }

        /// <summary>
        /// A ISurface method moved in IGeometry 
        /// </summary>        
        IPoint PointOnSurface { get; }

        /// <summary>
        /// Gets the geometry at the given index
        /// </summary>
        /// <remarks>A <see cref="IGeometryCollection"/> method moved in IGeometry</remarks>
        /// <param name="n">The index of the geometry to get</param>
        /// <returns>A geometry that is part of the <see cref="IGeometryCollection"/></returns>
        IGeometry GetGeometryN(int n);

        /// <summary>
        /// Normalizes this geometry
        /// </summary>
        void Normalize();

        /// <summary>
        /// Creates a new Geometry which is a normalized copy of this Geometry. 
        /// </summary>
        /// <returns>A normalized copy of this geometry.</returns>
        /// <seealso cref="Normalize"/>
        IGeometry Normalized();

        /// <summary>
        /// Gets the Well-Known-Binary representation of this geometry
        /// </summary>
        /// <returns>A byte array describing this geometry</returns>
        byte[] AsBinary();

        /// <summary>
        /// Gets the Well-Known-Text representation of this geometry
        /// </summary>
        /// <returns>A text describing this geometry</returns>
        string AsText();

        /// <summary>
        /// Gets or sets the user data associated with this geometry
        /// </summary>
        object UserData { get; set; }

        /// <summary>
        /// Computes the convex hull for this geometry
        /// </summary>
        /// <returns>The convex hull</returns>
        IGeometry ConvexHull();

        IntersectionMatrix Relate(IGeometry g);

        IGeometry Difference(IGeometry other);

        IGeometry SymmetricDifference(IGeometry other);

        IGeometry Buffer(double distance);

        IGeometry Buffer(double distance, int quadrantSegments);

        [Obsolete]
        IGeometry Buffer(double distance, BufferStyle endCapStyle);

        [Obsolete]
        IGeometry Buffer(double distance, int quadrantSegments, BufferStyle endCapStyle);

        IGeometry Buffer(double distance, int quadrantSegments, EndCapStyle endCapStyle);

        IGeometry Buffer(double distance, IBufferParameters bufferParameters);

        IGeometry Intersection(IGeometry other);

        IGeometry Union(IGeometry other);

        IGeometry Union();

        /// <summary>
        /// Tests whether this geometry is topologically equal to the argument geometry
        /// as defined by the SFS <tt>equals</tt> predicate.
        /// </summary>
        /// <param name="other">A geometry</param>
        /// <returns><c>true</c> if this geometry is topologically equal to <paramref name="other"/></returns>
        bool EqualsTopologically(IGeometry other);

        bool EqualsExact(IGeometry other);

        bool EqualsExact(IGeometry other, double tolerance);

        /// <summary>
        /// Tests whether two geometries are exactly equal
        /// in their normalized forms.
        /// </summary>>
        /// <param name="g">A geometry</param>
        /// <returns>true if the input geometries are exactly equal in their normalized form</returns>
        bool EqualsNormalized(IGeometry g);

        bool IsEmpty { get; }

        bool IsRectangle { get; }

        bool IsSimple { get; }

        bool IsValid { get; }

        bool Within(IGeometry g);

        bool Contains(IGeometry g);

        bool IsWithinDistance(IGeometry geom, double distance);

        bool CoveredBy(IGeometry g);

        bool Covers(IGeometry g);

        bool Crosses(IGeometry g);

        bool Intersects(IGeometry g);

        bool Overlaps(IGeometry g);

        bool Relate(IGeometry g, string intersectionPattern);

        bool Touches(IGeometry g);

        bool Disjoint(IGeometry g);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IGeometry Reverse();

        /// <summary>  
        /// Returns the minimum distance between this <c>Geometry</c>
        /// and the <c>Geometry</c> g.
        /// </summary>
        /// <param name="g">The <c>Geometry</c> from which to compute the distance.</param>
        double Distance(IGeometry g);

        /// <summary>
        /// Performs an operation with or on this <c>Geometry</c>'s
        /// coordinates. If you are using this method to modify the point, be sure
        /// to call <see cref="GeometryChanged()"/> afterwards.
        /// Note that you cannot use this  method to modify this Geometry 
        /// if its underlying <see cref="ICoordinateSequence"/>'s Get method
        /// returns a copy of the <see cref="Coordinate"/>, rather than the actual
        /// Coordinate stored (if it even stores Coordinates at all).
        /// </summary>
        /// <param name="filter">The filter to apply to this <c>Geometry</c>'s coordinates</param>
        void Apply(ICoordinateFilter filter);

        ///<summary>
        /// Performs an operation on the coordinates in this <c>Geometry</c>'s <see cref="ICoordinateSequence"/>s. 
        /// If this method modifies any coordinate values, <see cref="GeometryChanged()"/> must be called to update the geometry state.
        ///</summary>
        /// <param name="filter">The filter to apply</param>
        void Apply(ICoordinateSequenceFilter filter);

        /// <summary>
        /// Performs an operation with or on this <c>Geometry</c> and its
        /// subelement <c>Geometry</c>s (if any).
        /// Only GeometryCollections and subclasses
        /// have subelement Geometry's.
        /// </summary>
        /// <param name="filter">
        /// The filter to apply to this <c>Geometry</c> (and
        /// its children, if it is a <c>GeometryCollection</c>).
        /// </param>
        void Apply(IGeometryFilter filter);

        /// <summary>
        /// Performs an operation with or on this Geometry and its
        /// component Geometry's. Only GeometryCollections and
        /// Polygons have component Geometry's; for Polygons they are the LinearRings
        /// of the shell and holes.
        /// </summary>
        /// <param name="filter">The filter to apply to this <c>Geometry</c>.</param>
        void Apply(IGeometryComponentFilter filter);

        /// <summary>
        /// Notifies this geometry that its coordinates have been changed by an external
        /// party (using a CoordinateFilter, for example). The Geometry will flush
        /// and/or update any information it has cached (such as its <see cref="IEnvelope"/>).
        /// </summary>
        void GeometryChanged();

        /// <summary>
        /// Notifies this Geometry that its Coordinates have been changed by an external
        /// party. When <see cref="GeometryChanged"/> is called, this method will be called for
        /// this <c>Geometry</c> and its component geometries.
        /// </summary>
        void GeometryChangedAction();
    }
}
