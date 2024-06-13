using System.Text;

namespace MathParser
{
    internal class Tokenizer
    {
        string _input;
        string? _currentTokenValue;
        List<Token> _tokens;
        int _iterator = 0;
        
        TokenType _currentTokenType;

        public Tokenizer(string equasion)
        {
            this._input = equasion;
            _tokens = new List<Token>(_input.Length);
        }

        public void Tokenize()
        { 
            while (_currentTokenValue != null || _iterator == 0)
            {
                GetNext();

                if (_currentTokenValue == " ")
                {
                    continue;
                }

                Token token = ResolveToken();

                if (token.Type == TokenType.NUMBER && _tokens.Count > 0 && _tokens.Last().Type == TokenType.NUMBER)
                {
                    _tokens.Last().Value += token.Value;
                }
                else
                {
                    AddToTokenList(token);
                }
            }
        }

        private void GetNext()
        {
            if (_iterator < _input.Length)
            {
                _currentTokenValue = _input[_iterator].ToString();
                _iterator++;
            }
            else
            {
                _currentTokenValue = null;
            }
        }

        private Token ResolveToken()
        {
            switch (_currentTokenValue)
            {
                case "+":
                    _currentTokenType = TokenType.ADDITION;
                    break;
                case "-":
                    _currentTokenType = TokenType.SUBTRACTION;
                    break;
                case null:
                    _currentTokenType = TokenType.EOF;
                    break;
            }

            if (double.TryParse(_currentTokenValue, out double result) || _currentTokenValue == ".")
            {
                _currentTokenType = TokenType.NUMBER;
            }

            Token token = new Token(_currentTokenValue, _currentTokenType);

            return token;
        }

        private void AddToTokenList(Token token)
        {
            _tokens.Add(token);
        }
    }
}
