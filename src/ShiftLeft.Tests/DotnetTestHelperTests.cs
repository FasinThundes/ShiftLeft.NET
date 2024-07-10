using FluentAssertions;
using System.Text;

namespace ShiftLeft.Tests
{
    [TestClass]
    public class DotnetTestHelperTests
    {
        private static string BuildTestOutput(params DotnetTestResult[] tests)
        {
            var output = new StringBuilder();

            output.AppendLine("Testlauf für \"C:\\github\\Repos\\MSTest.ShiftLeft\\MSTest.ShiftLeft.Tests\\bin\\Debug\\net8.0\\MSTest.ShiftLeft.Tests.dll\"(.NETCoreApp,Version=v8.0)");
            output.AppendLine("Die Testausführung wird gestartet, bitte warten...");
            output.AppendLine("Insgesamt 1 Testdateien stimmten mit dem angegebenen Muster überein.");

            foreach (var test in tests)
            {
                if (test.State == TestState.Success)
                {
                    output.AppendLine($"  Bestanden {test.Name} [< 1 ms]");
                }
                else if(test.State == TestState.Skipped)
                {
                    output.AppendLine($"  Übersprungen {test.Name}");
                }
                else if(test.State == TestState.Error)
                {
                    output.AppendLine($"  Fehler {test.Name}");
                    output.AppendLine("Fehlermeldung:");
                    output.AppendLine(" Fehler bei \"Assert.Fail\".");
                    output.AppendLine("Stapelverfolgung:");
                    output.AppendLine("   at MSTest.ShiftLeft.Tests.TestsWithAttributes.L3() in C:\\github\\Repos\\MSTest.ShiftLeft\\MSTest.ShiftLeft.Tests\\TestsWithAttributes.cs:line 28");
                    output.AppendLine(" at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)");
                    output.AppendLine(" at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)");
                    output.AppendLine("");
                }
            }

            output.AppendLine("");
            output.AppendLine("Der Testlauf war erfolgreich.");
            output.AppendLine("Gesamtzahl Tests: 1");
            output.AppendLine("     Bestanden: 1");
            output.AppendLine(" Gesamtzeit: 0,6063 Sekunden");

           return output.ToString();
        }

        [TestMethod]
        public void ExtractAllTestsWithDifferentResults()
        {
            var output = BuildTestOutput(
                new DotnetTestResult(TestState.Success, "L0"), 
                new DotnetTestResult(TestState.Skipped, "L1"),
                new DotnetTestResult(TestState.Success, "L2"),
                new DotnetTestResult(TestState.Error, "L3"),
                new DotnetTestResult(TestState.Success, "L4"));

            var testNames = DotnetTestHelper.ExtractTestNames(output.ToString());

            testNames.Should().Equal(new[]
            {
                "L0",
                "L1",
                "L2",
                "L3",
                "L4",
            });
        }

        [TestMethod]
        public void ExtractSuccessfullTest()
        {
            var output = BuildTestOutput(new DotnetTestResult(TestState.Success, "L0TestAttributeGeneratesTestProperty"));
            var testNames = DotnetTestHelper.ExtractTestNames(output.ToString());

            testNames.Should().Equal(new[] 
            { 
                "L0TestAttributeGeneratesTestProperty" 
            });
        }
        [TestMethod]
        public void ExtractIgnoredTest()
        {
            var output = BuildTestOutput(new DotnetTestResult(TestState.Skipped, "L1TestAttributeGeneratesTestProperty"));
            var testNames = DotnetTestHelper.ExtractTestNames(output.ToString());

            testNames.Should().Equal(new[]
            {
                "L1TestAttributeGeneratesTestProperty"
            });
        }
        [TestMethod]
        public void ExtractFailedTest()
        {
            var output = BuildTestOutput(new DotnetTestResult(TestState.Error, "L2TestAttributeGeneratesTestProperty"));
            var testNames = DotnetTestHelper.ExtractTestNames(output.ToString());

            testNames.Should().Equal(new[]
            {
                "L2TestAttributeGeneratesTestProperty"
            });
        }
    }
}