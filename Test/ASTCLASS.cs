using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class NumberLiteral : ASTLeaf
    {
        public NumberLiteral(Token token) : base(token) { }

        public int Value
        {
            get
            {
                return ((NumberToken)_token).Number;
            }
        }
    }

    public class Name : ASTLeaf
    {
        public Name(Token token) : base(token)
        {
        }

        public string MyName { get { return _token.Text; } }

    }

    public class BinaryExpr : ASTList
    {
        public BinaryExpr(List<ASTree> tress) : base(tress)
        {
        }

        public ASTree Left
        {
            get
            {
                return _trees[0];
            }
        }

        public string Operator
        {
            get
            {
                return ((ASTLeaf)_trees[1]).Token.Text;
            }
        }

        public ASTree Right
        {
            get
            {
                return _trees[2];
            }
        }
    }
}
