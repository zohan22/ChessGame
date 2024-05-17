using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Queen : Piece
    {
        public Queen()
        {
            Icon = "Q";
            Type = 'Q';
        }

        public Queen(int x, int y, char c) : base(x, y, c, 'Q')
        {
            Icon = "Q";
        }

        public override bool ValidateMove(int posX, int posY, Piece square)
        {
            int diffX = Math.Abs(posX - PosX);
            int diffY = Math.Abs(posY - PosY);

            return (posX == PosX || posY == PosY || diffX == diffY) && square == null;
        }
    }
}

