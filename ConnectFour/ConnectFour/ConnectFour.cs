
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
                this.Play();
            } while (!this.GameHasFinished());
        }

        private void Play()
        {
            Message.PrintBoard(this.board);
            this.turn.Play();
            this.turn.ChangeTurn();
        }

        public bool GameHasFinished()
        {
            bool gameHasFinished = false;
            if (this.board.IsConnectedFour())
            {
                Message.PrintBoard(this.board);
                Message.WriteWinnerTitle();
                this.turn.WriteNonActivePlayer();
                gameHasFinished = true;
            }else if (this.board.IsBoardComplete())
            {
                Message.PrintBoard(this.board);
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
