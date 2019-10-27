namespace Calculator.View
{
    public class CalculatorPresenter
    {
        private ICalculatorView calculatorView;
        private IEquationEvaluator equationParser;

        private bool invalidEquation = false;

        public CalculatorPresenter(
            ICalculatorView calculatorView,
            IEquationEvaluator equationParser
        )
        {
            this.calculatorView = calculatorView;
            this.equationParser = equationParser;

            this.calculatorView.NumberPressed += this.OnNumberPressed;
            this.calculatorView.DecimalPressed += this.OnDecimalPointPressed;
            this.calculatorView.MulitplyPressed += this.OnMulitplyPressed;
            this.calculatorView.DividePressed += this.OnDividePressed;
            this.calculatorView.AddPressed += this.OnAddPressed;
            this.calculatorView.SubtractPressed += this.OnSubtractPressed;
            this.calculatorView.EqualsPressed += this.OnEqualsPressed;
            this.calculatorView.ClearPressed += this.OnClearPressed;
            this.calculatorView.OpenBracketPressed += this.OnOpenBracketPressed;
            this.calculatorView.CloseBracketPressed += this.OnCloseBracketPressed;
        }

        private void OnNumberPressed(int number)
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += "" + number;
        }

        private void OnDecimalPointPressed()
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += ".";
        }

        private void OnMulitplyPressed()
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += "*";
        }

        private void OnDividePressed()
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += "/";
        }

        private void OnAddPressed()
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += "+";
        }

        private void OnSubtractPressed()
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += "-";
        }

        private void OnOpenBracketPressed()
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += "(";
        }

        private void OnCloseBracketPressed()
        {
            if (this.invalidEquation) {
                this.ClearDisplay();
            }
            
            this.calculatorView.DisplayContents += ")";
        }

        private void OnEqualsPressed()
        {
            float answer;
            if (this.equationParser.TryEvaluate(this.calculatorView.DisplayContents, out answer)) {
                this.calculatorView.DisplayContents = "" + answer;
            }
            else {
                this.calculatorView.DisplayContents = "Invalid";
                this.invalidEquation = true;
            }
        }

        private void OnClearPressed()
        {
            this.ClearDisplay();
        }

        private void ClearDisplay()
        {
            this.calculatorView.DisplayContents = "";
            this.invalidEquation = false;
        }
    }
}
