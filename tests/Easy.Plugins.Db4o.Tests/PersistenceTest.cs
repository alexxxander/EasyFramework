using System;
using System.Reflection;
using Easy.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace Easy.Plugins.Db4o.Tests
{
    [TestFixture]
    public class PersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new Db4oPlugin();
            var moduleName = Guid.NewGuid().ToString();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(moduleName, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
