using System.Text;

namespace MathParser
{
    internal class Tokenizer
    {
        char currentChar;
        List<Token> tokens;
        int iterator = 0;
        string input;
        Token currentToken;

        public Tokenizer(string equasion)
        {
            this.input = equasion;
            tokens = new List<Token>(input.Length);
        }

        public void Tokenize()
        { 
            while (currentChar != '\0' || iterator == 0)
            {
                ResolveToken();
                AddToTokenList();
                GetNext();
            }
        }

        void GetNext()
        {
            if (iterator < this.input.Length - 1)
            {
                this.currentChar = this.input[iterator];
                iterator++;
            }
            else
            {
                currentChar = '\0';
            }
        }

        void ResolveToken()
        {
            switch (currentChar)
            {
                case '+':
                    currentToken = Token.ADDITION;
                    return;
                case '-':
                    currentToken = Token.SUBTRACTION;
                    return;
                case '\0':
                    currentToken = Token.EOF;
                    return;
            }

            if (Char.IsDigit(currentChar))
            {
                currentToken = Token.NUMBER;
                return;
            }
        }

        void AddToTokenList()
        {
            tokens.Add(currentToken);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Token token in tokens)
            {
                sb.Append(token.ToString());
            }

            return sb.ToString();
        }
    }
}
