using ConnectFour.Constants;
using ConnectFour.Enums;
using System;

namespace ConnectFour
{
    class Player
    {
        private readonly Board board;
        public Token Token { get; init; }
        private int tokensLeftCount;
        public Player(Token token, Board board)
        {
            this.board = board;
            this.Token = token;
            this.tokensLeftCount = PlayerConstant.MAXIMUM_TOKEN_NUMBER;
        }
        private void PutToken(int columnNumber)
        {
            if(this.tokensLeftCount == 0)
            {
                Message.WritePlayerNoTokenLeft(this.Token);
                return;
            }
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
