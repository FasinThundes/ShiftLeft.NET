using Xunit.Abstractions;
using Xunit.Sdk;

namespace ShiftLeft.XUnit
{
    /// <summary>
    /// Custom trait discoverer to allow our custom traits to be handled properly by xunit, specifically when filtering tests by traits in dotnet test
    /// </summary>
    public class CustomTraitDiscoverer : ITraitDiscoverer
    {
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo attributeInfo)
        {
            string testCase;
            var attribute = attributeInfo as ReflectionAttributeInfo;
            var traitAttribute = attribute?.Attribute as CustomTraitAttribute;
            if (traitAttribute != null)
            {
                yield return new KeyValuePair<string, string>(traitAttribute.Name, traitAttribute.Value);
            }
        }
    }

}
