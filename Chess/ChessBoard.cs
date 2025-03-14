using System;
using System.Collections.Generic;
using System.Linq; // Required for .Cast<object>()

namespace Chess {
    public class ChessBoard {
        public static int roundCount = -32;//starts at 32 because when i create each piece it updates and i only want it to start counting once each piece is made
        public static List<List<object>> board2D = new List<List<object>>() {
            new List<object> { "   ", "A ", "B ", "C ", "D ", "E ", "F ", "G ", "H " }, 
            new List<object> { "1 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " },
            new List<object> { "2 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " }, //black side
            new List<object> { "3 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " },
            new List<object> { "4 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " },
            new List<object> { "5 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " },
            new List<object> { "6 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " },
            new List<object> { "7 |", "x ", "o ", "x ", "o ", "x ", "o ", "x ", "o " }, //white side
            new List<object> { "8 |", "o ", "x ", "o ", "x ", "o ", "x ", "o ", "x " }
        };
        public static void setPosition(int xAxis, int yAxis, object piece) {
            board2D[yAxis][xAxis] = piece;
            roundCount++; //update round counter
        }
        public static String getPosition(int xAxis, int yAxis) {
            return board2D[yAxis][xAxis]?.ToString();//allows nullable
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
        
        //pawns
        static List<Pieces> whitePawns = new List<Pieces>();
        static List<Pieces> blackPawns = new List<Pieces>();
        //rooks
        static List<Pieces> whiteRooks = new List<Pieces>();
        static List<Pieces> blackRooks = new List<Pieces>();
        //Bishops
        static List<Pieces> whiteBishops = new List<Pieces>();
        static List<Pieces> blackBishops = new List<Pieces>();
        //Horse
        static List<Pieces> whiteHorses = new List<Pieces>();
        static List<Pieces> blackHorses = new List<Pieces>();
        //set queens
        static Pieces whiteQueen = new Pieces(4, 1, true, "Q ");
        static Pieces blackQueen = new Pieces(5,8, false, "Q ");
        //set kings
        static Pieces whiteKing= new Pieces(5, 1, true, "K ");
        static Pieces blackKing = new Pieces(4,8, false, "K ");
        public static void SetStartingPositions() {
            //set pawns
            for (int i = 1; i <= 8; i++) {
                whitePawns.Add( new Pieces(i, 2, true, "P ") ); //add white pawns
                blackPawns.Add(new Pieces(i, 7, false, "P ")); //add black pawns
            }
            //set rooks
            whiteRooks.Add( new Pieces(1, 1, true, "R ") );
            whiteRooks.Add( new Pieces(8, 1, true, "R ") );
            blackRooks.Add( new Pieces(1, 8, false, "R ") );
            blackRooks.Add( new Pieces(8, 8, false, "R ") );
            //set horses
            whiteHorses.Add( new Pieces(2, 1, true, "H ") );
            whiteHorses.Add( new Pieces(7, 1, true, "H ") );
            blackHorses.Add( new Pieces(2, 8, false, "H ") );
            blackHorses.Add( new Pieces(7, 8, false, "H ") );
            //set bishops
            whiteBishops.Add( new Pieces(3, 1, true, "B ") );
            whiteBishops.Add( new Pieces(6, 1,true, "B ") );
            blackBishops.Add( new Pieces(3, 8,false, "B ") );
            blackBishops.Add( new Pieces(6, 8, false, "B ") );
        }
    }
}