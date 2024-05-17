using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Knight : Piece
    {
        public Knight()
        {
            Icon = "N";
            Type = 'N';
        }

        public Knight(int x, int y, char c) : base(x, y, c, 'N')
        {
            Icon = "N";
        }

        public override bool ValidateMove(int posX, int posY, Piece square)
        {
            int diffX = Math.Abs(posX - PosX);
            int diffY = Math.Abs(posY - PosY);

            // L-shaped move (2 squares in one direction and 1 square in a perpendicular direction)
            return (diffX == 1 && diffY == 2) || (diffX == 2 && diffY == 1);
        }
    }
}


