using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Player
    {
        public string Name { get; }
        public Color Color { get; }
        public BoardPosition BoardPosition { get; set; }

        public Player(string name, Color color, BoardPosition boardPosition)
        {
            Name = name;
            Color = color;
            BoardPosition = boardPosition;
        }
    }
}