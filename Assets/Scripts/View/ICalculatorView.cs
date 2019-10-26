using System;

namespace Calculator.View
{
    public interface ICalculatorView
    {
        event Action<int> NumberPressed;
        
        event Action MulitplyPressed;
        
        event Action DividePressed;
        
        event Action AddPressed;
        
        event Action SubtractPressed;
        
        event Action EqualsPressed;

        event Action DecimalPressed;

        event Action ClearPressed;
        
        event Action OpenBracketPressed;

        event Action CloseBracketPressed;

        string DisplayContents { set; get; }
    }
}
