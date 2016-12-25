using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Test
{
    public class Lexer
    {
        public List<Token> Read(string input)
        {
            _input = input;
            _index = 0;
            _line++;

            List<Token> tokens = new List<Token>();

            while (true)
            {
                if (IsLineEnd())
                    break;

                var c = GetC();

                if (c == '"')
                {
                    Skip();
                    tokens.Add(new StrToken(Scan(x =>
                   {
                       if (x == '"')
                           return false;
                       return true;
                   }), _line));

                }
                else if (IsLetter(c) || IsSymbol(c))
                {
                    tokens.Add(new DefineToken(Scan(x =>
                   {
                       if (IsSpace(x))
                           return false;
                       return true;
                   }), _line));
                }
                else if (IsDigit(c))
                {
                    tokens.Add(new NumberToken(Scan(x =>
                   {
                       if (IsSpace(x))
                           return false;
                       return true;
                   }), _line));
                }
                else if (IsSpace(c))
                {
                    Skip();
                    continue;
                }
                else
                {
                    throw new Exception($"未能识别该符号，{c}，行号为，{_line}");
                }
            }

            return tokens;

        }

        private string Scan(Func<char, bool> func)
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                if (IsLineEnd())
                    break;

                var c = GetC();
                Skip();

                if (func(c))
                    sb.Append(c);
                else
                    break;
            }

            return sb.ToString();
        }

        public bool IsSymbol(char c)
        {
            return c == '=';
        }

        public bool IsLetter(char c)
        {
            return 'A' <= c && c <= 'Z' || 'a' <= c && c <= 'z';
        }

        public bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        public bool IsSpace(char c)
        {
            return 0 <= c && c <= ' ';
        }

        public bool IsLineEnd()
        {
            return _index > _input.Length - 1;
        }

        public char GetC(int i = 0)
        {
            return _input[_index + i];
        }

        public void Skip()
        {
            _index++;
        }


        public Lexer()
        {
            _input = string.Empty;
            _index = 0;
            _line = 0;
        }

        private int _line;

        private int _index;

        private string _input;

    }
}
