using System;

namespace Chess
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Position(string column, int row)
        {
            Row = 8 - row;
            Column = char.Parse(column) - 97;
        }

        public override string ToString()
        {
            return $"{8 - Row}{(char) (Column + 97)}";
        }
    }
}