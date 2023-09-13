using ConnectFour.Constants;
using ConnectFour.Enums;
using System;

namespace ConnectFour
{
    class Board
    {
        private Token[][] tokens;

        public Board()
        {
            this.InitializeBoardTokens();
        }
        private void InitializeBoardTokens()
        {
            this.tokens = new Token[BoardConstant.BOARD_ROWS][];
            for (int i = 0; i < BoardConstant.BOARD_ROWS; i++)
            {
                this.tokens[i] = new Token[BoardConstant.BOARD_COLUMNS];
                for (int j = 0; j < BoardConstant.BOARD_COLUMNS; j++)
                {
                    this.tokens[i][j] = Token.NULL;
                }
            }
        }
        public void PutToken(Token token, int columnNumber)
        {
            int emptyRow = this.GetFirstEmptyRowInColumn(columnNumber);
            this.tokens[emptyRow][columnNumber - 1] = token;
        }
        internal bool CanInsertIntoColumn(int columnNumber)
        {
            if(columnNumber > BoardConstant.BOARD_COLUMNS || columnNumber < 0)
            {
                Console.WriteLine("The column number is bigger than the maximum column number or smaller than 0");
                return false;
            }
            int emptyRow = this.GetFirstEmptyRowInColumn(columnNumber);   
            return emptyRow != -1;
        }
        private int GetFirstEmptyRowInColumn(int columnNumber)
        {
            int column = columnNumber - 1;
            int emptyRow = -1;
            for (int row = BoardConstant.BOARD_ROWS - 1; row >= 0 && emptyRow == -1; row--)
            {
                if (this.tokens[row][column] == Token.NULL)
                {
                    emptyRow = row;
                }
            }
            return emptyRow;
        }
        private bool IsHorizontalConnectedFour()
        {
            bool hasConnectedFour = false;
            for(int row = 0; !hasConnectedFour && row < BoardConstant.BOARD_ROWS; row++)
            {
                for(int column = 0; !hasConnectedFour && column <= BoardConstant.MAX_COLUMN_TO_CHECK; column++)
                {
                    hasConnectedFour = this.CheckRowHasConnectedFour(row, column);
                }
            }
            return hasConnectedFour;
        }
        private bool CheckRowHasConnectedFour(int row, int column)
        {
            int tokensToCheck = BoardConstant.WIN_NUMBER - 1;
            int lastColumnIndex = column + tokensToCheck;
            Token firstToken = this.tokens[row][column];
            bool isEqualsToFirstToken = true;
            if (this.tokens[row][column] == Token.NULL)
            {
                return false;
            }
            for (int c = column+1; isEqualsToFirstToken && c <= lastColumnIndex; c++)
            {
                isEqualsToFirstToken = this.tokens[row][c] == firstToken;
            }
            return isEqualsToFirstToken;
        }
        private bool IsVerticalConnectedFour()
        {
            bool hasConnectedFour = false;
            for (int column = 0; !hasConnectedFour && column < BoardConstant.BOARD_COLUMNS; column++)
            {
                for(int row = 0; !hasConnectedFour && row <= BoardConstant.MAX_ROW_TO_CHECK; row++)
                {
                    hasConnectedFour = this.CheckColumnHasConnectedFour(row, column);
                }
            }
            return hasConnectedFour;
        }
        private bool CheckColumnHasConnectedFour(int row, int column)
        {
            int tokensToCheck = BoardConstant.WIN_NUMBER - 1;
            int lastRowIndex = row + tokensToCheck;
            Token firstToken = this.tokens[row][column];
            bool isEqualsToFirstToken = true;
            if (this.tokens[row][column] == Token.NULL)
            {
                return false;
            }
            for (int r = row + 1; isEqualsToFirstToken && r <= lastRowIndex; r++)
            {
                isEqualsToFirstToken = this.tokens[r][column] == firstToken;
            }
            return isEqualsToFirstToken;
        }

        private bool IsDiagonalConnectedFour()
        {
            bool hasConnectFour = false;
            for(int row = 0; !hasConnectFour && row <= BoardConstant.MAX_ROW_TO_CHECK; row++)
            {
                for(int column = 0; !hasConnectFour && column <= BoardConstant.MAX_COLUMN_TO_CHECK; column++)
                {
                    hasConnectFour = this.CheckDiagonalHasConnectedFour(row, column);
                }
            }
            return hasConnectFour;
        }
        private bool IsInvertedDiagonalConnectedFour()
        {
            bool hasConnectFour = false;
            for(int row = BoardConstant.BOARD_ROWS -1; !hasConnectFour && row > BoardConstant.MAX_ROW_TO_CHECK; row--)
            {
                for(int column = 0; !hasConnectFour && column <= BoardConstant.MAX_COLUMN_TO_CHECK; column++)
                {
                    hasConnectFour = this.CheckDiagonalHasConnectedFour(row, column, true);
                }
            }
            return hasConnectFour;
        }
        private bool CheckDiagonalHasConnectedFour(int row, int column, bool invertedDiagonal = false)
        {
            bool isEqualToFirstToken = true;
            Token firstToken = this.tokens[row][column];
            if(firstToken == Token.NULL)
            {
                return false;
            }
            for(int i = 0; isEqualToFirstToken && i < BoardConstant.WIN_NUMBER; i++)
            {
                int nextRowIndex = row + i;
                int nextColumnIndex = column + i;
                if (invertedDiagonal)
                {
                    nextRowIndex = row - i;
                }
                isEqualToFirstToken = this.tokens[nextRowIndex][nextColumnIndex] == firstToken;
            }
            return isEqualToFirstToken;
        }
        public bool IsConnectedFour()
        {
            return IsHorizontalConnectedFour() || IsVerticalConnectedFour() || IsDiagonalConnectedFour() || IsInvertedDiagonalConnectedFour();
        }
        public bool IsBoardComplete()
        {
            bool boardComplete = true;
            for(int row = 0; boardComplete && row < BoardConstant.BOARD_ROWS; row++)
            {
                for(int column = 0; boardComplete && column < BoardConstant.BOARD_COLUMNS; column++)
                {
                    if(this.tokens[row][column] == Token.NULL)
                    {
                        boardComplete = false;
                    }
                }
            }
            return boardComplete;
        }
        public void PrintBoard()
        {
            for(int row = 0; row < tokens.Length; row++)
            {
                for(int column = 0; column < tokens[row].Length; column++)
                {
                    Console.Write($"[{(char)tokens[row][column]}]");
                }
                Console.Write("\n");
            }
        }
    }
}
