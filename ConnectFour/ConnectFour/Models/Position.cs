namespace ConnectFour.Models
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Position(): this(0, 0) {}

        public Position(Position other): this(other.Row,other.Column) {}

        public void SumOtherPosition(Position other)
        {
            this.Row += other.Row;
            this.Column += other.Column;
        }
    }
}
