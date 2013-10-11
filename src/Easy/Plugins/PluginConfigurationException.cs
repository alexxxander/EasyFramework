using System;

namespace Easy.Plugins
{
    public class PluginConfigurationException : Exception
    {
        public PluginConfigurationException(string getPluginConfigurationInfo, Exception exception):base(getPluginConfigurationInfo,exception)
        {
            
        }
    }
}