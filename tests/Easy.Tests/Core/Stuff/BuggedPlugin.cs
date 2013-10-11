using System;
using Easy.Core;
using Easy.Plugins;

namespace Easy.Tests.Core.Stuff
{
    public class BuggedPlugin : Plugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            throw new Exception("Something wrong happen");
        }
    }
}