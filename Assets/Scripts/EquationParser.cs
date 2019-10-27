using System.Collections.Generic;

namespace Calculator
{
    public sealed class EquationParser : IEquationParser
    {
        public bool TryParse(string equation, out List<EquationToken> tokens)
        {
            var tokenStrings = new List<string>();
            tokens = new List<EquationToken>();
            int lastToken = 0;
            bool carryNegative = false;

            for (int i = 0; i < equation.Length; i++) {

                if (equation[i] == '(') {

                    // tokens.Add(new EquationToken() {
                    //     Type = EquationToken.TokenType.OpenBracket
                    // });
                    // lastToken = i + 1;

                    this.CreateTokens(ref equation, lastToken, i, EquationToken.TokenType.OpenBracket, ref tokens, addNegative: carryNegative);
                    lastToken = i + 1;     
                    carryNegative = false;
                    continue;
                }

                carryNegative = false;

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
                    //Subtract can act both as an operator or to designate negative numbers
                    if (i == 0 ||
                        (tokens.Count > 0 &&
                        tokens[tokens.Count - 1].Type != EquationToken.TokenType.CloseBracket &&
                        tokens[tokens.Count - 1].Type != EquationToken.TokenType.Value)) {
                            carryNegative = true;
                    }
                    else {
                        this.CreateTokens(ref equation, lastToken, i, EquationToken.TokenType.Subtraction, ref tokens);
                        lastToken = i + 1;
                    }

                    continue;
                }
            }

            if (lastToken != equation.Length) {
                EquationToken token;
                if (!this.ParseToken(equation.Substring(lastToken, equation.Length - lastToken), out token)) {
                    return false;
                }

                tokens.Add(token);
            }

            return true;
        }
        
        private bool CreateTokens(
            ref string equation,
            int lastToken,
            int index,
            EquationToken.TokenType currentToken,
            ref List<EquationToken> tokens,
            bool addNegative = false)
        {
            int previousTokenLength = index - lastToken;
            if (addNegative) {
                previousTokenLength -= 1;
            }
            
            bool didParse = false;
            if (previousTokenLength != 0) {
                EquationToken token;
                if (this.ParseToken(equation.Substring(lastToken, previousTokenLength), out token)) {
                    tokens.Add(token);
                    didParse = true;
                }
                else if (!addNegative) {
                    return false;
                }
            }

            // This is to handle a situtaion like "5*-(2*2)"
            if (addNegative) {
                if (didParse) {
                    tokens.Add (new EquationToken() {
                        Type = EquationToken.TokenType.Addition,
                    });
                }
                tokens.Add (new EquationToken() {
                    Type = EquationToken.TokenType.Value,
                    Value = -1,
                });
                tokens.Add (new EquationToken() {
                    Type = EquationToken.TokenType.Multiplication,
                });
            }

            tokens.Add(new EquationToken() {
                Type = currentToken,
            });

            return true;
        }

        private bool ParseToken(string tokenString, out EquationToken token)
        {
            float baseValue;
            if (float.TryParse(tokenString, out baseValue)) {
                token = new EquationToken(){
                    Type = EquationToken.TokenType.Value,
                    Value = baseValue
                };
                return true;
            }

            token = null;
            return false;
        }
    }
}
