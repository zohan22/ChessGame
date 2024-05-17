using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class King : Piece
    {
        public King()
        {
            Icon = "K";
            Type = 'K';
        }

        public King(int x, int y, char c) : base(x, y, c, 'K')
        {
            Icon = "K";
        }

        public override bool ValidateMove(int posX, int posY, Piece square)
        {
            int diffX = Math.Abs(posX - PosX);
            int diffY = Math.Abs(posY - PosY);
            return (diffX == 1 || diffY == 1) && square == null;
        }
    }
}

