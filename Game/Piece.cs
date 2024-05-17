using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Piece
    {
        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public char Color { get; protected set; }
        public string Icon { get; protected set; }
        public char Type { get; protected set; }

        public Piece()
        {
            PosX = 0;
            PosY = 0;
            Color = ' ';
            Icon = "";
            Type = ' ';
        }

        public Piece(int x, int y, char c, char type)
        {
            PosX = x;
            PosY = y;
            Color = c;
            Icon = "";
            Type = type;
        }

        public virtual bool ValidateMove(int posX, int posY, Piece square)
        {
            return true;
        }

        public void SetPosX(int x)
        {
            PosX = x;
        }

        public void SetPosY(int y)
        {
            PosY = y;
        }

        public int GetPosX()
        {
            return PosX;
        }

        public int GetPosY()
        {
            return PosY;
        }

        public char GetColor()
        {
            return Color;
        }

        public string GetIcon()
        {
            return Icon;
        }

        public char GetType()
        {
            return Type;
        }
    }
}

