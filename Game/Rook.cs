using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Rook : Piece
    {
        public Rook()
        {
            Icon = "R";
            Type = 'R';
        }

        public Rook(int x, int y, char c) : base(x, y, c, 'R')
        {
            Icon = "R";
        }

        public override bool ValidateMove(int posX, int posY, Piece square)
        {
            return (posX == PosX || posY == PosY) && square == null;
        }
    }
}

