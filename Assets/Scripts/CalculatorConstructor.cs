using Calculator.View;
using UnityEngine;

namespace Calculator
{
    public class CalculatorConstructor : MonoBehaviour
    {
        [SerializeField]
        private CalculatorView calculatorView = null;


        private CalculatorPresenter calculatorPresenter;

        void Start()
        {
            var equationParser = new EquationParser();
            var equationEvaluator = new EquationEvaluator(equationParser);
            this.calculatorPresenter = new CalculatorPresenter(
                this.calculatorView,
                equationEvaluator);
        }
    }
}
