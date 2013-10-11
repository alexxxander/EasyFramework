using System;
using System.Reflection;

namespace Easy.Plugins.BultIn.IoC
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}