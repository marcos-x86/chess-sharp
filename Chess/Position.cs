using System;

namespace Chess
{
    public class Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
        
        public Position(string column, int row)
        {
            Row = 8 - row;
            Column = char.Parse(column) - 'a';
        }

        public override string ToString()
        {
            return Row + ", " + Column;
        }


        public void SetValues(int x, int y)
        {
            Row = x;
            Column = y;
        }
    }
}