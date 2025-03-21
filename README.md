PIECES OBJECT

attributes:
   - ChessBoard 'board'
    -> holds instance of chess board object
        
  - (int x, int y) 'position' h
    -> olds position of the piece
    
  - String 'type'
    -> holds the capitol first letter of piece. ie( P, B, R )
    
  - string 'name'
    -> holds full name of piece. ie( pawn, rook )
    
  - bool 'sideWhite'
    -> holds true if piece is white
    
  - bool 'isAlive' = true
    -> holds true until you lose the piece
    
  - int 'moveCount' = 0
    -> holds if you've moved the piece yet for

Constructors:
  - Pieces( int x, int y, bool sideWhite, String type, string name, ChessBoard board )
    >  intializes all possible useful values
  
GET Methods:
  - (int x, int y) 'GetPiecePosition'
    -> gets x and y position of current piece
    
  - String 'GetType'
    -> returns the type
    
  - string 'GetName'
    -> returns the name
    
  - bool 'GetColor'
    -> returns color of piece
    
  - int 'GetMoveCount'
    -> returns number of time's the piece has moved.    
