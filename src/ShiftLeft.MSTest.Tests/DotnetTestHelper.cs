using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace MSTest.ShiftLeft.Tests
{
    internal static class DotnetTestHelper
    {
        private static string EscapeArgument(string argument)
        {
            if (argument.Contains(" "))
                return $"\"{argument}\"";

            return argument;
        }
        public static async Task<string[]> RunTestsByFilters(IReadOnlyDictionary<string, string> filters)
        {
            var info = new ProcessStartInfo("dotnet");

            var arguments = new List<string>();

            arguments.Add("test");
            arguments.Add("--framework");
            arguments.Add("net8.0");
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

            info.RedirectStandardOutput = true;
            info.StandardOutputEncoding = Encoding.UTF8;

            info.WorkingDirectory = Path.Combine(Environment.CurrentDirectory, "../../..");

            var p = Process.Start(info);
            if (p == null)
                throw new InvalidOperationException("dotnet test failed to start");

            var output = await p.StandardOutput.ReadToEndAsync();

            return ExtractTestNames(output);
        }

        public static string[] ExtractTestNames(string cliOutput)
        {
            var outputReader = new StringReader(cliOutput);
            var lineIndex = 0;
            var isError = false;
            var testNames = new List<string>();
            while (true)
            {
                lineIndex += 1;
                var line = outputReader.ReadLine();
                if (line == null)
                    break;

                if (lineIndex > 3)
                {
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
            }

            return testNames.ToArray();
        }
    }
}