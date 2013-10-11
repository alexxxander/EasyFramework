using System;
using Easy.Core;
using Easy.Instances.Log;
using Easy.Plugins.Contracts.Log;
using NUnit.Framework;
using Rhino.Mocks;

namespace Easy.Tests.Instances.Log
{
    [TestFixture]
    public class LoggerTest
    {
        private MockRepository _mockery;
        private ILogger _instancePlugin;

        [SetUp]
        public void SetUp()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<ILogger>();

            ThreadContext.Create("Easy.Tests");
            ThreadContext.GetCurrent().SetInstance(new Logger(_instancePlugin));
        }

        [TearDown]
        public void TearDown()
        {
            ThreadContext.GetCurrent().SetInstance<Logger>(null);
        }

        [Test]
        public void Should_log()
        {
            const string originalMessage = "mensagem de teste";
            var message = string.Format("   [Message]: {0}", originalMessage);
            var identifier = ThreadContext.GetCurrent().Identifier;
            Expect.Call(() => _instancePlugin.Log(LogLevel.Debug, identifier, message, null)).Repeat.Once();
            _mockery.ReplayAll();

            Mechanisms.Log.Logger.Message(originalMessage).Debug();

            _mockery.VerifyAll();
        }
    }
}