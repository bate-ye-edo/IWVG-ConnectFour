using ConnectFour.Constants;
using ConnectFour.Enums;
using System;

namespace ConnectFour
{
    class Turn
    {
        private readonly Player[] players = new Player[PlayerConstant.MAXIMUM_PLAYERS_NUMBER];
        private readonly Board board;
        private int currentPlayer;
        public Turn(Board board)
        {
            this.board = board;
            for(int i = 0; i < PlayerConstant.MAXIMUM_PLAYERS_NUMBER; i++)
            {
                this.players[i] = new Player(TokenMethod.GetTokenFromNumber(i),this.board);
            }
            this.currentPlayer = 0;
        }

        public void ChangeTurn()
        {
            this.currentPlayer = GetOtherPlayer();
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
        private int GetOtherPlayer()
        {
            return (this.currentPlayer + 1) % PlayerConstant.MAXIMUM_PLAYERS_NUMBER;
        }
        public void Play()
        {
            Message.WritePlayerDescription(this.players[currentPlayer], currentPlayer+1);
            this.players[currentPlayer].Play();
        }
    }
}
