#define picky
using System;
using System.Globalization;
using GeoAPI.Geometries;

namespace GeoAPI.DataStructures
{
    /// <summary>
    /// 一维间隔结构
    /// </summary>
    [Serializable]
    public struct Interval : IEquatable<Interval>
    {
        /// <summary>
        /// 最小间隔
        /// </summary>
        public readonly double Min;

        /// <summary>
        /// 最大间隔
        /// </summary>
        public double Max;

        /// <summary>
        /// 使用<see cref =“Min”/> = <see cref =“Max”/> = <paramref name =“value”/>
        /// 初始化此结构
        /// </summary>
        /// <param name="value">最小值和最大值</param>
        private Interval(double value)
        {
            Min = value;
            Max = value;
        }

        /// <summary>
        /// 使用<paramref name =“min”/>和<paramref name =“max”/>值初始化此结构
        /// </summary>
        /// <param name="min">最小间隔值</param>
        /// <param name="max">最大间隔值</param>
        private Interval(double min, double max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Interval ExpandedByValue(double p)
        {
            // 这不是有效的值，忽略它
            if (p.Equals(Coordinate.NullOrdinate))
                return this;

            // 此间隔未见有效的纵坐标
            if (Min.Equals(Coordinate.NullOrdinate))
                return new Interval(p, p);
            var min = p < Min ? p : Min;
            var max = p > Max ? p : Max;
            return new Interval(min, max);
        }

        /// <summary>
        /// 如果此间隔为空/未定义，则获取值
        /// </summary>
        bool IsEmpty { get { return Min.Equals(Coordinate.NullOrdinate); } }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            return 52876 ^ Min.GetHashCode();
        }

        ///<inheritdoc/>
        public override bool Equals(object obj)
        {
            if (!(obj is Interval))
                return false;
            return Equals((Interval)obj);
        }

        ///<inheritdoc/>
        public bool Equals(Interval other)
        {
            if (IsEmpty ^ other.IsEmpty)
                return false;

            if (IsEmpty && other.IsEmpty)
                return true;

            return Min == other.Min &&
                   Max == other.Max;
        }

        ///<inheritdoc/>
        public override string ToString()
        {
            return !IsEmpty
                       ? String.Format(NumberFormatInfo.InvariantInfo, "Interval \u211D[{0}, {1}] (Width={2}) ", Min,
                                       Max, Width)
                       : "Interval \u211D[Uninitialized]";
        }

        /// <summary>
        /// 获取一个值，表示<see cref =“Interval”/>的宽度
        /// </summary>
        public double Width { get { return Max - Min; } }

        /// <summary>
        /// 获取指示间隔中心的值（Min + Width * 0.5）
        /// </summary>
        public double Centre { get { return Min + Width * 0.5; } }

        /// <summary>
        /// 用于计算包含此值的间隔的函数和<paramref name =“interval”/> <see cref =“Interval”/>
        /// </summary>
        /// <param name="interval">间隔</param>
        /// <returns>间隔</returns>
        public Interval ExpandedByInterval(Interval interval)
        {
            if (IsEmpty && interval.IsEmpty)
                return Create();

            if (!IsEmpty && interval.IsEmpty)
                return this;

            if (IsEmpty && !interval.IsEmpty)
                return interval;
            var min = Min < interval.Min ? Min : interval.Min;
            var max = Max > interval.Max ? Max : interval.Max;
            return new Interval(min, max);
        }

        /// <summary>
        /// 测试这个<see cref =“Interval”/>是否重叠<paramref name =“interval”/>的功能。
        /// </summary>
        /// <param name="interval">测试间隔</param>
        /// <returns><c>如果此间隔与<paramref name =“interval”/>重叠，则为</ c></returns>
        public bool Overlaps(Interval interval)
        {
            return Overlaps(interval.Min, interval.Max);
        }

        /// <summary>
        /// 测试这个<see cref =“Interval”/>是否与间隔＆＃x211d; [<paramref name =“min”/>，
        /// <paramref name =“max”/>]重叠的功能。
        /// </summary>
        /// <param name="min">间隔的最小值</param>
        /// <param name="max">间隔的最大值</param>
        /// <returns><c> true </ c>如果此间隔与间隔＆＃x211d重叠; [<paramref name =“min”/>，
        /// <paramref name =“max”/>]</returns>
        public bool Overlaps(double min, double max)
        {
            return !(Min > max) && !(Max < min);
        }

