
namespace ShiftLeft.XUnit
{
    /// <summary>
    /// L2 are functional tests that might require the assembly plus other dependencies, like SQL or the file system.
    /// </summary>
    public class L2TestAttribute : CustomTraitAttribute
    {
        public L2TestAttribute()
            : base(Constants.Level, Constants.L2)
        {

        }
    }
}
