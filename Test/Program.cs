using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"C:\Users\Cell\Desktop\job.txt";

            var path = @"C:\Users\Abraham\Desktop\job.txt";

            var lex = new Lexer(path);

            lex.Parse().ToList().ForEach(x =>
            {
                Console.WriteLine($"token 行号  {x.Line}  类型  {x.Type}     值  {x.Text}");
            });
        }
    }
}
