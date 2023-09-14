using System;
using ConnectFour.Constants;
using ConnectFour.Enums;

namespace ConnectFour
{
    class Board
    {
        public Token[][] tokens;

        public Board()
        {
            this.InitializeBoardTokens();
        }

        private void InitializeBoardTokens()
        {
            this.tokens = new Token[BoardConstant.BOARD_ROWS][];
            for (int row = 0; row < BoardConstant.BOARD_ROWS; row++)
            {
                this.tokens[row] = new Token[BoardConstant.BOARD_COLUMNS];
                for (int column = 0; column < BoardConstant.BOARD_COLUMNS; column++)
                {
                    this.tokens[row][column] = Token.NULL;
                }
            }
        }

        public void PutToken(Token token, int column)
        {
            int emptyRow = this.GetFirstEmptyRowInColumn(column);
            this.tokens[emptyRow][column - 1] = token;
        }

        public bool CanInsertIntoColumn(int column)
        {
            if (column > BoardConstant.BOARD_COLUMNS || column < 0)
            {
                Console.WriteLine("The column number is bigger than the maximum column number or smaller than 0");
                return false;
            }
            int emptyRow = this.GetFirstEmptyRowInColumn(column);   
            return emptyRow != -1;
        }

        private int GetFirstEmptyRowInColumn(int column)
        {
            for (int row = 0; row < BoardConstant.BOARD_ROWS; row++)
            {
                if (this.tokens[row][column - 1] == Token.NULL)
                {
                    return row;
                }
            }
            return -1;
        }

        private bool IsHorizontalConnectedFour()
        {
            bool hasConnectedFour = false;
            for (int row = 0; !hasConnectedFour && row < BoardConstant.BOARD_ROWS; row++)
            {
                hasConnectedFour = CheckRowHasConnectedFour(row);
            }
            return hasConnectedFour;
        }

        private bool CheckRowHasConnectedFour(int row)
        {
            Token referenceToken = this.tokens[row][0];
            for (int column = 1, goal = 1; column < BoardConstant.BOARD_COLUMNS; column++, goal++)
            {
                if (goal == BoardConstant.WIN_NUMBER)
                {
                    return true;
                }
                Token currentToken = this.tokens[row][column];
                if (referenceToken == Token.NULL || referenceToken != currentToken)
                {
                    referenceToken = currentToken;
                    goal = 0;
                }
            }
            return false;
        }

        private bool IsVerticalConnectedFour()
        {
            bool hasConnectedFour = false;
            for (int column = 0; !hasConnectedFour && column < BoardConstant.BOARD_COLUMNS; column++)
            {
                hasConnectedFour = CheckColumnHasConnectedFour(column);
            }
            return hasConnectedFour;
        }

        private bool CheckColumnHasConnectedFour(int column)
        {
            Token referenceToken = this.tokens[0][column];
            for (int row = 1, goal = 1; row < BoardConstant.BOARD_ROWS; row++, goal++)
            {
                if (goal == BoardConstant.WIN_NUMBER)
                {
                    return true;
                }
                Token currentToken = this.tokens[row][column];
                if (referenceToken == Token.NULL || referenceToken != currentToken)
                {
                    referenceToken = currentToken;
                    goal = 0;
                }
            }
            return false;
        }

        private bool IsDiagonalConnectedFour(Token token)
        {
            return CheckBottomLeftToTopRight(token) || CheckBottomRightToTopLeft(token) ||
                    CheckTopLeftToBottomRight(token) || CheckTopRightToBottomLeft(token); 
        }

        private bool CheckBottomLeftToTopRight(Token token)
        {
            for (int row = 0; row <= BoardConstant.BOARD_ROWS - 4; row++)
            {
                for (int column = 0; column <= BoardConstant.BOARD_COLUMNS - 4; column++)
                {
                    if (this.tokens[row][column] == token &&
                        this.tokens[row + 1][column + 1] == token &&
                        this.tokens[row + 2][column + 2] == token &&
                        this.tokens[row + 3][column + 3] == token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckBottomRightToTopLeft(Token token)
        {
            for (int row = 0; row <= BoardConstant.BOARD_ROWS - 4; row++)
            {
                for (int column = 3; column < BoardConstant.BOARD_COLUMNS; column++)
                {
                    if (this.tokens[row][column] == token &&
                        this.tokens[row + 1][column - 1] == token &&
                        this.tokens[row + 2][column - 2] == token &&
                        this.tokens[row + 3][column - 3] == token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckTopLeftToBottomRight(Token token)
        {
            for (int row = 3; row < BoardConstant.BOARD_ROWS; row++)
            {
                for (int column = 0; column <= BoardConstant.BOARD_COLUMNS - 4; column++)
                {
                    if (this.tokens[row][column] == token &&
                        this.tokens[row - 1][column + 1] == token &&
                        this.tokens[row - 2][column + 2] == token &&
                        this.tokens[row - 3][column + 3] == token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckTopRightToBottomLeft(Token token)
        {
            for (int row = 3; row < BoardConstant.BOARD_ROWS; row++)
            {
                for (int column = 3; column < BoardConstant.BOARD_COLUMNS; column++)
                {
                    if (this.tokens[row][column] == token &&
                        this.tokens[row - 1][column - 1] == token &&
                        this.tokens[row - 2][column - 2] == token &&
                        this.tokens[row - 3][column - 3] == token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    
        public bool IsConnectedFour(Token token)
        {
            return IsHorizontalConnectedFour() ||
                   IsVerticalConnectedFour() ||
                   IsDiagonalConnectedFour(token);
        }

        public bool IsBoardComplete()
        {
            for (int row = 0; row < BoardConstant.BOARD_ROWS; row++)
            {
                for (int column = 0; column < BoardConstant.BOARD_COLUMNS; column++)
                {
                    if (this.tokens[row][column] == Token.NULL)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void PrintBoard()
        {
            for (int row = BoardConstant.BOARD_ROWS - 1; row >= 0; row--)
            {
                for (int column = 0; column < BoardConstant.BOARD_COLUMNS; column++)
                {
                    Console.Write($"[{(char)tokens[row][column]}]");
                }
                Console.Write("\n");
            }
        }
    }
}
