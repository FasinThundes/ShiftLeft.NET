using System.Diagnostics;

namespace ShiftLeft.NUnit.Tests
{
    [SetUpFixture]
    public class SetupTrace
    {
        [OneTimeSetUp]
        public void StartTest()
        {
            //In contrast to MSTest, Trace/Debug is not by default redirected to the test output in Visual Studio (only Console output is), so we need to redirect it ourselves.
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            Trace.Flush();
        }
    }
}