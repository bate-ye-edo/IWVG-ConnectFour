using ConnectFour.Models;

namespace ConnectFour.Views
{
    class StartView: WithGameView
    {
        public StartView(Game game) : base(game) { }
        public override void Interact()
        {
            Message.WriteGameStarted();
            new BoardView().Write(this.game);
        }
    }
}
