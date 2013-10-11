using System;

namespace Easy.Plugins.BultIn.IoC
{
    internal class TypeRegistry
    {
        internal Type Type;
        internal bool IsInteceptable;

        public TypeRegistry(Type implementationType, bool useInterception)
        {
            Type = implementationType;
            IsInteceptable = useInterception;
        }
    }
}