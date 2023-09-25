using ConnectFour.Enums;
using ConnectFour.Models;
using System;
namespace ConnectFour.Views
{
    class BoardView
    {
        public void Write(Game game)
        {
            Token[][] tokens = game.GetBoardTokens();
            Message.PrintSeparator();
            for (int row = 0; row < tokens.Length; row++)
            {
                for (int column = 0; column < tokens[row].Length; column++)
                {
                    Console.Write($"[{(char)tokens[row][column]}]");
                }
                Console.Write("\n");
            }
            Message.PrintSeparator();
        }
    }
}
