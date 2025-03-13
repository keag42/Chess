using System;
using System.Collections;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more informatin
namespace Chess {
    internal class chessDrver {
        public static void Main(string[] args) {
            ChessBoard board = new ChessBoard();
            ChessBoard.setStartingPositions();
            ChessBoard.PrintBoard();
            Console.WriteLine("----------------------------\n" + "----------------------------\n" + "\n \n \n" );
            
            
            //Console.WriteLine("         Round: " + ChessBoard.roundCount + "\n");//round title
            //ChessBoard.PrintBoard();
            
            Console.WriteLine("select a piece:  ex 'a5', 'h7'");
            String letter = Console.ReadLine();
            var (x, y) = ChessBoard.letterToXY(letter);
            Console.WriteLine(ChessBoard.getPosition(x, y));
            if (ChessBoard.getPosition(x, y) == "P ") {
                Console.WriteLine("you selected pawn: " + letter);
                Pawn.PawnMove(x, y, true);
            }
            

            //TESTING =====================================
            //Console.WriteLine("pawn testing");
           
            
            //place all code above this
            return;
        }
    }
}