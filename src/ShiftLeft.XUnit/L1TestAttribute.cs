
namespace ShiftLeft.XUnit
{
    /// <summary>
    /// L1 tests are unit tests, or tests that depend on code in the assembly under test and nothing else. 
    /// Average execution time per L1 test in an assembly should be less than 400 milliseconds.
    /// No test at this level should exceed 2 seconds.
    /// </summary>
    public class L1TestAttribute : CustomTraitAttribute
    {
        public L1TestAttribute()
            : base(Constants.Level, Constants.L1)
        {

        }
    }
}
