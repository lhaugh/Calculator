namespace Calculator.View
{
    public class CalculatorPresenter
    {
        private ICalculatorView calculatorView;
        private IEquationParser equationParser;

        public CalculatorPresenter(
            ICalculatorView calculatorView,
            IEquationParser equationParser
        )
        {
            this.calculatorView = calculatorView;
            this.equationParser = equationParser;

            this.calculatorView.NumberPressed += this.NumberPressed;
            this.calculatorView.DecimalPressed += this.DecimalPointPressed;
            this.calculatorView.MulitplyPressed += this.MulitplyPressed;
            this.calculatorView.DividePressed += this.DividePressed;
            this.calculatorView.AddPressed += this.AddPressed;
            this.calculatorView.SubtractPressed += this.SubtractPressed;
            this.calculatorView.EqualsPressed += this.EqualsPressed;
            this.calculatorView.ClearPressed += this.ClearPressed;
            this.calculatorView.OpenBracketPressed += this.OpenBracketPressed;
            this.calculatorView.CloseBracketPressed += this.CloseBracketPressed;
        }

        private void NumberPressed(int number)
        {
            this.calculatorView.DisplayContents += "" + number;
        }

        private void DecimalPointPressed()
        {
            this.calculatorView.DisplayContents += ".";
        }

        private void MulitplyPressed()
        {
            this.calculatorView.DisplayContents += "*";
        }

        private void DividePressed()
        {
            this.calculatorView.DisplayContents += "/";
        }

        private void AddPressed()
        {
            this.calculatorView.DisplayContents += "+";
        }

        private void SubtractPressed()
        {
            this.calculatorView.DisplayContents += "-";
        }

        private void OpenBracketPressed()
        {
            this.calculatorView.DisplayContents += "(";
        }

        private void CloseBracketPressed()
        {
            this.calculatorView.DisplayContents += ")";
        }

        private void EqualsPressed()
        {
            this.calculatorView.DisplayContents = "" + this.equationParser.Parse(this.calculatorView.DisplayContents);
        }

        private void ClearPressed()
        {
            this.calculatorView.DisplayContents = "";
        }
    }
}
