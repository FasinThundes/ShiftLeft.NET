
using Xunit;

namespace ShiftLeft.XUnit.Tests
{
    /// <summary>
    /// These tests are only used to test the attributes and dotnet CLI integration, they are not supposed to be run, so the are marked with [Ignore]
    /// </summary>
    public class TestsWithAttributes
    {
        [Fact(Skip = "Not supposed to run")]
        [L0Test]
        public void L0()
        {

        }
        [Fact(Skip = "Not supposed to run")]
        [L1Test]
        public void L1()
        {

        }
        [Fact(Skip = "Not supposed to run")]
        [L2Test]
        public void L2()
        {
        }
        [Fact(Skip = "Not supposed to run")]
        [L3Test]
        public void L3()
        {

        }
        [Fact(Skip = "Not supposed to run")]
        [L4Test]
        public void L4()
        {
        }
    }
}