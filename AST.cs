namespace MathParser
{
    internal abstract class AST
    {
        public abstract double Eval();
    }

    internal class ASTLeaf : AST
    {
        public Token _token;
        public ASTLeaf(Token token)
        {
            _token = token;
        }

        public override double Eval()
        {
            return double.Parse(_token.Value);
        }
    }

    internal abstract class ASTOperation : AST
    {
        public AST _leftNode;
        public AST _rightNode;
    }

    internal class ASTAddition : ASTOperation
    {
        public ASTAddition(AST leftNode, AST rightNode)
        {
            _leftNode = leftNode;
            _rightNode = rightNode;
        }

        public override double Eval()
        {
            return _leftNode.Eval() + _rightNode.Eval();
        }
    }

    internal class ASTSubtraction : ASTOperation
    {
        public ASTSubtraction(AST leftNode, AST rightNode)
        {
            _leftNode = leftNode;
            _rightNode = rightNode;
        }

        public override double Eval()
        {
            return _leftNode.Eval() - _rightNode.Eval();
        }
    }
}
