namespace MathParser
{
    internal class Parser
    {
        private string _input;
        public Parser(string input)
        {
            _input = input;

            List<Token> tokens = GetTokens();

           
            BuildTree(tokens);
        }

        private List<Token> GetTokens()
        {
            Tokenizer tokenizer = new Tokenizer(_input);
            tokenizer.Tokenize();

            return tokenizer.GetTokens();
        }

        private void BuildTree(List<Token> tokens)
        {
            foreach (Token token in tokens)
            {
                if (token.Type == TokenType.EOF)
                {
                    break;
                }



                Console.WriteLine(token.ToString());
            }
        }
    }
}
