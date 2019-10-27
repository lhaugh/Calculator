using NUnit.Framework;
using Calculator.Tests;

namespace Calculator.View.Tests
{
    public class CalculatorPresenterTests
    {
        private CalculatorPresenter presenter;

        private MockCalculatorView mockView;
        private MockEquationEvaluator mockEquationEvaluator;

        [SetUp]
        public void Initialize()
        {
            this.mockView = new MockCalculatorView();
            this.mockEquationEvaluator = new MockEquationEvaluator();

            this.presenter = new CalculatorPresenter(
                this.mockView,
                this.mockEquationEvaluator
            );
        }

        #region NumberPressed

        [TestCase(0, "0")]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [TestCase(4, "4")]
        [TestCase(5, "5")]
        [TestCase(6, "6")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(9, "9")]
        public void UpdatesDisplay_WhenNumberPressed(int button, string expectedDisplay)
        {
            this.mockView.RaiseNumberPressed(button);

            Assert.That(this.mockView.displayContents, Is.EqualTo(expectedDisplay));
        }

        [Test]
        public void AppendsDisplay_WhenNumberPressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "3.14";
            
            this.mockView.RaiseNumberPressed(1);

            Assert.That(this.mockView.displayContents, Is.EqualTo("3.141"));
        }

        [Test]
        public void Clears_WhenNumberPressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = ")";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseNumberPressed(1);

            Assert.That(this.mockView.displayContents, Is.EqualTo("1"));
        }

        #endregion

        #region DecimalPressed

        [Test]
        public void UpdatesDisplay_WhenDecimalPressed()
        {
            this.mockView.RaiseDecimalPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("."));
        }

        [Test]
        public void AppendsDisplay_WhenDecimalPressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "314";
            
            this.mockView.RaiseDecimalPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("314."));
        }

        [Test]
        public void Clears_WhenDecimalPressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = ")";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseDecimalPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("."));
        }

        #endregion

        #region MultiplyPressed

        [Test]
        public void UpdatesDisplay_WhenMultiplyPressed()
        {
            this.mockView.RaiseMultiplyPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("*"));
        }

        [Test]
        public void AppendsDisplay_WhenMultiplyPressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "314";
            
            this.mockView.RaiseMultiplyPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("314*"));
        }

        [Test]
        public void Clears_WhenMultiplyPressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = ")";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseMultiplyPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("*"));
        }

        #endregion

        #region DividePressed

        [Test]
        public void UpdatesDisplay_WhenDividePressed()
        {
            this.mockView.RaiseDividePressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("/"));
        }

        [Test]
        public void AppendsDisplay_WhenDividePressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "314";
            
            this.mockView.RaiseDividePressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("314/"));
        }

        [Test]
        public void Clears_WhenDividePressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = ")";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseDividePressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("/"));
        }

        #endregion

        #region AddPressed

        [Test]
        public void UpdatesDisplay_WhenAddPressed()
        {
            this.mockView.RaiseAddPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("+"));
        }

        [Test]
        public void AppendsDisplay_WhenAddPressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "314";
            
            this.mockView.RaiseAddPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("314+"));
        }

        [Test]
        public void Clears_WhenAddPressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = ")";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseAddPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("+"));
        }

        #endregion

        #region SubtractPressed

        [Test]
        public void UpdatesDisplay_WhenSubtractPressed()
        {
            this.mockView.RaiseSubtractPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("-"));
        }

        [Test]
        public void AppendsDisplay_WhenSubtractPressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "314";
            
            this.mockView.RaiseSubtractPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("314-"));
        }

        [Test]
        public void Clears_WhenSubtractPressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = ")";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseSubtractPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("-"));
        }

        #endregion

        #region OpenBracketPressed

        [Test]
        public void UpdatesDisplay_WhenOpenBracketPressed()
        {
            this.mockView.RaiseOpenBracketPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("("));
        }

        [Test]
        public void AppendsDisplay_WhenOpenBracketPressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "314";
            
            this.mockView.RaiseOpenBracketPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("314("));
        }

        [Test]
        public void Clears_WhenOpenBracketPressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = ")";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseOpenBracketPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("("));
        }

        #endregion

        #region CloseBracketPressed

        [Test]
        public void UpdatesDisplay_WhenCloseBracketPressed()
        {
            this.mockView.RaiseCloseBracketPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo(")"));
        }

        [Test]
        public void AppendsDisplay_WhenCloseBracketPressed_AndExistingEntryIsThere()
        {
            this.mockView.displayContents = "314";
            
            this.mockView.RaiseCloseBracketPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("314)"));
        }

        [Test]
        public void Clears_WhenCloseBracketPressed_AndPreviouslyInvalid()
        {
            this.mockView.displayContents = "+++";
            this.mockEquationEvaluator.BadEquation = true;
            this.mockView.RaiseEqualPressed();

            this.mockView.RaiseCloseBracketPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo(")"));
        }

        #endregion

        #region ClearPressed

        [Test]
        public void UpdatesDisplay_WhenClearPressed()
        {
            this.mockView.displayContents = "12345";

            this.mockView.RaiseClearPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo(""));
        }

        #endregion

        #region EqualsPressed

        [Test]
        public void UpdatesDisplay_WithEquationParsersAnswer()
        {
            this.mockView.RaiseEqualPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("99999"));
        }

        [Test]
        public void DisplaysInvalid_WhenEvaluatorThrows()
        {
            this.mockEquationEvaluator.BadEquation = true;

            this.mockView.RaiseEqualPressed();

            Assert.That(this.mockView.displayContents, Is.EqualTo("Invalid"));
        }

        #endregion
    }
}
