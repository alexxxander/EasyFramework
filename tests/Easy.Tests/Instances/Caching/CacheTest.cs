using System;
using Easy.Core;
using Easy.Mechanisms.Caching;
using Easy.Plugins.Contracts.Caching;
using Easy.Plugins.Contracts.Log;
using NUnit.Framework;
using Rhino.Mocks;

namespace Easy.Tests.Instances.Caching
{
    [TestFixture]
    public class CacheTest
    {
        private MockRepository _mockery;
        private ICache _instancePlugin;

        [SetUp]
        public void SetUp()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<ICache>();

            ThreadContext.Create("Easy.Tests");
            ThreadContext.GetCurrent().SetInstance(new Easy.Instances.Caching.Cache(_instancePlugin));
            ThreadContext.GetCurrent().SetInstance(new Easy.Instances.Log.Logger(MockRepository.GenerateStub<ILogger>()));
        }

        [Test]
        public void Should_add()
        {
            var key = Guid.NewGuid().ToString();

            Expect.Call(() => _instancePlugin.Add(key, 1));
            _mockery.ReplayAll();

            Cache.This(1).With.NoExpiration.At(key);

            _mockery.VerifyAll();
        }

        [Test]
        public void Should_remove()
        {
            var key = Guid.NewGuid().ToString();

            Expect.Call(() => _instancePlugin.Remove(key));
            _mockery.ReplayAll();

            Cache.Remove.At(key);

            _mockery.VerifyAll();
        }


        [Test]
        public void Should_clear()
        {
            Expect.Call(_instancePlugin.Flush);
            _mockery.ReplayAll();

            Cache.Clear();

            _mockery.VerifyAll();
        }


        [Test]
        public void Should_add_with_expiration()
        {
            var key = Guid.NewGuid().ToString();
            Expect.Call(() => _instancePlugin.Add(key, 1, new TimeSpan(0, 0, 1)));

            _mockery.ReplayAll();

            Cache.This(1).With.ExpirationOf(1).Seconds.At(key);

            _mockery.VerifyAll();
        }
    }
}