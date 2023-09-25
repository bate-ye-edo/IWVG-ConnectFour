using ConnectFour.Enums;

namespace ConnectFour.Models
{
    class Turn
    {
        private readonly Board board;
        private readonly Player[] players;
        private int currentPlayer;
        public Turn(Board board)
        {
            this.board = board;
            this.players = new Player[Player.MAXIMUM_PLAYERS_NUMBER];
            for(int i = 0; i < Player.MAXIMUM_PLAYERS_NUMBER; i++)
            {
                this.players[i] = new Player(TokenExtension.GetTokenFromNumber(i),this.board);
            }
            this.currentPlayer = 0;
        }

        public void ChangeTurn()
        {
            this.currentPlayer = GetOtherPlayerIndex();
        }
        private int GetOtherPlayerIndex()
        {
            return (this.currentPlayer + 1) % Player.MAXIMUM_PLAYERS_NUMBER;
        }
        public Player GetNonActivePlayer()
        {
            return this.players[this.GetOtherPlayerIndex()];
        }
        public Player GetActivePlayer()
        {
            return this.players[this.currentPlayer];
        }

        public void PutToken(int columnNumber)
        {
            this.players[currentPlayer].PutToken(columnNumber);
        }
    }
}
