using ConnectFour.Models;

namespace ConnectFour.Views
{
    class PlayView: WithGameView
    {
        public PlayView(Game game): base(game) { }

        public override void Interact()
        {
            do
            {
                new PlayerView(this.game).Interact();
                this.game.Next();
                new BoardView().Write(this.game);
            } while (!this.game.IsConnectedFour());
            this.PrintWinnerOrTie();
        }
        public void PrintWinnerOrTie()
        {
            new BoardView().Write(this.game);
            if (this.game.IsConnectedFour())
            {
                Message.WriteWinnerTitle();
                Message.WritePlayerWithToken(this.game.GetNonActivePlayer());
            }
            else if (this.game.IsBoardComplete())
            {
                Message.WriteGameTie();
            }
        }
    }
}
