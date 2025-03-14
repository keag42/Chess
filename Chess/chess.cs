using System;
using System.Collections;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more informatin
namespace Chess {
    internal class chessDrver {
        public static void Main(string[] args) {
            ChessBoard board = new ChessBoard();
            ChessBoard.SetStartingPositions();
            ChessBoard.PrintBoard();
            Console.WriteLine("----------------------------\n" + "----------------------------\n" + "\n \n \n" );
            
            
            //Console.WriteLine("         Round: " + ChessBoard.roundCount + "\n");//round title
            //ChessBoard.PrintBoard();
            
            Console.WriteLine("select a piece:  ex 'a5', 'h7'");
            String letter = Console.ReadLine();
            var (x, y) = ChessBoard.letterToXY(letter);
            if (ChessBoard.getPosition(x, y).ToString() == "P ") {
                Console.WriteLine("you selected pawn: " + letter);
                Pieces.PawnMove(x, y, true);//true for test
            }
            
            
           
            
            //place all code above this
            return;
        }
    }
}