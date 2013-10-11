using System;
using System.Reflection;
using Easy.Core;
using Easy.Plugins.BultIn.Validation;
using Easy.Plugins.Tests.Validation;
using NUnit.Framework;

namespace Easy.Plugins.BuiltIn.Tests.Validation
{
    [TestFixture]
    public class ValidatorTest : MinimalValidatorTest
    {
        [SetUp]
        public override void SetUp()
        {
            var moduleName = Guid.NewGuid().ToString();

            var validatorPlugin = new ValidatorPlugin();
            PluginInspector pluginInspector;

            var infraAssembly = Assembly.GetExecutingAssembly();

            validatorPlugin.Configure(new PluginConfiguration(moduleName, null, null, infraAssembly), out pluginInspector);
            Validator = validatorPlugin.GetInstance();
        }
    }
}
