using Xunit.Abstractions;
using Xunit.Sdk;

namespace ShiftLeft.XUnit
{
    /// <summary>
    /// Non-sealed copy of the TraitAttribute class from xunit.
    /// </summary>
    [TraitDiscoverer("ShiftLeft.XUnit.CustomTraitDiscoverer", "ShiftLeft.XUnit")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class CustomTraitAttribute : Attribute, ITraitAttribute
    {
        public string Name { get; }
        public string Value { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="CustomTraitAttribute"/> class.
        /// </summary>
        /// <param name="name">The trait name</param>
        /// <param name="value">The trait value</param>
        public CustomTraitAttribute(string name, string value) 
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Name = name;
            Value = value;
        }
    }

}
