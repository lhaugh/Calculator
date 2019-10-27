using NUnit.Framework;

namespace Calculator.Tests
{
    internal class EquationEvaluatorTests
    {
        private EquationEvaluator equationParser;

        [SetUp]
        public void Initialize()
        {
            var equationParser = new EquationParser();
            this.equationParser = new EquationEvaluator(equationParser);
        }


        #region TryEvaluate(string)

        [Test]
        public void TryEvaluate_Throws_WhenArgumentNull()
        {
            float answer;
            Assert.That(() => this.equationParser.TryEvaluate(null, out answer), Throws.ArgumentNullException);
        }

        [TestCase("Hello")]
        [TestCase("+")]
        [TestCase("1 2 3")]
        public void TryEvaluate_ReturnsFalse_WhenEquationInvalid(string invalidEquation)
        {
            float answer;

            bool validEquation = this.equationParser.TryEvaluate(invalidEquation, out answer);

            Assert.That(validEquation, Is.False);
        }

        [TestCase("666", 666)]
        [TestCase("3.141", 3.141f)]
        [TestCase("1+3", 4)]
        [TestCase("1+3+8", 12)]
        [TestCase("1.5+3.4", 4.9f)]
        [TestCase("8*8", 64)]
        [TestCase("8*8+10", 74)]
        [TestCase("888*8", 7104)]
        [TestCase("888.89*8", 7111.12f)]
        [TestCase("24/8", 3)]
        [TestCase("24-8", 16)]
        [TestCase("7*(4+5)", 63)]
        [TestCase("(4+10+2)/8", 2)]
        [TestCase("7+(4+5)/9", 8)]
        [TestCase("7*(4+(2*2))", 56)]
        [TestCase("1 + 3 + 8", 12)]
        [TestCase("-3", -3)]
        [TestCase("3--5", 8)]
        [TestCase("-3+-5", -8)]
        [TestCase("-3+-55", -58)]
        [TestCase("-3+8", 5)]
        [TestCase("-3+(-2*-2)", 1)]
        [TestCase("-0*5", 0)]
        [TestCase("5--(3+3)", 11)]
        [TestCase("5*-(3+3)", -30)]
        [TestCase("-5*-(3+3)", 30)]
        [TestCase("-5*(3+3)", -30)]
        [TestCase("-(-5)-(-1)", 6)]
        [TestCase("6*(-3-(-1))", -12)]
        [TestCase("6*(3+(1))", 24)]
        [TestCase("-1/-2", 0.5f)]
        [TestCase("5+((2))", 7)]
        [TestCase("(1+1)*(2*2)", 8)]
        [TestCase("(10+10)/5", 4)]
        public void TryEvaluate_UpdatesValueToExpectedValue(string equation, float answer)
        {
            float value;
            
            this.equationParser.TryEvaluate(equation, out value);
            
            Assert.That(value, Is.EqualTo(answer));
        }
        
        #endregion
    }
}
