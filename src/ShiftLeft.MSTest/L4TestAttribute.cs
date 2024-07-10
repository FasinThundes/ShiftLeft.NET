using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.ShiftLeft
{
    /// <summary>
    /// L4 tests are a restricted class of integration tests that run against production. 
    /// L4 tests require a full product deployment.
    /// </summary>
    public class L4TestAttribute : TestPropertyAttribute
    {
        public L4TestAttribute()
            : base(Constants.Level, Constants.L4)
        {

        }
    }
}
