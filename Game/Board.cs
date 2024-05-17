using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Board
    {
        private int sizeX;
        private int sizeY;
        private List<Piece> pieceList;
        private int numPieces;

        public Board()
        {
            sizeX = 8;
            sizeY = 8;
            pieceList = new List<Piece>();
            numPieces = 0;
            InitializePieces();
        }

        private void InitializePieces()
        {
            pieceList.Add(new Rook(0, 0, 'B'));
            pieceList.Add(new Knight(1, 0, 'B'));
            pieceList.Add(new Bishop(2, 0, 'B'));
            pieceList.Add(new Queen(3, 0, 'B'));
            pieceList.Add(new King(4, 0, 'B'));
            pieceList.Add(new Bishop(5, 0, 'B'));
            pieceList.Add(new Knight(6, 0, 'B'));
            pieceList.Add(new Rook(7, 0, 'B'));
            pieceList.Add(new Pawn(0, 1, 'B'));
            pieceList.Add(new Pawn(1, 1, 'B'));
            pieceList.Add(new Pawn(2, 1, 'B'));
            pieceList.Add(new Pawn(3, 1, 'B'));
            pieceList.Add(new Pawn(4, 1, 'B'));
            pieceList.Add(new Pawn(5, 1, 'B'));
            pieceList.Add(new Pawn(6, 1, 'B'));
            pieceList.Add(new Pawn(7, 1, 'B'));

            pieceList.Add(new Rook(0, 7, 'W'));
            pieceList.Add(new Knight(1, 7, 'W'));
            pieceList.Add(new Bishop(2, 7, 'W'));
            pieceList.Add(new Queen(3, 7, 'W'));
            pieceList.Add(new King(4, 7, 'W'));
            pieceList.Add(new Bishop(5, 7, 'W'));
            pieceList.Add(new Knight(6, 7, 'W'));
            pieceList.Add(new Rook(7, 7, 'W'));
            pieceList.Add(new Pawn(0, 6, 'W'));
            pieceList.Add(new Pawn(1, 6, 'W'));
            pieceList.Add(new Pawn(2, 6, 'W'));
            pieceList.Add(new Pawn(3, 6, 'W'));
            pieceList.Add(new Pawn(4, 6, 'W'));
            pieceList.Add(new Pawn(5, 6, 'W'));
            pieceList.Add(new Pawn(6, 6, 'W'));
            pieceList.Add(new Pawn(7, 6, 'W'));
        }

        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("  A  B  C  D  E  F  G  H");
            Console.WriteLine(" +-----------------------+");

            for (int i = 0; i < sizeY; i++)
            {
                Console.Write($"{i + 1}| ");
                for (int j = 0; j < sizeX; j++)
                {
                    Piece piece = FindPiece(i, j);
                    if (piece != null)
                    {
                        Console.Write($"{piece.Icon} ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine("|");
            }

            Console.WriteLine(" +-----------------------+");
        }

        public bool IsValidPosition(string pos)
        {
            if (pos.Length != 2)
            {
                return false;
            }

            int x = pos[0] - 'A';
            int y = pos[1] - '1';

            return x >= 0 && x < sizeX && y >= 0 && y < sizeY;
        }

        public Piece FindPiece(int y, int x)
        {
            return pieceList.Find(p => p.PosX == x && p.PosY == y);
        }

        public void RemovePiece(int y, int x)
        {
            pieceList.RemoveAll(p => p.PosX == x && p.PosY == y);
        }

        public bool MovePiece(int y1, int x1, int y2, int x2, bool turn)
        {
            Piece sourcePiece = FindPiece(y1, x1);
            Piece destPiece = FindPiece(y2, x2);

            if (sourcePiece != null && sourcePiece.Color == (turn ? 'W' : 'B'))
            {
                if (sourcePiece.ValidateMove(x2, y2, destPiece))
                {
                    if (destPiece != null)
                    {
                        RemovePiece(y2, x2);
                    }
                    sourcePiece.SetPosX(x2);
                    sourcePiece.SetPosY(y2);
                    return true;
                }
            }

            return false;
        }

        public bool IsInCheck(char kingColor)
        {
            Piece king = FindKing(kingColor);
            if (king == null)
            {
                return false;
            }

            foreach (Piece piece in pieceList)
            {
                if (piece.Color != kingColor)
                {
                    if (piece.ValidateMove(king.PosX, king.PosY, null))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsCheckmate(char kingColor)
        {
            if (!IsInCheck(kingColor))
            {
                return false;
            }

            Piece king = FindKing(kingColor);
            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    int x = king.PosX + dx;
                    int y = king.PosY + dy;
                    if (MovePiece(king.PosY, king.PosX, y, x, true))
                    {
                        MovePiece(y, x, king.PosY, king.PosX, true);
                        return false;
                    }
                }
            }

            return true;
        }

        private Piece FindKing(char kingColor)
        {
            return pieceList.Find(p => p is King && p.Color == kingColor);
        }
    }
}


