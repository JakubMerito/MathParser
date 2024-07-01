namespace MathParser
{
    internal class Parser
    {
        private string _input;
        private List<Token> _tokens;
        private int _iterator = 0;
        private Token _currentToken;
        private List<TokenType> _multiplicationDivisionTypes = new List<TokenType>() { TokenType.MULTIPLICATION, TokenType.DIVISION };
        private List<TokenType> _additionSubtractionTypes = new List<TokenType>() { TokenType.ADDITION, TokenType.SUBTRACTION };
        
        public Parser(string input)
        {
            _input = input;

            _tokens = GetTokens();

            NextToken();

            foreach(Token token in _tokens)
            {
                Console.WriteLine(token.ToString());
            }
            
            AST ast = ParseAdditionSubtraction();

            try
            {
                Console.WriteLine(ast.Eval());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private List<Token> GetTokens()
        {
            Tokenizer tokenizer = new Tokenizer(_input);
            tokenizer.Tokenize();

            return tokenizer.GetTokens();
        }

        private void NextToken()
        {
            if (_iterator < _tokens.Count)
            {
                _currentToken = _tokens[_iterator];
                _iterator++;
            }
        }

        private AST ParseBracketsNumber()
        {
            AST expression = null;

            if (_currentToken.Type == TokenType.LBRACKET)
            {
                NextToken();

                expression = ParseAdditionSubtraction();

            } 
            else if (_currentToken.Type == TokenType.NUMBER)
            {
                expression = new ASTLeaf(_currentToken);
            }

            NextToken();
            return expression;
        }

        private AST ParseMultiplicationDivision()
        {
            AST result = ParseBracketsNumber();
            while (_currentToken.Type != TokenType.EOF && result != null && _multiplicationDivisionTypes.Contains(_currentToken.Type))
            {
                if (_currentToken.Type == TokenType.MULTIPLICATION)
                {
                    NextToken();
                    AST rightNode = ParseBracketsNumber();
                    result = new ASTMultiplication(result, rightNode);
                }
                else if (_currentToken.Type == TokenType.DIVISION)
                {
                    NextToken();
                    AST rightNode = ParseBracketsNumber();
                        result = new ASTDivision(result, rightNode);
                }
            }
            return result;
        }

        private AST ParseAdditionSubtraction()
        {
            AST result = ParseMultiplicationDivision();
            while (_currentToken.Type != TokenType.EOF && result != null && _additionSubtractionTypes.Contains(_currentToken.Type))
            {
                if (_currentToken.Type == TokenType.ADDITION)
                {
                    NextToken();
                    AST rightNode = ParseMultiplicationDivision();
                    result = new ASTAddition(result, rightNode);
                }
                else if (_currentToken.Type == TokenType.SUBTRACTION)
                {
                    NextToken();
                    AST rightNode = ParseMultiplicationDivision();
                    result = new ASTSubtraction(result, rightNode);
                }
            }
            return result;
        }
    }
}
