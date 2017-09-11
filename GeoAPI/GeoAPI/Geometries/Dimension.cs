using System;

namespace GeoAPI.Geometries
{
    /// <summary>
    /// 提供表示点，曲线和曲面尺寸的常数。
    /// </summary>
    /// <remarks>
    /// 还提供了表示空几何和非空几何尺寸的常量，以及通配符常量<see cref =“Dontcare”/>，意思是“任何维度”。
    /// 这些常量用作<see cref =“IntersectionMatrix”/> s中的条目。
    /// </remarks>
    public enum Dimension
    {
        /// <summary>
        /// 点（0）的尺寸值。
        /// </summary>
        Point = 0,

        /// <summary>
        /// 曲线的尺寸值（1）。
        /// </summary>
        Curve = 1,

        /// <summary>
        /// 表面尺寸值（2）。
        /// </summary>
        Surface = 2,

        /// <summary>
        /// 空点的维度值（-1）。
        /// </summary>
        False = -1,

        /// <summary>
        /// 非空几何的尺寸值（= {Point，Curve，A}）。
        /// </summary>
        True = -2,

        /// <summary>
        /// 任何维度的维度值（= {False，True}）。
        /// </summary>
        Dontcare = -3
    }

    /// <summary>
    /// 类包含用于维度值和字符之间的转换的静态方法。
    /// </summary>
    public class DimensionUtility
    {
        /// <summary>
        /// FALSE模式矩阵条目的符号
        /// </summary>
        public const char SymFalse = 'F';

        /// <summary>
        /// TRUE模式矩阵输入的符号
        /// </summary>
        public const char SymTrue = 'T';

        /// <summary>
        /// DONTCARE模式矩阵条目的符号
        /// </summary>
        public const char SymDontcare = '*';

        /// <summary>
        /// P（维0）图案矩阵条目的符号
        /// </summary>
        public const char SymP = '0';

        /// <summary>
        /// L（维1）模式矩阵条目的符号
        /// </summary>
        public const char SymL = '1';

        /// <summary>
        /// A（维2）模式矩阵条目的符号
        /// </summary>
        public const char SymA = '2';



        /// <summary>
        /// 将维度值转换为维度符号，例如<c> True =>'T'</ c>
        /// </summary>
        /// <param name="dimensionValue">可以存储在<c> IntersectionMatrix </ c>中的数字。 可能的值为<c> True，False，Dontcare，0，1，2 </ c>。</param>
        /// <returns>用于<c> IntersectionMatrix </ c>的字符串表示中的字符。 可能的值为<c> T，F，*，0,1,2，</ c>。</returns>
        public static char ToDimensionSymbol(Dimension dimensionValue)
        {
            switch (dimensionValue)
            {
                case Dimension.False:
                    return SymFalse;
                case Dimension.True:
                    return SymTrue;
                case Dimension.Dontcare:
                    return SymDontcare;
                case Dimension.Point:
                    return SymP;
                case Dimension.Curve:
                    return SymL;
                case Dimension.Surface:
                    return SymA;
                default:
                    throw new ArgumentOutOfRangeException
                        ("Unknown dimension value: " + dimensionValue);
            }
        }

        /// <summary>
        /// 将维度符号转换为维度值，例如<c>'*'=> Dontcare </ c>
        /// </summary>
        /// <param name="dimensionSymbol">用于<c> IntersectionMatrix </ c>的字符串表示中的字符。 可能的值为<c> T，F，*，0,1,2，</ c>。</param>
        /// <returns>可以存储在<c> IntersectionMatrix </ c>中的数字。 可能的值为<c> True，False，Dontcare，0，1，2 </ c>。</returns>
        public static Dimension ToDimensionValue(char dimensionSymbol)
        {
            switch (Char.ToUpper(dimensionSymbol))
            {
                case SymFalse:
                    return Dimension.False;
                case SymTrue:
                    return Dimension.True;
                case SymDontcare:
                    return Dimension.Dontcare;
                case SymP:
                    return Dimension.Point;
                case SymL:
                    return Dimension.Curve;
                case SymA:
                    return Dimension.Surface;
                default:
                    throw new ArgumentOutOfRangeException
                        ("Unknown dimension symbol: " + dimensionSymbol);
            }
        }
    }
}
