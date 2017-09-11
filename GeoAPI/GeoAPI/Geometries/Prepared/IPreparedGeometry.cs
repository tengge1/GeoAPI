namespace GeoAPI.Geometries.Prepared
{

    ///<summary>
    /// 用于准备<see cref =“IGeometry”/>的类的接口，以优化对特定几何操作的重复调用的性能。
    ///</summary>
    /// <remarks>
    /// <para>
    /// 给定的实现可以为仅一些指定的方法提供优化的实现，并且将剩余的方法委托给原始的<see cref =“IGeometry”/>操作。
    /// </para>
    /// <para>
    /// 实施也可能仅仅优化某些情况，并且委托他人。 请参阅实现类的文档，了解哪些方法和优化方式。
    /// </para>
    /// <para>
    /// 子类旨在是线程安全的，以允许在多线程上下文中使用（c）IPreparedGeometry </ c>（允许从准备状态中提取最大利益）。
    /// </para>
    /// </remarks>
    /// <author>Martin Davis</author>
    public interface IPreparedGeometry
    {
        ///<summary>
        /// 获取已准备好的原始<see cref =“IGeometry”/>。
        ///</summary>
        IGeometry Geometry { get; }

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否包含给定的几何。
        ///</summary>
        /// <param name="geom">要几何测试</param>
        /// <returns>如果此几何包含给定的几何，则为true</returns>
        /// <see cref="IGeometry.Contains(IGeometry)"/>
        bool Contains(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否包含给定的几何。
        ///</summary>
        /// <remarks>
        /// <para>
        /// <c> ContainsProperly </ c>谓词具有以下等效定义：
        /// <list>
        /// <item>其他几何的每个点都是这个几何体内部的一个点。</item>
        /// <item>两个几何的DE-9IM交点矩阵匹配<c >> [T ** FF * FF *] </ c></item>
        /// </list>
        /// 使用该谓词的优点是可以有效地计算，无需在各个点计算拓扑。
        /// </para>
        /// <para>
        /// 此谓词的一个示例用例是计算一组几何与大多边形几何的交集。
        /// 由于<tt>交集</ tt>是一个相当慢的操作，因此使用<tt> containsProperly </ tt>可以更有效地过滤完全位于该区域内的测试几何。 在这些情况下，交叉点先验知道是简单的原始测试几何。
        /// </para>
        /// </remarks>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何正确地包含给定的几何，则为true</returns>
        //// <see cref="IGeometry.ContainsProperly(IGeometry)"/>
        bool ContainsProperly(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否被给定的几何体覆盖。
        ///</summary>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果该几何被给定的几何体覆盖，则为真</returns>
        /// <see cref="IGeometry.CoveredBy(IGeometry)"/>
        bool CoveredBy(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否涵盖给定的几何体。
        ///</summary>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何涵盖给定的几何体，则为真</returns>
        /// <see cref="IGeometry.Covers(IGeometry)"/>
        bool Covers(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否穿过给定的几何。
        ///</summary>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何穿过给定的几何体，则为真</returns>
        /// <see cref="IGeometry.Crosses(IGeometry)"/>
        bool Crosses(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否与给定几何不相交。
        ///</summary>
        /// <remarks>
       	/// 此方法支持<see cref =“IGeometryCollection”/> s作为输入
       	/// </remarks>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何与给定几何体不相交，则为true</returns>
        /// <see cref="IGeometry.Disjoint(IGeometry)"/>
        bool Disjoint(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否与给定的几何相交。
        ///</summary>
        /// <remarks>
        /// 此方法支持<see cref =“IGeometryCollection”/> s作为输入
        /// </remarks>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何与给定的几何相交，则为真</returns>
        /// <see cref="IGeometry.Intersects(IGeometry)"/>
        bool Intersects(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否与给定的几何重叠。
        ///</summary>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何与给定的几何重叠，则为真</returns>
        /// <see cref="IGeometry.Overlaps(IGeometry)"/>
        bool Overlaps(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否触及给定的几何。
        ///</summary>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何接触给定的几何，则为true</returns>
        /// <see cref="IGeometry.Touches(IGeometry)"/>
        bool Touches(IGeometry geom);

        ///<summary>
        /// 测试基础<see cref =“IGeometry”/>是否在给定的几何体内。
        ///</summary>
        /// <param name="geom">要测试的几何</param>
        /// <returns>如果这个几何在给定的几何体内，则为真</returns>
        /// <see cref="IGeometry.Within(IGeometry)"/>
        bool Within(IGeometry geom);

    }
}