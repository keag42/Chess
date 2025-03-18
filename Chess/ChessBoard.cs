using System;
using System.Collections.Generic;
using System.Linq; // Required for .Cast<object>()

namespace Chess {
    public class ChessBoard {
        public int roundCount = -32; //starts at 32 because when i create each piece it updates and i only want it to start counting once each piece is made

        public List<List<object>> board2D = new List<List<object>>() {
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
        private List<Pieces> whitePawns;
        private List<Pieces> blackPawns;
        private List<Pieces> whiteRooks;
        private List<Pieces> blackRooks;
        private List<Pieces> whiteBishops;
        private List<Pieces> blackBishops;
        private List<Pieces> whiteHorses;
        private List<Pieces> blackHorses;
        private Pieces whiteQueen;
        private Pieces blackQueen;
        private Pieces whiteKing;
        private Pieces blackKing;

        public ChessBoard() {
            whitePawns = new List<Pieces>();
            blackPawns = new List<Pieces>();
            whiteRooks = new List<Pieces>();
            blackRooks = new List<Pieces>();
            whiteBishops = new List<Pieces>();
            blackBishops = new List<Pieces>();
            whiteHorses = new List<Pieces>();
            blackHorses = new List<Pieces>();

            whiteQueen = new Pieces(4, 1, true, "Q", "Queen", this);
            blackQueen = new Pieces(5, 8, false, "Q", "Queen", this);
            whiteKing = new Pieces(5, 1, true, "K", "King", this);
            blackKing = new Pieces(4, 8, false, "K", "King", this);

            SetStartingPositions();
        }

        public void setPosition(int xAxis, int yAxis, object piece) {
            board2D[yAxis][xAxis] = piece;
            roundCount++; //update round counter
        }
        public String getPosition(int xAxis, int yAxis) {
            return board2D[yAxis][xAxis]?.ToString() ?? "Empty"; // Return "Empty" if the position is null
        }
        public bool isInBounds(int x, int y) {
            bool validX = x >= 1 && x <= 8;
            bool validY = y >= 1 && y <= 8;
            return validX && validY;
        }
        public (int, int) letterToXY(string move) {
            int x = move[0] - 'a' + 1;
            int y = int.Parse(move[1].ToString());
            return (x, y);
        }
        public void replaceTile(int xAxis, int yAxis) {
            board2D[yAxis][xAxis] = yAxis % 2 == 0 ? (xAxis % 2 == 0 ? "x " : "o ") : (xAxis % 2 == 0 ? "o " : "x ");
        } //possibly move this into the setPosition. than refactor the code
        public void PrintBoard() {
            int rowIndex = 0;
            Console.WriteLine("         Round: " + roundCount + "\n"); //round title
            foreach (var row in board2D) {
                string result = string.Join(" ", row);
                Console.WriteLine(result);
                if (rowIndex == 0) {
                    Console.WriteLine("    _  _  _  _  _  _  _  _ ");
                }

                rowIndex++;
            }
        }
        private void SetStartingPositions() {
            // Set pawns
            for (int i = 1; i <= 8; i++) {
                whitePawns.Add(new Pieces(i, 2, true, "P", "Pawn", this));
                blackPawns.Add(new Pieces(i, 7, false, "P", "Pawn", this));
            }

            // Set rooks
            whiteRooks.Add(new Pieces(1, 1, true, "R", "Rook", this));
            whiteRooks.Add(new Pieces(8, 1, true, "R", "Rook", this));
            blackRooks.Add(new Pieces(1, 8, false, "R", "Rook", this));
            blackRooks.Add(new Pieces(8, 8, false, "R", "Rook", this));

            // Set horses
            whiteHorses.Add(new Pieces(2, 1, true, "H", "Horse", this));
            whiteHorses.Add(new Pieces(7, 1, true, "H", "Horse", this));
            blackHorses.Add(new Pieces(2, 8, false, "H", "Horse", this));
            blackHorses.Add(new Pieces(7, 8, false, "H", "Horse", this));

            // Set bishops
            whiteBishops.Add(new Pieces(3, 1, true, "B", "Bishop", this));
            whiteBishops.Add(new Pieces(6, 1, true, "B", "Bishop", this));
            blackBishops.Add(new Pieces(3, 8, false, "B", "Bishop", this));
            blackBishops.Add(new Pieces(6, 8, false, "B", "Bishop", this));

        }
        public Pieces getPiecePositionValues(int xAxis, int yAxis) {
                if (board2D[yAxis][xAxis] is Pieces piece) {
                    return piece; // Return the piece if it's a valid object
                }

                //Debugging
                if (board2D[yAxis][xAxis] is Pieces temp) {
                    // Now you can safely work with temp, which is of type Pieces
                    Console.WriteLine("Found a piece at this position: " + temp);
                    Console.WriteLine(temp.GetName());
                }
                else {
                    Console.WriteLine("No piece at this position.");
                }

                return null; // Return null if there's no valid piece at this position
            }
    }
}