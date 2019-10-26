using NUnit.Framework;
using Calculator.Tests;

namespace Calculator.View.Tests
{
    public class CalculatorPresenterTests
    {
        private CalculatorPresenter presenter;

        private MockCalculatorView mockView;

        [SetUp]
        public void Initialize()
        {
            this.mockView = new MockCalculatorView();
            var mockEquationParser = new MockEquationParser();

            this.presenter = new CalculatorPresenter(
                this.mockView,
                mockEquationParser
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
        public void AppendsDisplay_WhenExistingEntryIsThere()
        {
            this.mockView.displayContents = "3.14";
            
            this.mockView.RaiseNumberPressed(1);

            Assert.That(this.mockView.displayContents, Is.EqualTo("3.141"));
        }

        #endregion

        #region DecimalPressed

        [Test]
        public void UpdatesDisplay_WhenDecimalPressed()
        {
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

        #endregion

        #region DividePressed

        [Test]
        public void UpdatesDisplay_WhenDividePressed()
        {
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

        #endregion

        #region SubtractPressed

        [Test]
        public void UpdatesDisplay_WhenSubtractPressed()
        {
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

        #endregion

        #region CloseBracketPressed

        [Test]
        public void UpdatesDisplay_WhenCloseBracketPressed()
        {
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

        #endregion
    }
}
