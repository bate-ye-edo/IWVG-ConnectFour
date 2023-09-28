using ConnectFour.Models;
namespace ConnectFour.Views
{
    class View
    {
        private readonly StartView startView;
        private readonly PlayView playView;

        public View(Game game)
        {
            this.startView = new StartView(game);
            this.playView = new PlayView(game);
        }

        public void Start()
        {
            this.startView.Interact();
        }

        public void Play()
        {
            this.playView.Interact();
        }
    }
}
