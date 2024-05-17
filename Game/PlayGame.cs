using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayGame
    {
        private Board board;
        private bool whiteTurn;
        private string currentPlayer;

        public PlayGame()
        {
            board = new Board();
            whiteTurn = true;
            currentPlayer = "White";
        }

        public void AnnounceWinner(string winner)
        {
            Console.WriteLine($"Game over! The winner is: {winner}");
        }

        public bool DetermineWinner()
        {
            if (board.IsCheckmate(whiteTurn ? 'W' : 'B'))
            {
                AnnounceWinner(whiteTurn ? "White" : "Black");
                return true;
            }
            return false;
        }

        public void ExecuteMove(string startPos, string endPos)
        {

            int x1 = startPos[0] - 'A';
            int y1 = startPos[1] - '1';
            int x2 = endPos[0] - 'A';
            int y2 = endPos[1] - '1';

            if (!board.IsValidPosition(startPos) || !board.IsValidPosition(endPos))
            {
                Console.WriteLine("Invalid positions entered.");
                return;
            }

            Piece sourcePiece = board.FindPiece(y1, x1);
            Piece destPiece = board.FindPiece(y2, x2);

            if (sourcePiece == null)
            {
                Console.WriteLine("No piece at the starting position.");
                return;
            }

            if (sourcePiece.Color == (whiteTurn ? 'W' : 'B'))
            {
                if (sourcePiece.ValidateMove(x2, y2, destPiece))
                {
                    board.MovePiece(y1, x1, y2, x2, whiteTurn);
                    whiteTurn = !whiteTurn;
                    ShowMoveInformation(sourcePiece, startPos, endPos);
                    DetermineCapturedPieces(destPiece);
                }
                else
                {
                    Console.WriteLine("Invalid move for the selected piece.");
                }
            }
            else
            {
                Console.WriteLine("You cannot move an opponent's piece on your turn.");
            }
        }

        public void RunGame()
        {
            while (true)
            {
                board.PrintBoard();

                Console.WriteLine($"Turn of {(whiteTurn ? "white" : "black")} pieces");
                Console.WriteLine("Enter the starting position (A2):");
                string startPos = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter the destination position (A4):");
                string endPos = Console.ReadLine().ToUpper();

                ExecuteMove(startPos, endPos);

                if (DetermineWinner())
                {
                    break;
                }

                currentPlayer = whiteTurn ? "Black" : "White";
            }
        }

        private void ShowMoveInformation(Piece piece, string startPos, string endPos)
        {
            string pieceName = GetPieceName(piece.GetType());
            Console.WriteLine($"Move: {pieceName} from {startPos} to {endPos}");
        }

        private void DetermineCapturedPieces(Piece destPiece)
        {
            if (destPiece != null)
            {
                string pieceName = GetPieceName(destPiece.GetType());
                Console.WriteLine($"Captured: {pieceName}!");
            }
        }

        private string GetPieceName(char pieceType)
        {
            switch (pieceType)
            {
                case 'P': return "Pawn";
                case 'R': return "Rook";
                case 'B': return "Bishop";
                case 'N': return "Knight";
                case 'Q': return "Queen";
                case 'K': return "King";
                default: return "Unknown Piece";
            }
        }
    }
}

