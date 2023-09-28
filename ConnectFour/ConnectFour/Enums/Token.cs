using System;
using System.Collections.Generic;
using System.Linq;
namespace ConnectFour.Enums
{
    enum Token
    {
        RED = 'R',
        YELLOW = 'Y',
        NULL = ' '
    }

    internal static class TokenExtension
    {
        internal static Token GetTokenFromNumber(int number){
            List<Token> tokens = Enum.GetValues<Token>().ToList();
            tokens.Remove(Token.NULL);
            int tokenIndex = number % tokens.Count;

            return tokens[tokenIndex];
        }
    }
}
