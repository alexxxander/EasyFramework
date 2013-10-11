using Easy.Plugins.BultIn.IoC;
using Easy.Plugins.Tests.IoC;
using NUnit.Framework;

namespace Easy.Plugins.BuiltIn.Tests.IoC
{
    [TestFixture]
    public class ContainerTest:MinimalContainerTest
    {
        [SetUp]
        public override void SetUp()
        {
            Container = new ContainerPlugin().GetInstance();
        }
    }
}
