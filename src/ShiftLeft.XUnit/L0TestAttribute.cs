
namespace ShiftLeft.XUnit
{
    /// <summary>
    /// L0 tests are unit tests, or tests that depend on code in the assembly under test and nothing else.
    /// L0 is a broad class of fast, in-memory unit tests.
    /// Average execution time per L0 test in an assembly should be less than 60 milliseconds.
    /// </summary>
    public class L0TestAttribute : CustomTraitAttribute
    {
        public L0TestAttribute()
            : base(Constants.Level, Constants.L0)
        {

        }
    }
}
