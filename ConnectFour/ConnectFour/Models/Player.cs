using ConnectFour.Enums;
using ConnectFour.Utils;
namespace ConnectFour.Models
{
    class Player
    {
        internal const int MAXIMUM_TOKEN_NUMBER = 21;
        internal const int MAXIMUM_PLAYERS_NUMBER = 2;

        private readonly Board board;
        public Token Token { get; init; }
        private int tokensLeftCount;

        public Player(Token token, Board board)
        {
            this.board = board;
            this.Token = token;
            this.tokensLeftCount = MAXIMUM_TOKEN_NUMBER;
        }

        public void PutToken(int columnNumber)
        {
            Assertion.AssertTrue(this.tokensLeftCount > 0);
            this.board.PutToken(this.Token, columnNumber);
            this.tokensLeftCount -= 1;
        }
        
    }
}
