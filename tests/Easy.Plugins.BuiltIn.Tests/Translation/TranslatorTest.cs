using System.Reflection;
using Easy.Core;
using Easy.Plugins.BultIn.Translation;
using Easy.Plugins.Tests.Translation;
using NUnit.Framework;

namespace Easy.Plugins.BuiltIn.Tests.Translation
{
    [TestFixture]
    public class TranslatorTest:MinimalTranslatorTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new TranslatorPlugin();

            PluginInspector pluginInspector;
            var infraAssembly = Assembly.GetExecutingAssembly();

            plugin.Configure(new PluginConfiguration(null, null, null, infraAssembly), out pluginInspector);
            Translator = plugin.GetInstance();
        }
    }
}
