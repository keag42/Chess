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
            
            /*
            Console.WriteLine("select a piece:" + "\n select the letter");
            String letter = Console.ReadLine();
            Console.WriteLine("select the number");
            byte numY = Convert.ToByte(Console.Read());
            byte letterToNum = 0;
            
            switch (letter) {
                case "A":
                case "a":
                    letterToNum = 1;
                    break;
                case "B":
                case "b":
                    letterToNum = 2;
                    break;
                case "C":
                case "c":
                    letterToNum = 3;
                    break;
                case "D":
                case "d":
                    letterToNum = 4;
                    break;
                case "E":
                case "e":
                    letterToNum = 5;
                    break;
                case "F":
                case "f":
                    letterToNum = 6;
                    break;
                case "G":
                case "g":
                    letterToNum = 7;
                    break;
                case "H":
                case "h":
                    letterToNum = 8;
                    break;
            } //wildly inefficient??
            
            Console.WriteLine(ChessBoard.board2D[letterToNum][numY]);
            */

            Console.WriteLine("pawn testing");
            Pawn.PawnMove(3, 2, true);
            ChessBoard.PrintBoard();
            return;
        }
    }
}