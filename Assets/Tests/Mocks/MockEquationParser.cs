namespace Calculator.Tests
{
    public class MockEquationParser : IEquationParser
    {
        public float Parse(string equation)
        {
            return 99999f;
        }
    }
}
