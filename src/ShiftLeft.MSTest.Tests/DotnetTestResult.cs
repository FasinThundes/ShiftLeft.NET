namespace MSTest.ShiftLeft.Tests
{
    internal class DotnetTestResult
    {
        public TestState State { get; }
        public string Name { get; }

        public DotnetTestResult(TestState state, string name)
        {
            State = state;
            Name = name;
        }
    }
}