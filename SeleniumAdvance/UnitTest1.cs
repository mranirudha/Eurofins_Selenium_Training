using NUnit.Framework;
using System;

namespace SeleniumAdvance
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            System.Console.WriteLine("Inside SetUp Method");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Inside Test1");
            Assert.Pass();
        }
        [TearDown]
        public void CleanUp()
        {
            Console.WriteLine("Inside TearDown");
        }
    }
}