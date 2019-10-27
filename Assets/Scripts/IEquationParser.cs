using System.Collections.Generic;

namespace Calculator
{
    public interface IEquationParser
    {
        bool TryParse(string equation, out List<EquationToken> tokens);
    }
}
