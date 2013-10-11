using Easy.Core;
using Easy.Plugins;

namespace Easy.Tests.Core.Stuff
{
    public class DummyPlugin : Plugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            pluginInspector.Log("Mensagem {0}","teste");
        }
    }
}
