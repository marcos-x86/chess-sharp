using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;
using Chess.Constants;

namespace Chess
{
    public class Player
    {
        public string Name { get; }
        public Color Color { get; }
        public BoardPosition BoardPosition { get; }

        public Player(string name, Color color, BoardPosition boardPosition)
        {
            Name = name;
            Color = color;
            BoardPosition = boardPosition;
        }
    }
}