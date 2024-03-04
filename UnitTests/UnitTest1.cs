namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("siemanko");
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
        }
    }
}