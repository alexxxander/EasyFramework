using Easy.Plugins.BultIn.Caching;
using Easy.Plugins.Tests.Caching;
using NUnit.Framework;

namespace Easy.Plugins.BuiltIn.Tests.Caching
{
    [TestFixture]
    public class CacheTest:MinimalCacheTest
    {
        [SetUp]
        public override void SetUp()
        {
            Cache =  new CachePlugin().GetInstance();
        }
    }
}