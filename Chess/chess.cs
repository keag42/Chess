using System;
using System.Collections;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more informatin
namespace Chess {
    internal class ChessDriver {
        public static void Main(string[] args) {
            ChessBoard board = new ChessBoard();
            ChessBoard.SetStartingPositions();
            ChessBoard.PrintBoard();
            Console.WriteLine("----------------------------\n" + "----------------------------\n" + "\n \n \n" );
            
            
            //Console.WriteLine("         Round: " + ChessBoard.roundCount + "\n");//round title
            //ChessBoard.PrintBoard();
            MovePiece();
            //place all code above this
            return;
        }

        public static void MovePiece() {
            while (true) {
                Console.WriteLine("select a piece:  ex 'a5', 'h7'");
                string letter = Console.ReadLine();
                var (x, y) = ChessBoard.letterToXY(letter);
                string pieceName = ChessBoard.getPosition(x, y);

                // Null check for piece existence at the position
                var piece = ChessBoard.getPiecePositionValues(x, y); // Getting the piece at the selected position
                if (piece == null) {
                    Console.WriteLine("No piece at this position.");
                    continue; // If no piece, continue the loop and ask for a new move
                }

                switch (pieceName) {
                    case "P ":
                        Console.WriteLine("you selected pawn: " + letter);
                        piece.PawnMove(); // Call the piece method, assuming it's not null now
                        break;
                    case "R ":
                        Console.WriteLine("you selected rook: " + letter);
                        break;
                    case "B ":
                        Console.WriteLine("you selected bishop: " + letter);
                        break;
                    case "H ":
                        Console.WriteLine("you selected horse: " + letter);
                        break;
                    case "Q ":
                        Console.WriteLine("you selected queen: " + letter);
                        break;
                    case "K ":
                        Console.WriteLine("you selected king: " + letter);
                        break;
                    default:
                        Console.WriteLine("that is an empty spot.");
                        continue;
                }

                Console.WriteLine("exit? e");
                if (Console.ReadLine() == "e")
                    break;
            }
        }

    }
}