#if !HAS_SYSTEM_ICLONEABLE
namespace GeoAPI
{
    /// <summary>
    /// System.ICloneable接口的框架替换。
    /// </summary>
    public interface ICloneable
    {
        /// <summary>
        /// 用于创建一个新对象的功能，该对象是当前实例的（深）副本。
        /// </summary>
        /// <returns>作为此实例的副本的新对象。</returns>
        object Clone();
    }
}
#endif
