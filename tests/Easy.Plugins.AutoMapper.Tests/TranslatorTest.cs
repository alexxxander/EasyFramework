using System.Reflection;
using Easy.Core;
using Easy.Plugins.Tests.Translation;
using NUnit.Framework;

namespace Easy.Plugins.AutoMapper.Tests
{
    [TestFixture]
    public class TranslatorTest : MinimalTranslatorTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new AutoMapperPlugin();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            Translator = plugin.GetInstance();
        }
    }
}
