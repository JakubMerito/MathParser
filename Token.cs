namespace MathParser
{
    internal class Token
    {
        private string _value;
        private TokenType _type;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public TokenType Type {
            get { return _type; }
            set { _type = value; }
        }

        public Token(string value, TokenType type)
        {
            _value = value;
            _type = type;
        }

        public override string ToString()
        {
            return $"Type: {_type}, Value: {_value}";
        }
    }
}