        /// <summary>
        /// 测试这个<see cref =“Interval”/>是否包含<paramref name =“interval”/>的功能。
        /// </summary>
        /// <remarks>这比<see cref="Overlaps(Interval)"/>更僵硬.</remarks>
        /// <param name="interval">测试间隔</param>
        /// <returns><c>如果此间隔包含<paramref name =“interval”/>，则为true</returns>
        public bool Contains(Interval interval)
        {
            return Contains(interval.Min, interval.Max);
        }

        /// <summary>
        /// 测试这个<see cref =“Interval”/>是否包含间隔＆＃x211d; [<paramref name =“min”/>，
        /// <paramref name =“max”/>]）的功能。
        /// </summary>
        /// <remarks>这比<see cref =“Overlaps（double，double）”/>更僵硬</remarks>
        /// <param name="min">间隔的最小值</param>
        /// <param name="max">间隔的最大值</param>
        /// <returns><c> true </ c>如果此间隔包含间隔＆＃x211d; [<paramref name =“min”/>，
        /// <paramref name =“max”/>]</returns>
        public bool Contains(double min, double max)
        {
            return (min >= Min && max <= Max);
        }

        /// <summary>
        /// 测试这个<see cref =“Interval”/>是否包含值<paramref name =“p”/>的功能。
        /// </summary>
        /// <param name="p">要测试的值</param>
        /// <returns><c> true </ c>如果此间隔包含值<paramref name =“p”/></returns>
        public bool Contains(double p)
        {
            return (p >= Min && p <= Max);
        }

        /// <summary>
        /// 测试这个<见cref =“Interval”/>是否与<paramref name =“other”/>相交的函数。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <returns><c> true </ c>如果此间隔与<paramref name =“other”/>相交</returns>
        public bool Intersects(Interval other)
        {
            return Intersects(other.Min, other.Max);
        }

        /// <summary>
        /// 用于测试这个<see cref =“Interval”/>是否与间隔＆＃x211d; 
        /// [<paramref name =“min”/>，<paramref name =“max”/>]相交的功能。
        /// </summary>
        /// <param name="min">间隔的最小值</param>
        /// <param name="max">间隔的最大值</param>
        /// <returns><value> true </ value>如果此间隔与间隔＆＃x211d; 
        /// [<paramref name =“min”/>，<paramref name =“max”/>]相交。</returns>
        public bool Intersects(double min, double max)
        {
            return !(min > Max || max < Min);
        }

        /// <summary>
        /// 创建一个空的或未初始化的间隔
        /// </summary>
        /// <returns>空或未初始化<see cref =“Interval”/></returns>
        public static Interval Create()
        {
            return new Interval(Coordinate.NullOrdinate);
        }

        /// <summary>
        /// 创建一个范围为[value,value]
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>一个<see cref="Interval"/></returns>
        public static Interval Create(double value)
        {
            return new Interval(value);
        }

        /// <summary>
        /// 创建一个范围为＆＃x211d; [<paramref name =“val1”/>，<paramref name =“val2”/>]的间隔。
        /// 如有必要，交换val1和val2。
        /// </summary>
        /// <param name="val1">最小值</param>
        /// <param name="val2">最大值</param>
        /// <returns>An <see cref="Interval"/></returns>
        public static Interval Create(double val1, double val2)
        {
            return val1 < val2
                ? new Interval(val1, val2)
                : new Interval(val2, val1);
        }

        /// <summary>
        /// 创建一个范围为＆＃x211d; [<see cref =“Interval.Min”/>，
        /// <see cref =“Interval.Max”/>]的间隔。
        /// </summary>
        /// <param name="interval">模板间隔</param>
        /// <returns>一<see cref="Interval"/></returns>
        public static Interval Create(Interval interval)
        {
            return new Interval(interval.Min, interval.Max);
        }

        /// <summary>
        /// 平均运算符<see cref =“Interval”/> s
        /// </summary>
        /// <param name="lhs">左手边<see cref="Interval"/></param>
        /// <param name="rhs">右手边 <see cref="Interval"/></param>
        /// <returns><value> true </ value>如果<see cref =“Interval”/> s相等。</returns>
        public static bool operator ==(Interval lhs, Interval rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// 不等式运算符<see cref =“Interval”/> s
        /// </summary>
        /// <param name="lhs">左手边<see cref="Interval"/></param>
        /// <param name="rhs">右手边<see cref="Interval"/></param>
        /// <returns><value>true</value> 如果 <see cref="Interval"/><b>不</b>相等。</returns>
        public static bool operator !=(Interval lhs, Interval rhs)
        {
            return !lhs.Equals(rhs);
        }


    }
}