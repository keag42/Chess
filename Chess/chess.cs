using System;
using System.Collections;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more informatin
namespace Chess {
    internal class ChessDriver {
        public static void Main(string[] args) {
            ChessBoard board = new ChessBoard();
            board.PrintBoard();
            Console.WriteLine("----------------------------\n" + "----------------------------\n" + "\n \n \n" );

            
            MovePiece(board);
        }
        public static void MovePiece(ChessBoard board) {
            while (true) {
                Console.WriteLine("Select a piece (e.g., 'a2', 'h7') or type 'exit' to quit:");
                string input = Console.ReadLine().ToLower();

                if (input == "exit") break;

                // Convert input to coordinates (e.g., "a2" -> x=1, y=2)
                var (x, y) = board.letterToXY(input);
                Pieces selectedPiece = board.getPiecePositionValues(x, y);

                if (selectedPiece == null) {
                    Console.WriteLine("No piece at this position. Try again.");
                    continue;
                }

                // Call the appropriate move method based on the piece type
                switch (selectedPiece.GetType().Trim()) {
                    // Trim to remove spaces
                    case "P":
                        selectedPiece.PawnMove();
                        break;
                    case "H":
                        selectedPiece.HorseMove();
                        break;
                    case "R":
                        selectedPiece.RookMove(); //not working
                        break;
                    case "B":
                        selectedPiece.BishopMove(); //not working
                        break;
                    case "Q":
                        selectedPiece.QueenMove(); //not working
                        break;
                    case "K":
                        selectedPiece.KingMove();
                        break;
                    default:
                        Console.WriteLine("Unknown piece type.");
                        break;
                }

                board.PrintBoard(); // Refresh the board after the move
            }
        }
    }
}