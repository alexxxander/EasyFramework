using System;
using System.Reflection;
using Easy.Core;
using Easy.Plugins.Tests.Log;
using NUnit.Framework;

namespace Easy.Plugins.log4net.Tests
{
    [TestFixture]
    public class LoggerTest:MinimalLoggerTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new Log4NetPlugin();

            base.ModuleName = Guid.NewGuid().ToString();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(base.ModuleName, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            base.Logger= plugin.GetInstance();
        }
    }
}
