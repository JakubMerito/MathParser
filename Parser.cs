namespace MathParser
{
    internal class Parser
    {
        public Parser(string input)
        {
            Tokenizer tokenizer = new Tokenizer(input);

            tokenizer.Tokenize();
        }
    }
}
