using ConnectFour.Models;
namespace ConnectFour.Views
{
    class PlayerView : WithGameView
    {
        public PlayerView(Game game) : base(game) {}

        public override void Interact()
        {
            int columnNumber;
            bool canInsertIntoColumn;

            do
            {
                InsertTokenView insertTokenView = new(this.game);
                Message.WritePlayerWithToken(this.game.GetActivePlayer());
                columnNumber = insertTokenView.ReadColumnNumber();
                canInsertIntoColumn = insertTokenView.CanInsertIntoColumn(columnNumber);
            } while (!canInsertIntoColumn);

            this.game.PutToken(columnNumber);
        }
        
    }
}
