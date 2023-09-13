﻿using ConnectFour.Constants;
using System;

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
            Console.WriteLine("ConnectFour Game Started");
            do
            {
                this.PlayGame();
            } while (!this.GameHasFinished());
        }

        private void PlayGame()
        {
            this.PrintGameTable();
            this.turn.Play();
            this.turn.ChangeTurn();
        }
        private void PrintGameTable()
        {
            Console.WriteLine(new String('-',BoardConstant.BOARD_ROWS*3));
            this.board.PrintBoard();
            Console.WriteLine(new String('-',BoardConstant.BOARD_ROWS*3));
        }

        public bool GameHasFinished()
        {
            bool gameHasFinished = false;
            if (this.board.IsConnectedFour())
            {
                this.board.PrintBoard();
                Console.WriteLine("The winner is: ");
                this.turn.WriteNonActivePlayer();
                gameHasFinished = true;
            }else if (this.board.IsBoardComplete())
            {
                this.board.PrintBoard();
                Console.WriteLine("The game has ended with a tie");
                gameHasFinished = true;
            }
            return gameHasFinished;
        }
    }
}
