﻿using System.Collections.Generic;
using EasyArchitecture.Plugins.Validation.Translation.Stuff;
using EasyArchitecture.Translation.Plugin.Contracts;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Validation.Translation
{
    [TestFixture]
    public abstract class MinimalTranslatorTest
    {
        protected ITranslator Translator;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_match_same_name_properties()
        {
            var entity = new Dog() { Age = 15, Id = 8, Name = "Rex" };
            var expected = new DogDto() { Age = 15, Id = 8, Name = "Rex" };

            var actual = Translator.Translate<Dog, DogDto>(entity);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_match_same_name_properties_only()
        {
            var entity = new Dog() { Age = 15, Id = 8, Name = "Rex" };
            var expected = new AnotherDogDto() { Id = 8, Name = "Rex" };

            var actual = Translator.Translate<Dog, AnotherDogDto>(entity);

            Assert.That(actual, Is.EqualTo(expected));
        }

        //TODO: translate specific
        [Test]
        [Ignore("Need to analise")]
        public void Should_translate_using_custom_rule()
        {
            var entity = new Dog() { Age = 15, Id = 8, Name = "Rex" };
            var expected = new DogDto() { Age = 16, Id = 8, Name = "NewName" };

            ////TODO: not allowed, just for test
            //var internalTranslator = (Translator)Translator;
            //internalTranslator.MapType<Dog, DogDto>(
            //    (source, target) =>
            //    {
            //        target.Id = source.Id;
            //        target.Age = source.Age + 1;
            //        target.Name = "NewName";
            //        return target;
            //    }
            //    );


            var actual = Translator.Translate<Dog, DogDto>(entity);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_translate_lists()
        {
            var entityList = new List<Dog>
                                 {
                                     new Dog() {Age = 15, Id = 8, Name = "Rex"},
                                     new Dog() {Age = 4, Id = 1, Name = "Jimmy"},
                                     new Dog() {Age = 95, Id = 3, Name = "Arthur"}
                                 };

            var expected = new List<DogDto>()
                    {
                                     new DogDto() {Age = 15, Id = 8, Name = "Rex"},
                                     new DogDto() {Age = 4, Id = 1, Name = "Jimmy"},
                                     new DogDto() {Age = 95, Id = 3, Name = "Arthur"}
                    };

            var actual = Translator.Translate<List<Dog>, List<DogDto>>(entityList);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}