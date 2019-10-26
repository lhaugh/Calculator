using NUnit.Framework;

namespace Calculator.Tests
{
    internal class EquationParserTests
    {
        private EquationParser equationParser;

        [SetUp]
        public void Initialize()
        {
            this.equationParser = new EquationParser();
        }


        #region Parse(string)

        [Test]
        public void Parse_Throws_WhenArgumentNull()
        {
            Assert.That(() => this.equationParser.Parse(null), Throws.ArgumentNullException);
        }

        [TestCase("Hello")]
        [TestCase("1 2 3")]
        [TestCase("7 * ( 4 + 5")]
        public void Parse_Throws_WhenEquationInvalid(string invalidEquation)
        {
            Assert.That(() => this.equationParser.Parse(invalidEquation), Throws.ArgumentException);
        }

        [TestCase("666", 666)]
        [TestCase("3.141", 3.141f)]
        [TestCase("1 + 3", 4)]
        [TestCase("1 + 3 + 8", 12)]
        [TestCase("1.5 + 3.4", 4.9f)]
        [TestCase("8 * 8", 64)]
        [TestCase("8 * 8 + 10", 74)]
        [TestCase("24 / 8", 3)]
        [TestCase("24 - 8", 16)]
        [TestCase("7 * ( 4 + 5 )", 63)]
        [TestCase("7 + ( 4 + 5 ) / 9", 8)]
        [TestCase("7 * ( 4 + ( 2 * 2 ) )", 56)]
        public void Parse_Returns_ExpectedValue(string equation, float answer)
        {
            var value = this.equationParser.Parse(equation);
            
            Assert.That(value, Is.EqualTo(answer));
        }
        
        #endregion
    }
}
