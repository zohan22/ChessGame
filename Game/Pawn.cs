using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Pawn : Piece
    {
        private bool firstMove;

        public Pawn()
        {
            firstMove = true;
            Icon = "P";
            Type = 'P';
        }

        public Pawn(int x, int y, char c) : base(x, y, c, 'P')
        {
            firstMove = true;
            Icon = "P";
        }

        public override bool ValidateMove(int posX, int posY, Piece square)
        {
            if (square == null && posX == PosX && ((PosY + 1 == posY && Color == 'W') || (PosY - 1 == posY && Color == 'B')))
            {
                firstMove = false;
                return true;
            }

            else if (square != null && posX == PosX + 1 && ((PosY + 1 == posY && Color == 'W') || (PosY - 1 == posY && Color == 'B')))
            {
                return true;
            }
            return false;
        }
    }
}


