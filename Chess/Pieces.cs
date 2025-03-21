namespace Chess;
public class Pieces {
    private ChessBoard board;
    private (int x, int y) position;
    private String type;
    private string name;
    private bool sideWhite;
    private int moveCount;
    public Pieces(int xAxis, int yAxis, bool sideWhite, String type, string name, ChessBoard board) {
        //starting position constructor
        this.board = board;
        this.sideWhite = sideWhite;
        position = (xAxis, yAxis);
        this.type = type;
        this.name = name;
        board.setPosition(xAxis, yAxis, this);
    }
    public (int, int) GetPiecePosition() {
        return position;
    }
    public new String GetType() {
        return type;
    }
    public string GetName() {
        return name;
    }
    public bool GetColor() {
        return sideWhite;
    }
    public void MovePieceToNewPosition(int currentX, int currentY, int newX, int newY) {
        board.setPosition(newX, newY, this);
        board.replaceTile(currentX, currentY);
        position = (newX, newY);
    }
    public bool IsEmpty(int x, int y) {
        return board.getPosition(x, y) == "x " || board.getPosition(x, y) == "o ";
    }
    public bool IsEnemy(int x, int y) {
        return board.getPiecePositionValues(x, y).GetColor() != this.GetColor();
    }
    public bool IsValidMove(int x, int y) {
        if (IsEmpty(x, y)) {
            return true;
        }
        else {
            if (IsEnemy(x, y)) {
                return true;
            }
            else {
                Console.WriteLine("that is your piece.");
                return false;
            }
        }
    }
    public (int, int) GetPieceMove() {
        Console.WriteLine($"where would you like to move this {name}? ex. e5, d3, a1");
        string tempMove = Console.ReadLine();
        var (xTemp, yTemp) = board.letterToXY(tempMove);
        return (xTemp, yTemp); 
    }
    public override string ToString() { //possibly remove this
        return type + " ";
    }
    public bool IsCheck(int x, int y) {
        
        // HORSE CHECK
        if (board.getPiecePositionValues(x + 2, y + 1).GetType().Equals("H") && IsEnemy(x + 2, y + 1)) { return true; }      // x + 2, y + 1
        if (board.getPiecePositionValues(x + 2, y - 1).GetType().Equals("H") && IsEnemy(x + 2, y - 1)) {return true; } // x + 2, y - 1
        if (board.getPiecePositionValues(x - 2, y - 1).GetType().Equals("H") && IsEnemy(x - 2, y - 1)) {return true; } // x - 2, y - 1
        if (board.getPiecePositionValues(x - 1, y + 2).GetType().Equals("H") && IsEnemy(x - 1, y + 2)) {return true; } // x - 1, y + 2
        if (board.getPiecePositionValues(x + 1, y + 2).GetType().Equals("H") && IsEnemy(x + 1, y + 2)) {return true; } // x + 1, y + 2
        if (board.getPiecePositionValues(x - 1, y - 2).GetType().Equals("H") && IsEnemy(x - 1, y - 2)) {return true; } // x - 1, y - 2
        if (board.getPiecePositionValues(x + 1, y - 2).GetType().Equals("H") && IsEnemy(x + 1, y - 2)) {return true; } // x + 1, y - 2
        
        // Diagonals
            // right-up
        for(int i = 1; i <= 8; i++) {
            if(!board.isInBounds(x + i, y + i)) {break;}
            string diagonalPiece = board.getPiecePositionValues(x + i, y + i).GetType();
            if(IsEmpty(x + i, y + i)) {continue;}
            if (!IsEnemy(x + i, y + i)) { break;}
            if( diagonalPiece == "Q" || diagonalPiece == "B" ) { return true; }
        }
            // left-down
        for(int i = 1; i <= 8; i++) {
            if(!board.isInBounds(x - i, y - i)) {break;}
            string diagonalPiece = board.getPiecePositionValues(x - i, y - i).GetType();
            if ( IsEmpty(x - i, y - i) ) {continue;}
            if (!IsEnemy(x - i, y - i)) { break;}
            if ( diagonalPiece == "Q" || diagonalPiece == "B")  { return true; }
        }
            // left-up
        for(int i = 1; i <= 8; i++) {
            if(!board.isInBounds(x - i, y + i)) {break;}
            string diagonalPiece = board.getPiecePositionValues(x - i, y + i).GetType();
            if ( IsEmpty(x - i, y + i) ) {continue;}
            if ( !IsEnemy(x - i, y + i) ) { break;}
            if ( diagonalPiece == "Q" || diagonalPiece == "B")  { return true; }
        }
            // right-down
        for(int i = 1; i <= 8; i++) {
            if(!board.isInBounds(x + i, y - i)) {break;}
            string diagonalPiece = board.getPiecePositionValues(x + i, y - i).GetType();
            if ( IsEmpty(x + i, y - i) ) {continue;}
            if ( !IsEnemy(x + i, y - i) ) { break;}
            if ( diagonalPiece == "Q" || diagonalPiece == "B")  { return true; }
        }
        
        // horizontal or verticle
            //up
        for(int i = 1; i <= 8; i++) {
            if(!board.isInBounds(x, y + i)) {break;}
            string diagonalPiece = board.getPiecePositionValues(x, y + i).GetType();
            if(IsEmpty(x, y + i)) {continue;}
            if (!IsEnemy(x, y + i)) { break;}
            if( diagonalPiece == "Q" || diagonalPiece == "R" ) { return true; }
        }
            //down
        for(int i = 1; i <= 8; i++) {
            string diagonalPiece = board.getPiecePositionValues(x, y - i).GetType();
            if(!board.isInBounds(x, y - i)) {break;}
            if(IsEmpty(x, y - i)) {continue;}
            if (!IsEnemy(x, y - i)) { break;}
            if( diagonalPiece == "Q" || diagonalPiece == "R" ) { return true; }
        }
            // left
        for(int i = 1; i <= 8; i++) {
            if(!board.isInBounds(x - i, y)) {break;}
            string diagonalPiece = board.getPiecePositionValues(x - i, y).GetType();
            if(IsEmpty(x - i, y)) {continue;}
            if (!IsEnemy(x - i, y)) { break;}
            if( diagonalPiece == "Q" || diagonalPiece == "R" ) { return true; }
        }
            //Right
        for(int i = 1; i <= 8; i++) {
                if(!board.isInBounds(x + i, y)) {break;}
                
                string diagonalPiece = board.getPiecePositionValues(x + i, y).GetType();
                if(IsEmpty(x + i, y)) {continue;}
                if (!IsEnemy(x + i, y)) { break;}
                if( diagonalPiece == "Q" || diagonalPiece == "R" ) { return true; }
            }

        return false;
    }
    public void PawnMove() { 
        (int xAxis, int yAxis) = GetPiecePosition();
        int yDir = sideWhite ? +1 : -1;
        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            if ((xTemp == xAxis + 1 && yTemp == yAxis + yDir) && IsEnemy(xTemp, yTemp)) { //Left attack
                MovePieceToNewPosition(xAxis, yAxis, xTemp, yTemp);
                moveCount++; 
            }
            else if (xTemp == xAxis - 1 && yTemp == yAxis + yDir && IsEnemy(xTemp, yTemp)) { //right attack
                MovePieceToNewPosition(xAxis, yAxis, xTemp, yTemp);
                moveCount++;
            }
            else if ((xTemp == xAxis && yTemp == yDir + yAxis) && IsEmpty(xTemp, yTemp)) {//move 1 space forward
                MovePieceToNewPosition(xAxis, yAxis, xTemp, yTemp);
                moveCount++;
            }
            else if (xTemp == xAxis && yTemp ==  yAxis + (2*yDir) && moveCount == 0 && IsEmpty(xTemp, yTemp) && IsEmpty(xTemp, yAxis + (1*yDir)))  {//move 2 space forward
                MovePieceToNewPosition(xAxis, yAxis, xTemp, yTemp);
                moveCount++;
            }
            else{
                Console.WriteLine("you cannot move there. try again.");
                continue;
            }
            break;
        }
    }
    public void HorseMove() {
        (int x, int y) = GetPiecePosition();
        int moveX, moveY;
        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            //Checks validity of move
            if ( !((xTemp == x - 1 && yTemp == y + 2) || 
                   (xTemp == x + 1 && yTemp == y + 2) ||
                   //move2
                   (xTemp == x + 1 && yTemp == y - 2) ||
                   (xTemp == x - 1 && yTemp == y - 2) ||
                   //move3
                   (xTemp == x + 2 && yTemp == y - 1) ||
                   (xTemp == x + 2 && yTemp == y + 1) ||
                   //move4
                   (xTemp == x - 2 && yTemp == y - 1) ||
                   (xTemp == x - 2 && yTemp == y + 1))) 
                {
                    Console.WriteLine("that is not a valid Horse move. where would you like to move?");
                    continue;
                }
            if (IsEmpty(xTemp, yTemp)) {
                moveX = xTemp;
                moveY = yTemp;
                break;
            }
            else {
                if (IsEnemy(xTemp, yTemp)) {
                    string tempName = board.getPiecePositionValues(xTemp, yTemp).GetName();
                    Console.WriteLine($" takes {tempName}");
                    moveX = xTemp;
                    moveY = yTemp;
                    break; 
                }
                else {
                    Console.WriteLine("that's your piece you cant move there. try again.");
                }
            }
        }//end of while loop
        MovePieceToNewPosition(x, y, moveX, moveY);
    }
    public void BishopMove() {
        (int x, int y) = GetPiecePosition();
        (int xMove, int yMove) finalMove;
        //int xDir, yDir;
        
        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            
            if (!IsValidMove(xTemp, yTemp)) 
                continue;
            
            int yDir = yTemp > y? +1 : -1;
            int xDir = xTemp > x? +1 : -1;
            bool isTempValid = true;
            int checkCount = 1;
            
            while(xTemp != x + (checkCount*xDir) && yTemp != y + (checkCount*yDir)) {
                if (!IsEmpty(x + (checkCount*xDir), y + (checkCount*yDir))) {
                    isTempValid = false;
                    break;
                }
                checkCount++;
            }

            if (isTempValid) {
                finalMove = (xTemp, yTemp);
                break;
            }
        }
        MovePieceToNewPosition(x, y, finalMove.xMove, finalMove.yMove);
    }
    public void RookMove() {
        (int x, int y) = GetPiecePosition();
        (int xMove, int yMove) finalMove = (0, 0);

        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            
            //checks if this the move is on the same x or y axis as rook.
            bool onXorY = (xTemp == x && yTemp != y) || (xTemp != x && yTemp == y);
            
            //check if that space is empty or a enemy
            if (!IsValidMove(xTemp, yTemp) || !onXorY) {
                continue;
            }
            
            //whether the move is up or down
            bool isVertical = (xTemp == x && yTemp != y);
            bool piecesInWay = false;
            int moveDirection = isVertical ? (yTemp > y? +1 : -1) : (xTemp > x? +1 : -1) ;
            int tempMoveCount = 1;
            
            if ( isVertical )  { //moving vertically
                while (y + (tempMoveCount * moveDirection) != yTemp) { //while the check is not equal too the move
                    if (!IsEmpty(x, y + tempMoveCount * moveDirection)) {
                        Console.WriteLine("piece in way");
                        piecesInWay = true;
                        break;
                    }
                    tempMoveCount++;
                }
            }
            else if (!isVertical) { // Horizontal movement
                while (x + tempMoveCount * moveDirection != xTemp) { //while the check is not equal too the move
                    if (!IsEmpty(x + tempMoveCount * moveDirection, y)) {
                        Console.WriteLine("piece in way");
                        piecesInWay = true;
                        break;
                    }
                    tempMoveCount++;
                }
                Console.WriteLine("end of inner loop");
            }
           
            if (piecesInWay) 
                continue;
            
            finalMove.xMove = xTemp;
            finalMove.yMove = yTemp;
            break;
        }// end of while statement
        MovePieceToNewPosition(x, y, finalMove.xMove, finalMove.yMove);
    }  //   not allowing me to move anywhere
    public void KingMove() {
        (int x, int y) = GetPiecePosition();
        (int xMove, int yMove) finalMove;

        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            bool isValidKingMove = (xTemp >= x - 1 && xTemp <= x + 1 && yTemp >= y - 1 && yTemp <= y + 1);

            if (isValidKingMove) { //valid king move
                if (IsEmpty(xTemp, yTemp)) { //no piece there
                    finalMove = (xTemp, yTemp);
                    break;
                }
                else if (IsEnemy(xTemp, yTemp)) {
                    finalMove = (xTemp, yTemp);
                    break;
                }
                else {
                    Console.WriteLine("that is your own piece, you cant move there. try again!");
                }
            }
        }
        MovePieceToNewPosition(x, y, finalMove.xMove, finalMove.yMove);
    }
    public void QueenMove() {
        (int x, int y) = GetPiecePosition();
        (int xMove, int yMove) finalMove = (0, 0);
        
        while (true) {
            var (xTemp, yTemp) = GetPieceMove();

            if (!IsValidMove(xTemp, yTemp)){ continue; }
            
            bool isXY = (x == xTemp && y != yTemp)|| (x != xTemp && y == yTemp);
            
            // h/v unfinished
            if (isXY) { // horizontal or vertical
                bool onXorY = (xTemp == x && yTemp != y) || (xTemp != x && yTemp == y);
            
                //check if that space is empty or a enemy
                if (!IsValidMove(xTemp, yTemp) || !onXorY) {
                    continue;
                }
            
                //whether the move is up or down
                bool isVertical = (xTemp == x && yTemp != y);
                bool piecesInWay = false;
                int moveDirection = isVertical ? (yTemp > y? +1 : -1) : (xTemp > x? +1 : -1) ;
                int tempMoveCount = 1;
            
                if ( isVertical )  { //moving vertically
                    while (y + (tempMoveCount * moveDirection) != yTemp) { //while the check is not equal too the move
                        if (!IsEmpty(x, y + tempMoveCount * moveDirection)) {
                            Console.WriteLine("piece in way");
                            piecesInWay = true;
                            break;
                        }
                        tempMoveCount++;
                    }
                }
                else if (!isVertical) { // Horizontal movement
                    while (x + tempMoveCount * moveDirection != xTemp) { //while the check is not equal too the move
                        if (!IsEmpty(x + tempMoveCount * moveDirection, y)) {
                            Console.WriteLine("piece in way");
                            piecesInWay = true;
                            break;
                        }
                        tempMoveCount++;
                    }
                    Console.WriteLine("end of inner loop");
                }
           
                if (piecesInWay) 
                    continue;
            
                finalMove.xMove = xTemp;
                finalMove.yMove = yTemp;
                break;
                
            } // horizontal or vertical end

            else {
                //DIAGONAL DIAGONAL DIAGONAL
                int yDir = yTemp > y ? +1 : -1;
                int xDir = xTemp > x ? +1 : -1;
                bool isTempValid = true;
                int checkCount = 1;

                while (xTemp != x + (checkCount * xDir) && yTemp != y + (checkCount * yDir)) {
                    if (!IsEmpty(x + (checkCount * xDir), y + (checkCount * yDir))) {
                        isTempValid = false;
                        break;
                    }

                    checkCount++;
                }

                if (isTempValid) {
                    finalMove = (xTemp, yTemp);
                    break;
                } 
            } //end of DIAGONAL DIAGONAL DIAGONAL 
        }//end of while loop
        MovePieceToNewPosition(x, y, finalMove.xMove, finalMove.yMove);
    } 
}
