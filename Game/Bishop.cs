using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bishop : Piece
    {
        public Bishop()
        {
            Icon = "B";
            Type = 'B';
        }

        public Bishop(int x, int y, char c) : base(x, y, c, 'B')
        {
            Icon = "B";
        }

        public override bool ValidateMove(int posX, int posY, Piece square)
        {
            int diffX = Math.Abs(posX - PosX);
            int diffY = Math.Abs(posY - PosY);
            return diffX == diffY && square == null;
        }
    }
}


