using System.Reflection;

namespace EasyArchitecture.Plugins
{
    public interface IObjectMapperPlugin
    {
        void Configure(Assembly assembly);
        T1 Map<T, T1>(T p0);
        T1 Map<T, T1>(T p0, T1 obj1);
    }
}