
namespace ShiftLeft.XUnit
{

    /// <summary>
    /// L4 tests are a restricted class of integration tests that run against production. 
    /// L4 tests require a full product deployment.
    /// </summary>
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class L4TestAttribute : CustomTraitAttribute
    {
        public L4TestAttribute()
            : base(Constants.Level, Constants.L4)
        {

        }
    }
}
