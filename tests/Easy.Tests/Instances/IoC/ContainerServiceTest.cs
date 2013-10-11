using Easy.Configuration.Exceptions;
using Easy.Mechanisms.IoC;
using Easy.Tests.Instances.IoC.Stuff;
using NUnit.Framework;

namespace Easy.Tests.Instances.IoC
{
    [TestFixture]
    public class ContainerServiceTest
    {
        [Test]
        public void Should_throw_exception_when_resolve_called_whithout_configuration()
        {
            Assert.That(()=>Container.Resolve<IDogFacade>(), Throws.InstanceOf<NotConfiguredException>());
        }
    }
}
