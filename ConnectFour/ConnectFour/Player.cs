using ConnectFour.Enums;

namespace ConnectFour
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
        private void PutToken(int columnNumber)
        {
            Assertion.AssertTrue(this.tokensLeftCount == 0);
            this.board.PutToken(this.Token, columnNumber);
            this.tokensLeftCount -= 1;
        }
        public void Play()
        {
            int columnNumber = Message.IntroduceColumnNumber();
            bool canInsertIntoColumn = this.board.CanInsertIntoColumn(columnNumber);
            while (!canInsertIntoColumn)
            {
                Message.WriteColumnCanNotBeUsed(columnNumber);
                columnNumber = Message.IntroduceColumnNumber();
                canInsertIntoColumn = this.board.CanInsertIntoColumn(columnNumber);
            }
            this.PutToken(columnNumber);
        }
        
        public void WritePlayer()
        {
            Message.WritePlayer(this);
        }
    }
}
