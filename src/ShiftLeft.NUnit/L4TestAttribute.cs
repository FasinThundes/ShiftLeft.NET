using NUnit.Framework;

namespace ShiftLeft.NUnit
{
    /// <summary>
    /// L4 tests are a restricted class of integration tests that run against production. 
    /// L4 tests require a full product deployment.
    /// </summary>
    public class L4TestAttribute : PropertyAttribute
    {
        public L4TestAttribute()
            : base(Constants.Level, Constants.L4)
        {

        }
    }
}
