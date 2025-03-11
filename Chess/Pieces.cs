namespace Chess {

    public class Pieces : ChessBoard{
        //pawns
        static List<Pawn> whitePawns = new List<Pawn>();
        static List<Pawn> blackPawns = new List<Pawn>();
        //rooks
        static List<Rook> whiteRooks = new List<Rook>();
        static List<Rook> blackRooks = new List<Rook>();
        //Bishops
        static List<Bishop> whiteBishops = new List<Bishop>();
        static List<Bishop> blackBishops = new List<Bishop>();
        //Horse
        static List<Horse> whiteHorses = new List<Horse>();
        static List<Horse> blackHorses = new List<Horse>();
      
        public static void setPawnStartingPosition() {
            for (int i = 1; i <= 8; i++) {
                Pawn tempW = new Pawn(i, 2);
                whitePawns.Add(tempW);
                
                Pawn tempB = new Pawn(i, 7);
                blackPawns.Add(tempB);
            }
        }

        public static void setRookStartingPosition() { 
            whiteRooks.Add( new Rook(1, 1) );
            whiteRooks.Add( new Rook(8, 1) );
            blackRooks.Add( new Rook(1, 8) );
            blackRooks.Add( new Rook(8, 8) );
        }
        public static void setHorseStartingPosition() { 
            whiteHorses.Add( new Horse(2, 1) );
            whiteHorses.Add( new Horse(7, 1) );
            blackHorses.Add( new Horse(2, 8) );
            blackHorses.Add( new Horse(7, 8) );
        }
        public static void setBishipStartingPosition() {
            whiteBishops.Add( new Bishop(3, 1) );
            whiteBishops.Add( new Bishop(6, 1) );
            blackBishops.Add( new Bishop(3, 8) );
            blackBishops.Add( new Bishop(6, 8) );
        }
        
        public static void setQueenStartingPosition() {
             Queen whiteQueen = new Queen(4, 1); 
             Queen BlackQueen = new Queen(5,8 );
        }
        
        public static void setKingStartingPosition() {
             King whiteKing = new King(5, 1);
             King BlackKing = new King(4,8); 
        }
    }
}