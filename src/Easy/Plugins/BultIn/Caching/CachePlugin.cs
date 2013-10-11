using Easy.Core;
using Easy.Plugins.Contracts.Caching;

namespace Easy.Plugins.BultIn.Caching
{
    internal class CachePlugin :Plugin,ICachePlugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
        }

        public ICache GetInstance()
        {
            return new Cache();
        }
    }
}
