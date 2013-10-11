using Easy.Plugins.Contracts.Storage;

namespace Easy.Plugins.BultIn.Storage
{
    internal class MemoryStoragePlugin : Plugin,IStoragePlugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
        }

        public IStorage GetInstance()
        {
            return new MemoryStorage();
        }
    }
}