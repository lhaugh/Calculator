using System;

namespace Calculator.View.Tests
{
    public class MockCalculatorView : ICalculatorView
    {
        public string DisplayContents
        { 
            get { return this.displayContents; } 
            set { this.displayContents = value;} 
        }

        public event Action<int> NumberPressed;
        public event Action MulitplyPressed;
        public event Action DividePressed;
        public event Action AddPressed;
        public event Action SubtractPressed;
        public event Action EqualsPressed;
        public event Action DecimalPressed;
        public event Action ClearPressed;
        public event Action OpenBracketPressed;
        public event Action CloseBracketPressed;

        public string displayContents;


        public void RaiseNumberPressed(int number)
        {
            this.NumberPressed(number);
        }

        public void RaiseMultiplyPressed()
        {
            this.MulitplyPressed();
        }

        public void RaiseDividePressed()
        {
            this.DividePressed();
        }

        public void RaiseAddPressed()
        {
            this.AddPressed();
        }

        public void RaiseSubtractPressed()
        {
            this.SubtractPressed();
        }

        public void RaiseDecimalPressed()
        {
            this.DecimalPressed();
        }

        public void RaiseClearPressed()
        {
            this.ClearPressed();
        }

        public void RaiseEqualPressed()
        {
            this.EqualsPressed();
        }

        public void RaiseOpenBracketPressed()
        {
            this.OpenBracketPressed();
        }

        public void RaiseCloseBracketPressed()
        {
            this.CloseBracketPressed();
        }
    }
}
