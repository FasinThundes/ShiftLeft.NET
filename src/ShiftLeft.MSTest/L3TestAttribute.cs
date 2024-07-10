using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.ShiftLeft
{
    /// <summary>
    /// L3 functional tests run against testable service deployments. 
    /// This test category requires a service deployment, but might use stubs for key service dependencies.
    /// </summary>
    public class L3TestAttribute : TestPropertyAttribute
    {
        public L3TestAttribute()
            : base(Constants.Level, Constants.L3)
        {
            
        }
    }
}
