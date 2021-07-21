using NUnit.Framework;

namespace DataDrivenTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [TestCase("Anirudha1")]
        [TestCase("Anirudha2")]
        [TestCase("Anirudha3")]
        [TestCase("Anirudha4")]
        [Category("DataDriven")]

        public void Test1(string name)
        {
            System.Console.WriteLine(name);

            
        }
    }
}