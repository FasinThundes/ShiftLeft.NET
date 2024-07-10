using System.Diagnostics;
using System.Text;

namespace ShiftLeft
{
    public static class DotnetTestHelper
    {
        private static string EscapeArgument(string argument)
        {
            if (argument.Contains(" "))
                return $"\"{argument}\"";

            return argument;
        }
        public static async Task<string> RunTestsByFilters(IReadOnlyDictionary<string, string> filters)
        {
            var info = new ProcessStartInfo("dotnet");

            var arguments = new List<string>();

            arguments.Add("test");
            arguments.Add("--framework");
            arguments.Add(GetCurrentRuntimeTargetFrameworkMoniker());

            arguments.Add("--no-build");
            arguments.Add("--nologo");
            arguments.Add("--logger");
            arguments.Add("console;verbosity=normal");

            arguments.Add("--filter");

            var filterString = new StringBuilder();
            foreach (var filter in filters)
            {
                if (filterString.Length != 0)
                    filterString.Append(" | ");

                filterString.Append($"{filter.Key}={filter.Value}");
            }
            arguments.Add(filterString.ToString());

            info.Arguments = String.Join(" ", arguments.Select(x => EscapeArgument(x)));
            Trace.WriteLine($"{info.FileName} {info.Arguments}");

            info.RedirectStandardOutput = true;
            info.StandardOutputEncoding = Encoding.UTF8;

            info.WorkingDirectory = Path.Combine(Environment.CurrentDirectory, "../../..");

            var p = Process.Start(info);
            if (p == null)
                throw new InvalidOperationException("dotnet test failed to start");

            var output = await p.StandardOutput.ReadToEndAsync();

            return output;
        }

        private static string GetCurrentRuntimeTargetFrameworkMoniker()
        {
            string? tfm = null;
#if NET8_0
            tfm = "net8.0";
#elif NET7_0
            tfm = "net7.0";
#elif NET6_0
            tfm = "net6.0";
#elif NETCOREAPP3_1
            tfm = "netcoreapp3.1";    
#endif
            if (tfm == null) 
                throw new NotSupportedException("Support for calling dotnet test with the current runtime is not supported");

            return tfm;
        }

        public static string[] ExtractTestNames(string cliOutput)
        {
            // dotnet test output examples

            // MSTest

            //Testlauf für "C:\github\Repos\ShiftLeft.NET\src\ShiftLeft.MSTest.Tests\bin\Debug\net8.0\ShiftLeft.MSTest.Tests.dll" (.NETCoreApp,Version=v8.0)
            //Die Testausführung wird gestartet, bitte warten...
            //Insgesamt 1 Testdateien stimmten mit dem angegebenen Muster überein.
            //  Übersprungen L0
            //
            //Der Testlauf war erfolgreich.
            //Gesamtzahl Tests: 1
            //    Übersprungen: 1
            // Gesamtzeit: 0,8666 Sekunden


            // NUnit

            //Testlauf für "C:\github\Repos\ShiftLeft.NET\src\ShiftLeft.NUnit.Tests\bin\Debug\net8.0\ShiftLeft.NUnit.Tests.dll" (.NETCoreApp,Version=v8.0)
            //Die Testausführung wird gestartet, bitte warten...
            //Insgesamt 1 Testdateien stimmten mit dem angegebenen Muster überein.
            //NUnit Adapter 4.5.0.0: Test execution started
            //Running selected tests in C:\github\Repos\ShiftLeft.NET\src\ShiftLeft.NUnit.Tests\bin\Debug\net8.0\ShiftLeft.NUnit.Tests.dll
            //   NUnit3TestExecutor discovered 1 of 1 NUnit test cases using Current Discovery mode, Non-Explicit run
            //L0: Not supposed to run
            //NUnit Adapter 4.5.0.0: Test execution complete
            //  Übersprungen L0 [2 ms]
            //
            //Der Testlauf war erfolgreich.
            //Gesamtzahl Tests: 1
            //    Übersprungen: 1
            // Gesamtzeit: 1,1208 Sekunden


            var outputReader = new StringReader(cliOutput);
            var lineIndex = 0;
            var isError = false;
            var isNUnit = false;
            var testNames = new List<string>();
            while (true)
            {
                lineIndex += 1;
                var line = outputReader.ReadLine();
                if (line == null)
                    break;

                // skip dotnet test header
                if (lineIndex < 4) 
                    continue;
                         
                //TODO: refactor TestAdapter-specific header skipping, so that the code can be moved to the appropriate project (MSTest/NUnit/xUnit)

                // skip NUnit Test Adapter header
                if (line.StartsWith("NUnit Adapter"))
                {
                    // text marks both start and end of the header, so just toggle the flag if found
                    isNUnit = !isNUnit;
                    continue;
                }
                else if(isNUnit)
                {
                    continue;
                }

                // skip stack trace of failed tests (followed by an empty line)
                if (isError)
                {
                    if (String.IsNullOrWhiteSpace(line))
                        isError = false;

                    continue;
                }

                // end parsing after last test (marked by an empty line)
                if (String.IsNullOrWhiteSpace(line))
                    break;

                line = line.Trim();
                var startOfTestName = line.IndexOf(" ");
                if (startOfTestName < 0)
                    throw new FormatException($"Failed to extract test name from line {lineIndex}");

                var state = line.Substring(0, startOfTestName);
                if (state == "Fehler")
                    isError = true;

                var squareBracket = line.Substring(startOfTestName + 1).IndexOf("["); // successfull tests end with runtime in square brackets
                var space = line.Substring(startOfTestName + 1).IndexOf(" "); // space before sqaure bracket (sometimes there, sometimes not?)

                // take space or sqaure bracket as delimiter, whichever comes first, otherwise take all of it
                int endOfTestName;                    
                if (squareBracket > 0 && space > 0)
                {
                    endOfTestName = Math.Min(squareBracket, space);
                }
                else if(squareBracket > 0)
                {
                    endOfTestName = squareBracket;
                }
                else if(space > 0)
                {
                    endOfTestName = space;
                }
                else
                {
                    endOfTestName = line.Length - startOfTestName - 1;
                }

                var testName = line.Substring(startOfTestName + 1, endOfTestName);
                testNames.Add(testName);
            }

            return testNames.ToArray();
        }
    }
}