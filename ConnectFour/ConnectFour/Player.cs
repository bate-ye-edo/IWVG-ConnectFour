using ConnectFour.Constants;
using ConnectFour.Enums;
using System;

namespace ConnectFour
{
    class Player
    {
        private readonly Board board;
        public Token token { get; init; }
        private int tokensLeftCount;
        public Player(Token token, Board board)
        {
            this.board = board;
            this.token = token;
            this.tokensLeftCount = PlayerConstant.MAXIMUM_TOKEN_NUMBER;
        }
        private void PutToken(int columnNumber)
        {
            if(this.tokensLeftCount == 0)
            {
                Console.WriteLine("No more tokens left for player");
                return;
            }
            this.board.PutToken(this.token, columnNumber);
            this.tokensLeftCount -= 1;
        }
        public void Play()
        {
            int columnNumber = this.IntroduceColumnNumber();
            bool canInsertIntoColumn = this.board.CanInsertIntoColumn(columnNumber);
            while (!canInsertIntoColumn)
            {
                Console.WriteLine($"The column {columnNumber} can not be used, please insert another column");
                columnNumber = this.IntroduceColumnNumber();
                canInsertIntoColumn = this.board.CanInsertIntoColumn(columnNumber);
            }
            this.PutToken(columnNumber);
        }
        private int IntroduceColumnNumber()
        {
            Console.WriteLine("Please, insert a column number to insert a token: ");
            string columnString = Console.ReadLine();
            bool isNumber = int.TryParse(columnString, out int columnNumber);
            while (!isNumber)
            {
                Console.WriteLine("Please, insert a valid column number to insert a token: ");
                columnString = Console.ReadLine();
                isNumber = int.TryParse(columnString, out columnNumber);
            }
            return columnNumber;
        }
        public void WritePlayer()
        {
            Console.WriteLine($"Player with token {token}");
        }
    }
}
