using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class ASTree : IEnumerable<ASTree>
    {
        public abstract ASTree Child(int i);

        public abstract int NumChild();        

        public abstract string Location(); 

        public abstract IEnumerator<ASTree> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
