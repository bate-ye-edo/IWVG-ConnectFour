using System;
using ConnectFour.Constants;
using ConnectFour.Enums;

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
        public static void WritePlayerDescription(Player player, int order)
        {
            Message.WriteStringWithParams(MessageConstant.PLAYER_DESCRIPTION, order, (char)player.Token);
        }
        public static void WritePlayerNoTokenLeft(Token token)
        {
            Message.WriteStringWithParams(MessageConstant.PLAYER_NO_MORE_TOKENS, (char)token);
        }
        public static void WriteColumnCanNotBeUsed(int column)
        {
            Message.WriteStringWithParams(MessageConstant.COLUMN_X_CAN_NOT_BE_USED, column);
        }
        public static void WriteInsertColumnNumber()
        {
            Message.WriteLine(MessageConstant.INSERT_COLUMN_NUMBER);
        }
        public static void WriteInsertValidColumnNumber()
        {
            Message.WriteLine(MessageConstant.INSERT_VALID_COLUMN_NUMBER);
        }
        public static void WritePlayer(Player player)
        {
            Message.WriteStringWithParams(MessageConstant.PLAYER_INFO, (char)player.Token);
        }
        private static void WriteStringWithParams(string str, params object[] parameters)
        {
            string strFormatted = string.Format(str, parameters);
            Message.WriteLine(strFormatted);
        }
        internal static int IntroduceColumnNumber()
        {
            Message.WriteInsertColumnNumber();
            string columnString = Console.ReadLine();
            bool isNumber = int.TryParse(columnString, out int columnNumber);
            while (!isNumber)
            {
                Message.WriteInsertValidColumnNumber();
                columnString = Console.ReadLine();
                isNumber = int.TryParse(columnString, out columnNumber);
            }
            return columnNumber;
        }
        public static void PrintSeparator()
        {
            Console.WriteLine(new String('-', BoardConstant.BOARD_COLUMNS * 3));
        }
    }
}
