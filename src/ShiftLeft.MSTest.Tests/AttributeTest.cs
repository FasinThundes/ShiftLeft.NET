using FluentAssertions;
using System.Reflection;

namespace MSTest.ShiftLeft.Tests
{

    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void L0TestAttributeGeneratesTestProperty()
        {
            var method = typeof(TestsWithAttributes).GetMethod(nameof(TestsWithAttributes.L0));
            var propertyAttribute = method.GetCustomAttribute<TestPropertyAttribute>();
            var level0Attribute = method.GetCustomAttribute<L0TestAttribute>();
            var level1Attribute = method.GetCustomAttribute<L1TestAttribute>();
            var level2Attribute = method.GetCustomAttribute<L2TestAttribute>();
            var level3Attribute = method.GetCustomAttribute<L3TestAttribute>();
            var level4Attribute = method.GetCustomAttribute<L4TestAttribute>();

            propertyAttribute.Should().NotBeNull();
            propertyAttribute.Name.Should().Be(Constants.Level);
            propertyAttribute.Value.Should().Be(Constants.L0);

            level0Attribute.Should().NotBeNull();
            level0Attribute.Name.Should().Be(Constants.Level);
            level0Attribute.Value.Should().Be(Constants.L0);

            level1Attribute.Should().BeNull();
            level2Attribute.Should().BeNull();
            level3Attribute.Should().BeNull();
            level4Attribute.Should().BeNull();
        }

        [TestMethod]
        public void L1TestAttributeGeneratesTestProperty()
        {
            var method = typeof(TestsWithAttributes).GetMethod(nameof(TestsWithAttributes.L1));
            var propertyAttribute = method.GetCustomAttribute<TestPropertyAttribute>();
            var level0Attribute = method.GetCustomAttribute<L0TestAttribute>();
            var level1Attribute = method.GetCustomAttribute<L1TestAttribute>();
            var level2Attribute = method.GetCustomAttribute<L2TestAttribute>();
            var level3Attribute = method.GetCustomAttribute<L3TestAttribute>();
            var level4Attribute = method.GetCustomAttribute<L4TestAttribute>();

            propertyAttribute.Should().NotBeNull();
            propertyAttribute.Name.Should().Be(Constants.Level);
            propertyAttribute.Value.Should().Be(Constants.L1);

            level1Attribute.Should().NotBeNull();
            level1Attribute.Name.Should().Be(Constants.Level);
            level1Attribute.Value.Should().Be(Constants.L1);

            level0Attribute.Should().BeNull();
            level2Attribute.Should().BeNull();
            level3Attribute.Should().BeNull();
            level4Attribute.Should().BeNull();
        }

        [TestMethod]
        public void L2TestAttributeGeneratesTestProperty()
        {
            var method = typeof(TestsWithAttributes).GetMethod(nameof(TestsWithAttributes.L2));
            var propertyAttribute = method.GetCustomAttribute<TestPropertyAttribute>();
            var level0Attribute = method.GetCustomAttribute<L0TestAttribute>();
            var level1Attribute = method.GetCustomAttribute<L1TestAttribute>();
            var level2Attribute = method.GetCustomAttribute<L2TestAttribute>();
            var level3Attribute = method.GetCustomAttribute<L3TestAttribute>();
            var level4Attribute = method.GetCustomAttribute<L4TestAttribute>();

            propertyAttribute.Should().NotBeNull();
            propertyAttribute.Name.Should().Be(Constants.Level);
            propertyAttribute.Value.Should().Be(Constants.L2);

            level2Attribute.Should().NotBeNull();
            level2Attribute.Name.Should().Be(Constants.Level);
            level2Attribute.Value.Should().Be(Constants.L2);

            level0Attribute.Should().BeNull();
            level1Attribute.Should().BeNull();
            level3Attribute.Should().BeNull();
            level4Attribute.Should().BeNull();
        }

        [TestMethod]
        public void L3TestAttributeGeneratesTestProperty()
        {
            var method = typeof(TestsWithAttributes).GetMethod(nameof(TestsWithAttributes.L3));
            var propertyAttribute = method.GetCustomAttribute<TestPropertyAttribute>();
            var level0Attribute = method.GetCustomAttribute<L0TestAttribute>();
            var level1Attribute = method.GetCustomAttribute<L1TestAttribute>();
            var level2Attribute = method.GetCustomAttribute<L2TestAttribute>();
            var level3Attribute = method.GetCustomAttribute<L3TestAttribute>();
            var level4Attribute = method.GetCustomAttribute<L4TestAttribute>();

            propertyAttribute.Should().NotBeNull();
            propertyAttribute.Name.Should().Be(Constants.Level);
            propertyAttribute.Value.Should().Be(Constants.L3);

            level3Attribute.Should().NotBeNull();
            level3Attribute.Name.Should().Be(Constants.Level);
            level3Attribute.Value.Should().Be(Constants.L3);

            level0Attribute.Should().BeNull();
            level1Attribute.Should().BeNull();
            level2Attribute.Should().BeNull();
            level4Attribute.Should().BeNull();
        }

        [TestMethod]
        public void L4TestAttributeGeneratesTestProperty()
        {
            var method = typeof(TestsWithAttributes).GetMethod(nameof(TestsWithAttributes.L4));
            var propertyAttribute = method.GetCustomAttribute<TestPropertyAttribute>();
            var level0Attribute = method.GetCustomAttribute<L0TestAttribute>();
            var level1Attribute = method.GetCustomAttribute<L1TestAttribute>();
            var level2Attribute = method.GetCustomAttribute<L2TestAttribute>();
            var level3Attribute = method.GetCustomAttribute<L3TestAttribute>();
            var level4Attribute = method.GetCustomAttribute<L4TestAttribute>();

            propertyAttribute.Should().NotBeNull();
            propertyAttribute.Name.Should().Be(Constants.Level);
            propertyAttribute.Value.Should().Be(Constants.L4);

            level4Attribute.Should().NotBeNull();
            level4Attribute.Name.Should().Be(Constants.Level);
            level4Attribute.Value.Should().Be(Constants.L4);

            level0Attribute.Should().BeNull();
            level1Attribute.Should().BeNull();
            level2Attribute.Should().BeNull();
            level3Attribute.Should().BeNull();
        }
    }
}