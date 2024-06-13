namespace MathParser
{
    internal class Parser
    {
        private string _input;
        public Parser(string input)
        {
            _input = input;

            List<Token> tokens = GetTokens();
        }

        private List<Token> GetTokens()
        {
            Tokenizer tokenizer = new Tokenizer(_input);
            tokenizer.Tokenize();

            return tokenizer.GetTokens();
        }
    }
}
