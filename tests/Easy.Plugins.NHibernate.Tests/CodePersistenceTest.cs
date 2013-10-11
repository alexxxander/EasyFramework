using System.Reflection;
using Easy.Plugins.NHibernate.Persistence;
using Easy.Plugins.NHibernate.Tests.Stuff;
using Easy.Plugins.NHibernate.Tests.Stuff.Code;
using Easy.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace Easy.Plugins.NHibernate.Tests
{
    [TestFixture]
    public class CodePersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new NHibernatePlugin();
            plugin.SetConfigurationInstance(new CodeNHibernateConfig());

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
