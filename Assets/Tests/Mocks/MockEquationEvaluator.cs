using System;

namespace Calculator.Tests
{
    public class MockEquationEvaluator : IEquationEvaluator
    {
        public bool BadEquation = false;

        public bool TryEvaluate(string equation, out float answer)
        {
            if (this.BadEquation) {
                answer = 0;
                return false;
            }

            answer = 99999f;
            return true;
        }
    }
}
