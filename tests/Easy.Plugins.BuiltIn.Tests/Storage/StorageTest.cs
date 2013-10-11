using Easy.Plugins.BultIn.Storage;
using Easy.Plugins.Tests.Storage;
using NUnit.Framework;

namespace Easy.Plugins.BuiltIn.Tests.Storage
{
    [TestFixture]
    public class StorageTest:MinimalStorageTest
    {
        [SetUp]
        public override void SetUp()
        {
            Storage = new MemoryStoragePlugin().GetInstance();
        }
    }
}
