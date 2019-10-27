using System;
using System.Collections.Generic;

namespace Calculator
{
    public sealed class EquationEvaluator : IEquationEvaluator
    {
        private readonly IEquationParser equationParser;


        public EquationEvaluator(
            IEquationParser equationParser)
        {
            this.equationParser = equationParser;
        }

        public bool TryEvaluate(string equation, out float answer)
        {
            if (equation == null) {
                throw new ArgumentNullException(nameof(equation));
            }

            List<EquationToken> tokenEquation;
            if (!this.equationParser.TryParse(equation, out tokenEquation)) {
                answer = 0;
                return false;
            }

            return this.EvaluateTokens(tokenEquation, out answer);
        }


        private bool EvaluateTokens(List<EquationToken> tokens, out float answer)
        {
            if (tokens.Count == 0) {
                answer = 0;
                return false;
            }

            if (tokens.Count == 1) {
                if (tokens[0].Type != EquationToken.TokenType.Value) {
                    answer = 0;
                    return false;
                }

                answer = tokens[0].Value;
                return true;
            }

            var highestOperator = EquationToken.TokenType.Value;
            int index = 0;

            for (int i = 0; i < tokens.Count; i++) {
                if (tokens[i].Type > highestOperator) {
                    highestOperator = tokens[i].Type;
                    index = i;
                }
            }

            if (index == 0 && tokens[0].Type != EquationToken.TokenType.OpenBracket) {
                answer = 0;
                return false;
            }

            if (highestOperator == EquationToken.TokenType.OpenBracket) {
                int bracketDepth = 0;

                for (int i = index + 1; i < tokens.Count; i++) {
                    if (tokens[i].Type == EquationToken.TokenType.OpenBracket) {
                        bracketDepth++;
                    }
                    else if (tokens[i].Type == EquationToken.TokenType.CloseBracket) {
                        bracketDepth--;
                    }

                    if (bracketDepth < 0) {
                        return this.ExtractBrackets(i, index, tokens, out answer);
                    }
                }
            }

            float leftHandSide;
            if (!this.EvaluateTokens(tokens.GetRange(0, index), out leftHandSide)) {
                answer = 0;
                return false;
            }
            float rightHandSide;
            if (!this.EvaluateTokens(tokens.GetRange(index + 1, tokens.Count - index - 1), out rightHandSide)) {
                answer = 0;
                return false;
            }

            switch (highestOperator)
            {
                case EquationToken.TokenType.Multiplication:
                answer = leftHandSide * rightHandSide;
                return true;

                case EquationToken.TokenType.Division:
                answer = leftHandSide / rightHandSide;
                return true;

                case EquationToken.TokenType.Addition:
                answer = leftHandSide + rightHandSide;
                return true;

                case EquationToken.TokenType.Subtraction:
                answer = leftHandSide - rightHandSide;
                return true;

                default:
                answer = 0;
                return false;
            }
        }

        private bool ExtractBrackets(int bracketPosition, int index, List<EquationToken> tokens, out float answer)
        {
            int bracketLength = bracketPosition - index;
            var bracketContents = tokens.GetRange(index + 1, bracketLength - 1);

            float bracketValue;
            if (!this.EvaluateTokens(bracketContents, out bracketValue)) {
                answer = 0;
                return false;
            }

            var leftHandSideTokens = tokens.GetRange(0, index);
            var rightHandSideTokens = tokens.GetRange(bracketPosition + 1, tokens.Count - bracketPosition - 1);

            tokens.RemoveRange(index, bracketLength + 1);
            tokens.Insert(index, new EquationToken() {
                Type = EquationToken.TokenType.Value,
                Value = bracketValue,
            });

            return this.EvaluateTokens(tokens, out answer);
        }
    }
}
