using ConnectFour.Constants;
using ConnectFour.Enums;
using ConnectFour.Utils;

namespace ConnectFour.Models
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
        private bool CheckIfLineHasConnectedFour(Position createLineDirection, Position slideDirection)
        {
            Line line = CreateLine(createLineDirection);
            Position currentPosition = new(lastTokenPosition);
            currentPosition.SumOtherPosition(slideDirection);
            bool isConnectedFour = line.AreAllTokensEqualsAndNotNull();
            while (!isConnectedFour && Board.IsValidPosition(currentPosition))
            {
                line.SlideLineWithOneToken(this.Tokens[currentPosition.Row][currentPosition.Column]);
                currentPosition.SumOtherPosition(slideDirection);
                isConnectedFour = line.AreAllTokensEqualsAndNotNull();
            }
            return isConnectedFour;
        }

        private Line CreateLine(Position orientation)
        {
            Line line = new();
            Position currentPosition = new(lastTokenPosition);
            while (Board.IsValidPosition(currentPosition) && line.GetInsertedTokensCount() < WIN_NUMBER)
            {
                line.AddToken(this.Tokens[currentPosition.Row][currentPosition.Column]);
                currentPosition.SumOtherPosition(orientation);
            }
            return line;
        }
        private static bool IsValidPosition(Position position)
        {
            bool isRowValid = position.Row >= 0 && position.Row < BOARD_ROWS;
            bool isColumnValid = position.Column >= 0 && position.Column < BOARD_COLUMNS;
            return isRowValid && isColumnValid;
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
