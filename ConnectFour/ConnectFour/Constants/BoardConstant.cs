namespace ConnectFour.Constants
{
    internal static class BoardConstant
    {
        internal const int BOARD_COLUMNS = 7;
        internal const int BOARD_ROWS = 6;
        internal const int WIN_NUMBER = 4;
        internal const int MAX_COLUMN_TO_CHECK = BOARD_COLUMNS - WIN_NUMBER;
        internal const int MAX_ROW_TO_CHECK = BOARD_ROWS- WIN_NUMBER;
    }
}
