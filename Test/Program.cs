﻿using System;
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
            var reader = File.OpenText(@"C:\Users\Cell\Desktop\job.txt");

            var lex = new Lexer();

            while (true)
            {
                var tokens = lex.Read(reader.ReadLine());

                tokens.ForEach(x =>
                {
                    Console.WriteLine($"token 行号  {x.Line}  类型  {x.Type}     值  {x.Text}");
                });

                if (reader.EndOfStream)
                    break;
            }
        }
    }
}
