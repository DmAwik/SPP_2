using NUnit.Framework;
using Microsoft.VisualStudio.UnitTesting;
using System.Collections.Generic;
using Fakers;

namespace TestLib
{
    [TestClass]
    public class UnitTests
    {
        private Faker faker = new Faker();

        [TestMethod]
        public void TestConstructorPropertyInitialization()
        {
            var testValue = faker.Create<MyClass2>();
            string name = "defVal";
            Assert.AreEqual(testValue.Name, name);
        }

        [TestMethod]
        public void TestValueType()
        {
            var testValue = faker.Create<int>();
            Assert.IsInstanceOfType(testValue, typeof(int));
        }

        [TestMethod]
        public void TestValueType2()
        {
            var testValue = faker.Create<List<string>>();
            Assert.IsInstanceOfType(testValue, typeof(List<string>));
        }

        [TestMethod]
        public void TestValueType3()
        {
            var testValue = faker.Create<List<List<bool>>>();
            Assert.IsInstanceOfType(testValue, typeof(List<List<bool>>));
        }

        [TestMethod]
        public void TestGenericType()
        {
            var testValue = faker.Create<List<int>>();

            Assert.IsInstanceOfType(testValue, typeof(List<int>));
            Assert.IsTrue(testValue.Count > 0);
        }

        [TestMethod]
        public void TestNullValue()
        {
            var testValue = faker.Create<List<double>>();
            Assert.IsNotNull(testValue);
        }

        public class MyClass2
        {
            private string name = "defVal";

            public MyClass2()
            {

            }

            public string Name
            {
                get { return name; }
            }
        }
    }
}