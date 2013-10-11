using System;
using Easy.Core;
using Easy.Plugins.BultIn.Log;
using Easy.Plugins.Tests.Log;
using NUnit.Framework;

namespace Easy.Plugins.BuiltIn.Tests.Log
{
    [TestFixture]
    public class LoggerTest:MinimalLoggerTest
    {
        [SetUp]
        public override void SetUp()
        {
            ModuleName = Guid.NewGuid().ToString();

            var loggerPlugin = new LoggerPlugin();
            PluginInspector pluginInspector;
            loggerPlugin.Configure(new PluginConfiguration(ModuleName, null, null, null), out pluginInspector);
            Logger = loggerPlugin.GetInstance();
        }
    }
}
