using FluentAssertions;
using System.Diagnostics;

namespace ShiftLeft.XUnit.Tests
{

    public class DotnetCliTests
    {

// these test methods invoke dotnet CLI, which is not available in .Net Framework
#if NETCOREAPP3_1_OR_GREATER

        [Fact]
        public async Task L0TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L0 } }, false);
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be($"{typeof(TestsWithAttributes).FullName}.{nameof(TestsWithAttributes.L0)}");
        }

        [Fact]
        public async Task L1TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L1 } }, false);
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be($"{typeof(TestsWithAttributes).FullName}.{nameof(TestsWithAttributes.L1)}");
        }

        [Fact]
        public async Task L2TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L2 } }, false);
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be($"{typeof(TestsWithAttributes).FullName}.{nameof(TestsWithAttributes.L2)}");
        }

        [Fact]
        public async Task L3TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L3 } }, false);
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be($"{typeof(TestsWithAttributes).FullName}.{nameof(TestsWithAttributes.L3)}");
        }

        [Fact]
        public async Task L4TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L4 } }, false);
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be($"{typeof(TestsWithAttributes).FullName}.{nameof(TestsWithAttributes.L4)}");
        }
#endif
    }
}