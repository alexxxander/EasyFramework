using System;
using Easy.Core;
using Easy.Plugins.BultIn.Persistence;
using Easy.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace Easy.Plugins.BuiltIn.Tests.Persistence
{
    [TestFixture]
    public class PersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var moduleName = Guid.NewGuid().ToString();

            var plugin = new PersistencePlugin();
            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(moduleName, null, null, null), out pluginInspector);
            PluginInstance = plugin.GetInstance();
        }
    }
}
