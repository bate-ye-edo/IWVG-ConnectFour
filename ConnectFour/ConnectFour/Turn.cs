using ConnectFour.Enums;

namespace ConnectFour
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
            this.currentPlayer = GetOtherPlayer();
        }
        private int GetOtherPlayer()
        {
            return (this.currentPlayer + 1) % Player.MAXIMUM_PLAYERS_NUMBER;
        }

        public void WriteActivePlayer()
        {
            this.players[currentPlayer].WritePlayer();
        }
        public void WriteNonActivePlayer()
        {
            int nonActivePlayer = GetOtherPlayer();
            this.players[nonActivePlayer].WritePlayer();
        }
        public void Play()
        {
            Message.WritePlayerDescription(this.players[currentPlayer], currentPlayer+1);
            this.players[currentPlayer].Play();
        }
    }
}
