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
            
            while (true) {
                Console.WriteLine("select a piece:  ex 'a5', 'h7'");
                String letter = Console.ReadLine();
                var (x, y) = ChessBoard.letterToXY(letter);
                if (ChessBoard.getPosition(x, y).ToString() == "P ") {
                    Console.WriteLine("you selected pawn: " + letter);
                    Pieces.PawnMove(x, y, true); //true for test
                }
                else if (ChessBoard.getPosition(x, y).ToString() == "R ") {
                    Console.WriteLine("you selected rook: " + letter);
                }
                else if (ChessBoard.getPosition(x, y).ToString() == "B ") {
                    Console.WriteLine("you selected bishop: " + letter);
                }
                else if (ChessBoard.getPosition(x, y).ToString() == "H ") {
                    Console.WriteLine("you selected horse: " + letter);
                    //ChessBoard.getPiecePositionValues(x, y)?.HorseMove();
                }
                else if (ChessBoard.getPosition(x, y).ToString() == "Q ") {
                    Console.WriteLine("you selected queen: " + letter);
                }
                else if (ChessBoard.getPosition(x, y).ToString() == "K ") {
                    Console.WriteLine("you selected king: " + letter);
                }
                else {
                    Console.WriteLine("that is an empty spot.");
                }

                Console.WriteLine("exit? e");
                if (Console.ReadLine() == "e")
                    break;
            }

            //place all code above this
            return;
        }
    }
}