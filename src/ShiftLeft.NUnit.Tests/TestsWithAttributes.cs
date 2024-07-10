using NUnit.Framework;

namespace ShiftLeft.NUnit.Tests
{
    /// <summary>
    /// These tests are only used to test the attributes and dotnet CLI integration, they are not supposed to be run, so the are marked with [Ignore]
    /// </summary>
    public class TestsWithAttributes
    {
        [Test]
        [L0Test]
        [Ignore("Not supposed to run")]
        public void L0()
        {

        }
        [Test]
        [L1Test]
        [Ignore("Not supposed to run")]
        public void L1()
        {

        }
        [Test]
        [L2Test]
        [Ignore("Not supposed to run")]
        public void L2()
        {
        }
        [Test]
        [L3Test]
        [Ignore("Not supposed to run")]
        public void L3()
        {

        }
        [Test]
        [L4Test]
        [Ignore("Not supposed to run")]
        public void L4()
        {
        }
    }
}