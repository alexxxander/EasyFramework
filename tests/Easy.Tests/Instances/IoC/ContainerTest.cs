using Easy.Core;
using Easy.Mechanisms.IoC;
using Easy.Plugins.Contracts.IoC;
using Easy.Plugins.Contracts.Log;
using Easy.Tests.Instances.IoC.Stuff;
using NUnit.Framework;
using Rhino.Mocks;

namespace Easy.Tests.Instances.IoC
{
    [TestFixture]
    public class ContainerTest
    {
        private MockRepository _mockery;
        private IContainer _instancePlugin;

        [SetUp]
        public void Setup()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<IContainer>();

            ThreadContext.Create("Easy.Tests");
            ThreadContext.GetCurrent().SetInstance(new Easy.Instances.IoC.Container(_instancePlugin));
            ThreadContext.GetCurrent().SetInstance(new Easy.Instances.Log.Logger(MockRepository.GenerateStub<ILogger>()));

        }

        [Test]
        public void Can_get_a_facade()
        {
            Expect.Call(() => _instancePlugin.Resolve<IDogFacade>());
            _mockery.ReplayAll();

            Container.Resolve<IDogFacade>();

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_get_a_overrided_facade()
        {
            Expect.Call(() => _instancePlugin.Register<IDogFacade,DummyDogFacade>());
            _mockery.ReplayAll();

            Container.Register<IDogFacade, DummyDogFacade>();

            _mockery.VerifyAll();
        }
    }
}
