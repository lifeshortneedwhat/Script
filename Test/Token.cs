using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class Token
    {
        public Token(TokenType type, string text, int line)
        {
            Text = text;
            Type = type;
            Line = line;
        }

        public static Token Eof { get; } = new EofToken();

        public string Text { get; protected set; }

        public int Line { get; }
        public TokenType Type { get; }
    }

    public class EofToken : Token
    {
        public EofToken() : base(TokenType.Eof, "\n", -1) { }
    }

    public class NoneToken : Token
    {
        public NoneToken(int line) : base(TokenType.None, "", line) { }
    }

    public class NumberToken : Token
    {
        public NumberToken(string text, int line) : base(TokenType.Number, text, line)
        {
            Number = int.Parse(text);
        }

        public int Number { get; }
    }

    public class DefineToken : Token
    {
        public DefineToken(string text, int line) : base(TokenType.Define, text, line)
        { }
    }

    public class StrToken : Token
    {
        public StrToken(string text, int line) : base(TokenType.String, text, line) { }
    }

    public enum TokenType
    {
        Number,
        String,
        Define,
        None,
        Eof
    }
}
