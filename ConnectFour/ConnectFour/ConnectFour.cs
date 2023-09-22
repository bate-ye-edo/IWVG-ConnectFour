using ConnectFour.Constants;
using System;

namespace ConnectFour
{
    class ConnectFour
    {
        private readonly Board board;
        private readonly Turn turn;
        public ConnectFour()
        {
            this.board = new Board();
            this.turn = new Turn(board);
        }
        public void GameStart()
        {
            Message.WriteGameStarted();
            do
            {
                this.PlayGame();
            } while (!this.GameHasFinished());
        }

        private void PlayGame()
        {
            this.PrintGameTable();
            this.turn.Play();
            this.turn.ChangeTurn();
        }
        private void PrintGameTable()
        {
            Message.PrintSeparator();
            this.board.PrintBoard();
            Message.PrintSeparator();
        }

        public bool GameHasFinished()
        {
            bool gameHasFinished = false;
            if (this.board.IsConnectedFour())
            {
                this.board.PrintBoard();
                Message.WriteWinnerTitle();
                this.turn.WriteNonActivePlayer();
                gameHasFinished = true;
            }else if (this.board.IsBoardComplete())
            {
                this.board.PrintBoard();
                Message.WriteGameTie();
                gameHasFinished = true;
            }
            return gameHasFinished;
        }

        static void Main()
        {
            ConnectFour game = new();
            game.GameStart();
        }
    }
}
