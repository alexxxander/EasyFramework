using System;

namespace Easy.Configuration.Exceptions
{
    public class NotConfiguredException : Exception
    {
        public string ModuleName { get; private set; }

        public NotConfiguredException()
        {
        }

        public NotConfiguredException(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}