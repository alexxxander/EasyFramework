﻿using System;
using Easy.Plugins.Contracts.Persistence;
using Easy.Plugins.Tests.Persistence.Stuff;
using NUnit.Framework;

namespace Easy.Plugins.Tests.Persistence
{
    [TestFixture]
    public abstract class MinimalPersistenceTest
    {
        protected IPersistence PluginInstance;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_begin_transaction()
        {
            Assert.That(() => PluginInstance.BeginTransaction(), Throws.Nothing);

            //just for remove lock
            try {PluginInstance.RollbackTransaction();}catch {}
        }

        [Test]
        public void Should_commit_transaction()
        {
            Assert.That(() => PluginInstance.BeginTransaction(), Throws.Nothing);
            Assert.That(() => PluginInstance.CommitTransaction(), Throws.Nothing);
        }

        [Test]
        public void Should_rollback_transaction()
        {
            Assert.That(() => PluginInstance.BeginTransaction(), Throws.Nothing);
            Assert.That(() => PluginInstance.RollbackTransaction(), Throws.Nothing);
        }

        [Test]
        public void Should_save_entity()
        {
            var uniqueDogName = Guid.NewGuid().ToString();

            var dog = new Dog { Age = 15, Name = uniqueDogName };
            
            Assert.That(() => PluginInstance.Save(dog), Throws.Nothing);
        }

        [Test]
        public void Should_get_entity()
        {
            var uniqueDogName = Guid.NewGuid().ToString();

            var dog = new Dog { Age = 15, Name = uniqueDogName };

            PluginInstance.Save(dog);

            var dogs = PluginInstance.Get<Dog>(new Dog() { Age = 15 ,Name = uniqueDogName});

            Assert.That(dogs[0], Is.EqualTo(dog));
        }

        [Test]
        public void Should_get_list_of_entity()
        {
            var uniqueDogName = Guid.NewGuid().ToString();

            var dogA = new Dog { Age = 10, Name = uniqueDogName };
            var dogB = new Dog { Age = 15, Name = uniqueDogName };
            var dogC = new Dog { Age = 25, Name = uniqueDogName };

            PluginInstance.Save(dogA);
            PluginInstance.Save(dogB);
            PluginInstance.Save(dogC);

            var dogs = PluginInstance.Get<Dog>(new Dog { Name = uniqueDogName });

            Assert.That(dogs.Count, Is.EqualTo(3));
        }


        [Test]
        public void Should_update_entity()
        {
            var uniqueDogName = Guid.NewGuid().ToString();

            var dog = new Dog { Age = 15, Name = uniqueDogName };

            PluginInstance.Save(dog);

            dog.Age = 200;

            PluginInstance.Update(dog);

            var dogs = PluginInstance.Get<Dog>(new Dog { Name = uniqueDogName });

            Assert.That(dogs[0].Age, Is.EqualTo(200));
        }

        [Test]
        public void Should_delete_entity()
        {
            var uniqueDogName = Guid.NewGuid().ToString();

            var dog = new Dog { Age = 15, Name = uniqueDogName };

            PluginInstance.Save(dog);
            PluginInstance.Delete(dog);

            var dogs = PluginInstance.Get<Dog>(new Dog {Age = 15, Name = uniqueDogName});

            Assert.That(dogs.Count, Is.EqualTo(0));
        }
    }
}
