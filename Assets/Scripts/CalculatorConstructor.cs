using Calculator.View;
using UnityEngine;

namespace Calculator
{
    public class CalculatorConstructor : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private CalculatorView calculatorView;

#pragma warning restore 0649

        private CalculatorPresenter calculatorPresenter;

        void Start()
        {   
            var equationParser = new EquationParser();
            this.calculatorPresenter = new CalculatorPresenter(
                this.calculatorView,
                equationParser);
        }
    }
}
