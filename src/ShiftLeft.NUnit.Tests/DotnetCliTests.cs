using FluentAssertions;
using NUnit.Framework;
using System.Diagnostics;

namespace ShiftLeft.NUnit.Tests
{

    public class DotnetCliTests
    {

// these test methods invoke dotnet CLI, which is not available in .Net Framework
#if NETCOREAPP3_1_OR_GREATER

        [Test]
        public async Task L0TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L0 } });
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be(nameof(TestsWithAttributes.L0));
        }

        [Test]
        public async Task L1TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L1 } });
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be(nameof(TestsWithAttributes.L1));
        }

        [Test]
        public async Task L2TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L2 } });
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be(nameof(TestsWithAttributes.L2));
        }

        [Test]
        public async Task L3TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L3 } });
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be(nameof(TestsWithAttributes.L3));
        }

        [Test]
        public async Task L4TestCanBeFilteredWithDotnetTestCli()
        {
            var output = await DotnetTestHelper.RunTestsByFilters(new Dictionary<string, string> { { Constants.Level, Constants.L4 } });
            var testsRun = DotnetTestHelper.ExtractTestNames(output);

            testsRun.Should().HaveCount(1);
            testsRun.First().Should().Be(nameof(TestsWithAttributes.L4));
        }
#endif
    }
}