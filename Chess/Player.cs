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

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}