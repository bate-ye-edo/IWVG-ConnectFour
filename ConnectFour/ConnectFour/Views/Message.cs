using System;
using ConnectFour.Constants;
using ConnectFour.Models;
namespace ConnectFour
{
    static class Message
    {
        private static void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
        public static void WriteGameStarted()
        {
            Message.WriteLine(MessageConstant.GAME_START);
        }
        public static void WriteWinnerTitle()
        {
            Message.WriteLine(MessageConstant.WINNER_TITLE);
        }
        public static void WriteGameTie()
        {
            Message.WriteLine(MessageConstant.GAME_TIE);
        }
        public static void WriteInsertColumnNumber()
        {
            Message.WriteLine(MessageConstant.INSERT_COLUMN_NUMBER);
        }
        public static void WriteInsertValidColumnNumber()
        {
            Message.WriteLine(MessageConstant.INSERT_VALID_COLUMN_NUMBER);
        }
        public static void WriteCanNotInsertIntoSelectedColumn(int columnNumber)
        {
            Message.WriteStringWithParams(MessageConstant.CAN_NOT_INSERT_INTO_COLUMN,columnNumber);
        }
        public static void WritePlayerWithToken(Player player)
        {
            Message.WriteStringWithParams(MessageConstant.PLAYER_INFO, (char)player.Token);
        }
        private static void WriteStringWithParams(string str, params object[] parameters)
        {
            string strFormatted = string.Format(str, parameters);
            Message.WriteLine(strFormatted);
        }

        public static void PrintSeparator()
        {
            Console.WriteLine(new String('-', Board.BOARD_COLUMNS * 3));
        }
    }
}
