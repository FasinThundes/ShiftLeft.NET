namespace MSTest.ShiftLeft.Tests
{
    /// <summary>
    /// These tests are only used to test the attributes and dotnet CLI integration, they are not supposed to be run, so the are marked with [Ignore]
    /// </summary>
    [TestClass]
    public class TestsWithAttributes
    {
        [TestMethod]
        [L0Test]
        [Ignore]
        public void L0()
        {

        }
        [TestMethod]
        [L1Test]
        [Ignore]
        public void L1()
        {

        }
        [TestMethod]
        [L2Test]
        [Ignore]
        public void L2()
        {
        }
        [TestMethod]
        [L3Test]
        [Ignore]
        public void L3()
        {
            
        }
        [TestMethod]
        [L4Test]
        [Ignore]
        public void L4()
        {
        }
    }
}