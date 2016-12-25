using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ASTLeaf : ASTree
    {
        public ASTLeaf(Token token)
        {
            _token = token;
        }

        public override ASTree Child(int i)
        {
            throw new Exception("没有节点");
        }

        public override IEnumerator<ASTree> GetEnumerator()
        {
            return _trees.GetEnumerator();
        }

        public override string Location()
        {
            return $"在第{_token.Line}行";
        }

        public override int NumChild()
        {
            return 0;
        }

        public override string ToString()
        {
            return _token.Text;
        }

        private List<ASTree> _trees = new List<ASTree>();

        protected Token _token;
        public Token Token
        {
            get { return _token; }
        }
    }
}
