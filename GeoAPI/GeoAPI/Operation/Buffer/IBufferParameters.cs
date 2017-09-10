using GeoAPI.Operation.Buffer;

namespace GeoAPI.Operation.Buffer
{
    /// <summary>
    /// 用于控制缓冲区构建过程的参数的类的接口
    /// <para>
    /// 参数允许控制：
    /// <list type="Bullet">
    /// <item>象限段（圆弧近似精度）</item>
    /// <item>端帽风格</item>
    /// <item>连接样式</item>
    /// <item>斜度限制</item>
    /// <item>缓冲区是否是单面的</item>
    /// </list>
    /// </para>
    /// </summary>
    public interface IBufferParameters
    {
        ///<summary>
        /// 获取/设置将要使用的象限段数
        ///</summary>
        /// <remarks>
        /// QuadrantSegments是用于近似角度圆角的线段数。
        /// <list type="Table">
        /// <item>qs &gt;>= 1</item><description>连接是圆形的，qs表示用于近似四分之一圈的段数。</description>
        /// <item>qs = 0</item><description>连接是斜面的</description>
        /// <item>qs &lt; 0</item><description>连接被忽略，qs的值表示斜角比例限制为<c> mitreLimit = | qs | </ c></description>
        /// </list>
        /// </remarks>
        int QuadrantSegments { get; set; }

        ///<summary>
        /// 获取/设置生成的缓冲区的端帽样式。
        ///</summary>
        /// <remarks>
        /// <para>
        /// 支持的样式是<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Round"/>，<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Flat"/>和<see cref ="GeoAPI.Operation。Buffer.EndCapStyle.Square"/>。
        /// </para>
        /// <para>默认值为<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Round"/>。</para>
        /// </remarks>
        EndCapStyle EndCapStyle { get; set; }

        ///<summary>
        /// 获取/设置线段之间的外部（反射）角的连接样式。
        ///</summary>
        /// <remarks>
        /// <para>允许的值为<see cref =“GeoAPI.Operation.Buffer.JoinStyle.Round”/>（这是默认值），<see cref =“GeoAPI.Operation.Buffer.JoinStyle.Mitre”/>和<see cref =“GeoAPI.Operation.Buffer.JoinStyle.Bevel“/></para>
        /// </remarks>
        JoinStyle JoinStyle { get; set; }

        ///<summary>
        /// 设置用于非常锋利角落的斜角比的极限。
        ///</summary>
        /// <remarks>
        /// <para>
        /// 斜角比是从偏心角偏移角到终点的距离的比值。 当两个线段以锐角相交时，斜接连接将远远超出原始几何。 （并且在极端情况下将无限远）。为了防止不合理的几何形状，斜角限制允许控制连接角的最大长度。 角度超过极限的角落将被倾斜。
        /// </para>
        /// </remarks>
        double MitreLimit { get; set; }

        /// <summary>
        /// 获取或设置计算缓冲区是否应该是单面的。 单面缓冲器仅在每条输入线的一侧构成。
        /// <para>
        /// 所使用的一面由缓冲距离的符号决定：
        /// <list type="Bullet">
        /// <item>正的距离表示左侧</item>
        /// <item>负距离表示右侧</item>
        /// </list>
        /// 点几何的单面缓冲区与常规缓冲区相同。
        /// </para><para>
        /// 单向缓冲区的端盖样式总是被忽略，并被强制等同于<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Flat"/>。
        /// </para>
        /// </summary>
        bool IsSingleSided { get; set; }

        /// <summary>
        /// 获取或设置用于确定简化距离公差的因子，以实现输入简化。 简化可以提高计算缓冲区的性能。 通常，简化因子应大于0.对于生成缓冲区，0.01和0.1之间的值产生相对较好的精度。 更大的价值牺牲精度来回报表现。
        /// </summary>
        double SimplifyFactor { get; set; }
    }
}