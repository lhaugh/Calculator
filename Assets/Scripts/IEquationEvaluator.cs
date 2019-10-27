namespace Calculator
{
    public interface IEquationEvaluator
    {
        bool TryEvaluate(string equation, out float answer);
    }
}
