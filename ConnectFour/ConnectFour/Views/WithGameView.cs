using ConnectFour.Models;

namespace ConnectFour.Views
{
    abstract class WithGameView
    {
        protected readonly Game game;

        public WithGameView(Game game)
        {
            this.game = game;
        }

        public abstract void Interact();
    }
}
