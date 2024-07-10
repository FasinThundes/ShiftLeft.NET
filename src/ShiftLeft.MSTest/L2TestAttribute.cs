using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.ShiftLeft
{
    /// <summary>
    /// L2 are functional tests that might require the assembly plus other dependencies, like SQL or the file system.
    /// </summary>
    public class L2TestAttribute : TestPropertyAttribute
    {
        public L2TestAttribute()
            : base(Constants.Level, Constants.L2)
        {

        }
    }
}
