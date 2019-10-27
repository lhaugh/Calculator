namespace Calculator
{
    public sealed class EquationToken
    {
        public enum TokenType
        {
            Value = 0,
            CloseBracket,
            Multiplication,
            Division,
            Addition,
            Subtraction,
            OpenBracket,
        }

        public TokenType Type;
        public float Value;
    }
}