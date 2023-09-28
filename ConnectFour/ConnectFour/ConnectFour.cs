using ConnectFour.Models;
using ConnectFour.Views;
namespace ConnectFour
{
    class ConnectFour
    {
        private readonly Game game;
        private readonly View view;

        public ConnectFour()
        {
            this.game = new Game();
            this.view = new View(this.game);
        }

        public void Play()
        {
            this.view.Start();
            this.view.Play();
        }

        static void Main()
        {
            new ConnectFour().Play();
        }
    }
}
