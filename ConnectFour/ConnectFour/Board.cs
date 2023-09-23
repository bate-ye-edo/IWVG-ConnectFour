﻿using ConnectFour.Constants;
using ConnectFour.Enums;

namespace ConnectFour
{
    class Board
    {
        internal const int BOARD_COLUMNS = 7;
        internal const int BOARD_ROWS = 6;
        internal const int WIN_NUMBER = 4;
        public Token[][] Tokens { get; init; }
        private readonly Position lastTokenPosition;
        public Board()
        {
            this.Tokens = new Token[BOARD_ROWS][];
            this.InitializeBoardColumns();
            lastTokenPosition = new Position();
        }
        private void InitializeBoardColumns()
        {
            for (int i = 0; i < BOARD_ROWS; i++)
            {
                this.Tokens[i] = new Token[BOARD_COLUMNS];
                for (int j = 0; j < BOARD_COLUMNS; j++)
                {
                    this.Tokens[i][j] = Token.NULL;
                }
            }
        }
        public void PutToken(Token token, int columnNumber)
        {
            int emptyRow = this.GetFirstEmptyRowInColumn(columnNumber);
            this.Tokens[emptyRow][columnNumber - 1] = token;
            this.lastTokenPosition.Row = emptyRow;
            this.lastTokenPosition.Column = columnNumber - 1;
        }
        internal bool CanInsertIntoColumn(int columnNumber)
        {
            Assertion.AssertTrue(columnNumber < 0 || columnNumber > BOARD_COLUMNS);
            int emptyRow = this.GetFirstEmptyRowInColumn(columnNumber);   
            return emptyRow != -1;
        }
        private int GetFirstEmptyRowInColumn(int columnNumber)
        {
            int column = columnNumber - 1;
            int emptyRow = -1;
            for (int row = BOARD_ROWS - 1; row >= 0 && emptyRow == -1; row--)
            {
                if (this.Tokens[row][column] == Token.NULL)
                {
                    emptyRow = row;
                }
            }
            return emptyRow;
        }

        private Line CreateLine(Position orientation)
        {
            Line line = new();
            int tokensInsertedToLine = 0;
            Position currentCoordinate = new(lastTokenPosition);
            while (this.IsValidCoordinate(currentCoordinate) && tokensInsertedToLine < WIN_NUMBER)
            {
                line.AddToken(this.Tokens[currentCoordinate.Row][currentCoordinate.Column]);
                currentCoordinate.SumOtherPosition(orientation);
                tokensInsertedToLine++;
            }
            return line;
        }
        private bool IsValidCoordinate(Position coordinate)
        {
            bool isXValid = coordinate.Row >= 0 && coordinate.Row < BOARD_ROWS;
            bool isYValid = coordinate.Column >= 0 && coordinate.Column < BOARD_COLUMNS;
            return isXValid && isYValid;
        }
        private bool CheckIfLineHasConnectedFour(Position createLineOrientation, Position slideOrientation)
        {
            Line line = CreateLine(createLineOrientation);
            Position currentCoordinate = new(lastTokenPosition);
            currentCoordinate.SumOtherPosition(slideOrientation);
            bool isConnectedFour = line.IsAllElementTheSameInLine();
            while (!isConnectedFour && this.IsValidCoordinate(currentCoordinate))
            {
                line.SlideLineWithOneToken(this.Tokens[currentCoordinate.Row][currentCoordinate.Column]);
                currentCoordinate.SumOtherPosition(slideOrientation);
                isConnectedFour = line.IsAllElementTheSameInLine();
            }
            return isConnectedFour;
        }
        private bool IsHorizontalConnectedFour()
        {
            return this.CheckIfLineHasConnectedFour(Orientation.EAST, Orientation.WEST);
        }
        private bool IsVerticalConnectedFour()
        {
            return this.CheckIfLineHasConnectedFour(Orientation.SOUTH, Orientation.NORTH);
        }

        private bool IsDiagonalConnectedFour()
        {
            return this.CheckIfLineHasConnectedFour(Orientation.SOUTHEAST, Orientation.NORTHWEST);
        }
        private bool IsInvertedDiagonalConnectedFour()
        {
            return this.CheckIfLineHasConnectedFour(Orientation.SOUTHWEST, Orientation.NORTHEAST);
        }
        public bool IsConnectedFour()
        {
            return IsHorizontalConnectedFour() || IsVerticalConnectedFour() || IsDiagonalConnectedFour() || IsInvertedDiagonalConnectedFour();
        }
        public bool IsBoardComplete()
        {
            bool boardComplete = true;
            for(int row = 0; boardComplete && row < BOARD_ROWS; row++)
            {
                for(int column = 0; boardComplete && column < BOARD_COLUMNS; column++)
                {
                    if(this.Tokens[row][column] == Token.NULL)
                    {
                        boardComplete = false;
                    }
                }
            }
            return boardComplete;
        }
    }
}
