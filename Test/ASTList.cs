using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ASTList : ASTree
    {
        public ASTList(List<ASTree> tress)
        {
            _trees = tress;
        }

        public override ASTree Child(int i)
        {
            return _trees[i];
        }

        public override IEnumerator<ASTree> GetEnumerator()
        {
            return _trees.GetEnumerator();
        }

        public override string Location()
        {
            foreach (var item in _trees)
            {
                return item.Location();
            }

            return string.Empty;
        }

        public override int NumChild()
        {
            return _trees.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append('(');
            foreach (var item in _trees)
            {
                sb.Append(" " + item.ToString() + " ");
            }
            sb.Append(')');

            return sb.ToString();
        }

        protected List<ASTree> _trees;
    }
}
