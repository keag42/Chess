using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; // Required for .Cast<object>()

namespace Chess;
public class ChessBoard {
    public int roundCount = -32; //starts at 32 because when i create each piece it updates and i only want it to start counting once each piece is made
    Dictionary<string, int> whitePiecesAlive = new Dictionary<string, int>() {
        {"Pawn", 8},
        {"Rook", 2},
        {"Bishop", 2},
        {"Horse", 2},
        {"Queen", 1},
        {"King", 1}
    };
    Dictionary<string, int> blackPiecesAlive = new Dictionary<string, int>() {
        {"Pawn", 8},
        {"Rook", 2},
        {"Bishop", 2},
        {"Horse", 2},
        {"Queen", 1},
        {"King", 1}
    };
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
    public List<Pieces> whitePawns;
    public List<Pieces> blackPawns;
    public List<Pieces> whiteRooks;
    public List<Pieces> blackRooks;
    public List<Pieces> whiteBishops;
    public List<Pieces> blackBishops;
    public List<Pieces> whiteHorses;
    public List<Pieces> blackHorses;
    public Pieces whiteQueen;
    public Pieces blackQueen;
    public Pieces whiteKing;
    public Pieces blackKing;

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
        int x;
        int y;
        
        while (true) {
            if (move.Length == 2 && Regex.IsMatch(move[0].ToString(), @"^[a-hA-H]$") && (move[1] > '0' && move[1] <= '8')) {
                x = move[0] - 'a' + 1;
                y = int.Parse(move[1].ToString());
                break;
            }
            else {
                Console.WriteLine("not on board or, incorrect format. try agiain");
                move = Console.ReadLine();
            }
        }
        
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
        Console.WriteLine("^^   _  white side  _   ^^");
        
        Console.WriteLine("    _  _  _  _  _  _  _  _ ");
        Console.WriteLine($"white, pawn's: {whitePiecesAlive["Pawn"]}, Rook's {whitePiecesAlive["Rook"]}, Bishops's {whitePiecesAlive["Bishop"]}, Horse's {whitePiecesAlive["Horse"]}, Queen {whitePiecesAlive["Queen"]}, King {whitePiecesAlive["King"]}");
        Console.WriteLine($"white, pawn's: {blackPiecesAlive["Pawn"]}, Rook's {blackPiecesAlive["Rook"]}, Bishops's {blackPiecesAlive["Bishop"]}, Horse's {blackPiecesAlive["Horse"]}, Queen {blackPiecesAlive["Queen"]}, King {blackPiecesAlive["King"]}");
        Console.WriteLine("    _  _  _  _  _  _  _  _ ");
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

    public void KillPiece(int x, int y) {
        Pieces temp = getPiecePositionValues(x, y);
        temp.PieceTaken();
        
        bool sideWhite = temp.GetColor();
        switch (temp.GetType()) {
            case "P": //pawn
                if (sideWhite) {
                    whitePiecesAlive["Pawn"]--;
                }
                else {
                    blackPiecesAlive["Pawn"]--;
                }
                break;
            case "B":
                if (sideWhite) {
                    whitePiecesAlive["Bishop"]--;
                }
                else {
                    blackPiecesAlive["Bishop"]--;
                }
                break;
            case "R":
                if (sideWhite) {
                    whitePiecesAlive["Rook"]--;
                }
                else {
                    blackPiecesAlive["Rook"]--;
                }
                break;
            case "H":
                if (sideWhite) {
                    whitePiecesAlive["Horse"]--;
                }
                else {
                    blackPiecesAlive["Horse"]--;
                }
                break;
            case "Q":
                if (sideWhite) {
                    whitePiecesAlive["Queen"]--;
                }
                else {
                    blackPiecesAlive["Queen"]--;
                }
                break;
            case "K":
                if (sideWhite) {
                    whitePiecesAlive["King"]--;
                }
                else {
                    blackPiecesAlive["King"]--;
                }

                Console.WriteLine("if your seeing this you've lost your king when it should have been checkmate so somethings wrong..");
                break;
            default:
                Console.WriteLine("something is really wrong if your seeing this, \n this means that somehow the Type value of your piece is not a kind that i allowed.");
                break;
        }
    }
}