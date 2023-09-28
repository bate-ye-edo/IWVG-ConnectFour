using ConnectFour.Enums;
using ConnectFour.Utils;

namespace ConnectFour.Models
{
    class Game
    {
        private readonly Board board;
        private readonly Turn turn;

        public Game()
        {
            this.board = new Board();
            this.turn = new Turn(board);
        }
        
        public Token[][] GetBoardTokens()
        {
            return this.board.Tokens;
        }
        
        public bool IsConnectedFour()
        {
            return this.board.IsConnectedFour();
        }

        public bool IsBoardComplete()
        {
            return this.board.IsBoardComplete();
        }

        public Player GetNonActivePlayer()
        {
            return this.turn.GetNonActivePlayer();
        }

        public Player GetActivePlayer()
        {
            return this.turn.GetActivePlayer();
        }

        public void Next()
        {
            this.turn.Change();
        }

        public void PutToken(int columnNumber) 
        {
            this.turn.PutToken(columnNumber);
        }

        public bool CanInsertIntoColumn(int columnNumber)
        {
            return this.board.CanInsertIntoColumn(columnNumber);
        }
    }
}
