using System.Reflection;
using Easy.Plugins.NHibernate.Persistence;
using Easy.Plugins.NHibernate.Tests.Stuff;
using Easy.Plugins.NHibernate.Tests.Stuff.Fluently;
using Easy.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace Easy.Plugins.NHibernate.Tests
{
    [TestFixture]
    public class FluentPersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new NHibernatePlugin();
            plugin.SetConfigurationInstance(new FluentlyNHibernateConfig());

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
