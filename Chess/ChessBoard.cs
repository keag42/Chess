using System;
using System.Collections.Generic;
using System.Linq; // Required for .Cast<object>()

namespace Chess {
    public class ChessBoard {
        public static int roundCount = -32;//starts at 32 because when i create each piece it updates and i only want it to start counting once each piece is made
        public static List<List<string>> board2D = new List<List<string>>() {
            new List<string> { "   ", "A ", "B ", "C ", "D ", "E ", "F ", "G ", "H " }, 
            new List<string> { "1 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " },
            new List<string> { "2 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " }, //black side
            new List<string> { "3 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " },
            new List<string> { "4 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " },
            new List<string> { "5 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " },
            new List<string> { "6 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " },
            new List<string> { "7 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " }, //white side
            new List<string> { "8 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " }
        };

        

        public static void setPosition(int xAxis, int yAxis, string type) {
            board2D[yAxis][xAxis] = type + " ";
            roundCount++; //update round counter
        }
        public static String getPosition(int xAxis, int yAxis) {
            return board2D[yAxis][xAxis];
        }

        public static (int, int) letterToXY(string move) {
            int x = move[0] - 'a' + 1;
            int y = int.Parse(move[1].ToString());
            return (x, y);
        } 
        public static void replaceTile(int xAxis, int yAxis) {
            board2D[yAxis][xAxis] = yAxis % 2 == 0 ? (xAxis % 2 ==0 ? "x " : "o ") : (xAxis % 2 == 0 ? "o " : "x ");
        }
        public static void PrintBoard() {
            int rowIndex = 0;
            Console.WriteLine("         Round: " + ChessBoard.roundCount + "\n");  //round title
            foreach (var row in board2D) {
                string result = string.Join(" ", row);
                Console.WriteLine(result);
                if (rowIndex == 0) {
                    Console.WriteLine("    _  _  _  _  _  _  _  _ ");
                }
                rowIndex++;
            }
        }
        public static void setStartingPositions() {
            Pieces.setPawnStartingPosition(); //create pawns
            Pieces.setRookStartingPosition(); //create rooks
            Pieces.setBishipStartingPosition(); //create bishops
            Pieces.setHorseStartingPosition(); //create horses
            Pieces.setQueenStartingPosition(); //creates queens
            Pieces.setKingStartingPosition(); //creates kings
        }
    }
}