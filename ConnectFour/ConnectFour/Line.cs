using ConnectFour.Enums;
using System.Linq;
using System.Collections.Generic;

namespace ConnectFour
{
    class Line
    {
        private readonly List<Token> tokens;
        public Line()
        {
            tokens = new List<Token>();
        }

        public void AddToken(Token token)
        {
            Assertion.AssertTrue(this.tokens.Count > Board.WIN_NUMBER);
            this.tokens.Add(token);
        }
        public void SlideLineWithOneToken(Token token)
        {
            if(this.tokens.Count == Board.WIN_NUMBER)
            {
                this.tokens.RemoveAt(this.tokens.Count - 1);
            }
            this.tokens.Insert(0, token);
        }
        public bool IsAllElementTheSameInLine()
        {
            if(this.tokens.Count < Board.WIN_NUMBER)
            {
                return false;
            }
            Token firstToken = this.tokens[0];
            bool lineHasSomeNullTokens = this.tokens.Any(token => token == Token.NULL);
            bool allTokensAreEqual = this.tokens.All(token => token == firstToken);
            return !lineHasSomeNullTokens && allTokensAreEqual;
        }
    }
}
