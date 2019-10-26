using System;
using System.Collections.Generic;

namespace Calculator
{
    public sealed class EquationParser : IEquationParser
    {
        public float Parse(string equation)
        {
            if (equation == null) {
                throw new ArgumentNullException(nameof(equation));
            }

            return this.Read(equation);
        }


        private float Evaluate(List<EquationToken> tokens)
        {
            UnityEngine.Debug.Log("Evaluate tokens from: " + tokens.Count);

            if (tokens.Count == 1) {
                if (tokens[0].Type != EquationToken.TokenType.Value) {
                    throw new ArgumentException("Invalid equation.");
                }

                return tokens[0].Value;
            }

            var highestOperator = EquationToken.TokenType.Value;
            int index = 0;

            for (int i = 0; i < tokens.Count; i++) {
            UnityEngine.Debug.Log("tokens " + i + tokens[i].Type);

                if (tokens[i].Type > highestOperator) {
                    highestOperator = tokens[i].Type;
                    index = i;
                }
            }

            if (index == 0 && tokens[0].Type != EquationToken.TokenType.OpenBracket) {
                throw new ArgumentException("Invalid equation. Missing opperator.");
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
                        int bracketLength = i - index;
                        var bracketContents = tokens.GetRange(index + 1, bracketLength - 1);

                        float bracketValue = this.Evaluate(bracketContents);

                        var leftHandSideTokens = tokens.GetRange(0, index);
                        var rightHandSideTokens = tokens.GetRange(i + 1, tokens.Count - i - 1);

                        tokens.RemoveRange(index, bracketLength + 1);
                        tokens.Insert(index, new EquationToken() {
                            Type = EquationToken.TokenType.Value,
                            Value = bracketValue,
                        });

                        return this.Evaluate(tokens);
                    }
                }
            }

            float leftHandSide = this.Evaluate(tokens.GetRange(0, index));
            float rightHandSide = this.Evaluate(tokens.GetRange(index + 1, tokens.Count - index - 1));

            switch (highestOperator)
            {
                case EquationToken.TokenType.Multiplication:
                return leftHandSide * rightHandSide;

                case EquationToken.TokenType.Division:
                return leftHandSide / rightHandSide;

                case EquationToken.TokenType.Addition:
                return leftHandSide + rightHandSide;

                case EquationToken.TokenType.Subtraction:
                return leftHandSide - rightHandSide;

                default:
                throw new ArgumentException("Invalid equation.");
            }
        }
        
        private float Read(string equation)
        {
            var tokenStrings = new List<string>();
            var tokens = new List<EquationToken>();
            int lastToken = 0;

            for (int i = 0; i < equation.Length; i++) {

                if (equation[i] == '(') {
                    tokens.Add(new EquationToken() {
                        Type = EquationToken.TokenType.OpenBracket
                    });
                    lastToken = i + 1;
                    continue;
                }

                if (equation[i] == ')') {
                    this.CreateTokens(ref equation, lastToken, i, EquationToken.TokenType.CloseBracket, ref tokens);
                    lastToken = i + 1;          
                    continue;
                }

                if (equation[i] == '*') {
                    this.CreateTokens(ref equation, lastToken, i, EquationToken.TokenType.Multiplication, ref tokens);
                    lastToken = i + 1;
                    continue;
                }

                if (equation[i] == '/') {
                    this.CreateTokens(ref equation, lastToken, i, EquationToken.TokenType.Division, ref tokens);
                    lastToken = i + 1;                    
                    continue;
                }

                if (equation[i] == '+') {
                    this.CreateTokens(ref equation, lastToken, i, EquationToken.TokenType.Addition, ref tokens);
                    lastToken = i + 1;          
                    continue;
                }

                if (equation[i] == '-') {
                    this.CreateTokens(ref equation, lastToken, i, EquationToken.TokenType.Subtraction, ref tokens);
                    lastToken = i + 1;          
                    continue;
                }
            }

            UnityEngine.Debug.Log("Last tokens from: " + lastToken + " " + equation.Length);

            if (lastToken != equation.Length) {
                tokens.Add(this.ParseToken(equation.Substring(lastToken, equation.Length - lastToken)));
            }
                    

            return this.Evaluate(tokens);
        }

        private void CreateTokens(
            ref string equation,
            int lastToken,
            int index,
            EquationToken.TokenType currentToken,
            ref List<EquationToken> tokens)
        {
            UnityEngine.Debug.Log("Create tokens from: " + equation.Substring(lastToken, index - lastToken));

            if (index - lastToken != 0) {
                tokens.Add(this.ParseToken(equation.Substring(lastToken, index - lastToken)));
            }
            tokens.Add(new EquationToken() {
                Type = currentToken,
            });
        }

        private EquationToken ParseToken(string token)
        {
            float baseValue;
            if (float.TryParse(token, out baseValue)) {
                return new EquationToken(){
                    Type = EquationToken.TokenType.Value,
                    Value = baseValue
                };
            }

            throw new ArgumentException("Invalid equation. Unexpected token: " + token);
        }


        private sealed class EquationToken
        {
            public enum TokenType
            {
                Value = 0,
                CloseBracket,
                Multiplication,
                Division,
                Addition,
                Subtraction,
                OpenBracket,
            }

            public TokenType Type;
            public float Value;
        }
    }
}
