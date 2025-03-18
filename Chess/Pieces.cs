using System.Runtime.CompilerServices;
namespace Chess;
public class Pieces {
    private ChessBoard board;
    private (int x, int y) position = (0, 0);
    private String type;
    private string name;
    private bool sideWhite;
    private int moveCount = 0;

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
    public string GetType() {
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
    public bool isEmpty(int x, int y) {
        return board.getPosition(x, y) == "x " || board.getPosition(x, y) == "o ";
    }
    public bool isEnemy(int x, int y) {
        return board.getPiecePositionValues(x, y).GetColor() != this.GetColor();
    }
    public bool isValidMove(int x, int y) {
        if (isEmpty(x, y)) {
            return true;
        }
        else {
            if (isEnemy(x, y)) {
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
    public void PawnMove() { 
        (int xAxis, int yAxis) = GetPiecePosition();
        int yDir = sideWhite ? +1 : -1;
        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            if ((xTemp == xAxis + 1 && yTemp == yAxis + yDir) && isEnemy(xTemp, yTemp)) { //Left attack
                MovePieceToNewPosition(xAxis, yAxis, xTemp, yTemp);
                moveCount++; 
            }
            else if (xTemp == xAxis - 1 && yTemp == yAxis + yDir && isEnemy(xTemp, yTemp)) { //right attack
                MovePieceToNewPosition(xAxis, yAxis, xTemp, yTemp);
                moveCount++;
            }
            else if ((xTemp == xAxis && yTemp == yDir + yAxis) && isEmpty(xTemp, yTemp)) {//move 1 space forward
                MovePieceToNewPosition(xAxis, yAxis, xTemp, yTemp);
                moveCount++;
            }
            else if (xTemp == xAxis && yTemp ==  yAxis + (2*yDir) && moveCount == 0 && isEmpty(xTemp, yTemp) && isEmpty(xTemp, yAxis + (1*yDir)))  {//move 2 space forward
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
            if (isEmpty(xTemp, yTemp)) {
                moveX = xTemp;
                moveY = yTemp;
                break;
                }
            else {
                if (isEnemy(xTemp, yTemp)) {
                    string tempName = board.getPiecePositionValues(xTemp, yTemp).GetName();
                    Console.WriteLine($" takes {tempName}");
                    moveX = xTemp;
                    moveY = yTemp;
                    break;
                }
                else {
                    Console.WriteLine("that's your piece you cant move there. try again.");
                    continue;
                }
            }
        }//end of while loop
        MovePieceToNewPosition(x, y, moveX, moveY);
    }
    public void BishopMove() {
        (int x, int y) = GetPiecePosition();
        (int xMove, int yMove) finalMove = (0, 0);
        //int xDir, yDir;
        
        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            
            if (!isValidMove(xTemp, yTemp)) 
                continue;
            
            int yDir = yTemp > y? +1 : -1;
            int xDir = xTemp > x? +1 : -1;
            bool isTempValid = true;
            int checkCount = 1;
            
            while(xTemp != x + (checkCount*xDir) && yTemp != y + (checkCount*yDir)) {
                if (!isEmpty(x + (checkCount*xDir), y + (checkCount*yDir))) {
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
            if (!isValidMove(xTemp, yTemp) || !onXorY) {
                continue;
            }
            
            //whether the move is up or down
            bool isVerticle = (xTemp == x && yTemp != y);
            bool piecesInWay = false;
            int moveDirection = isVerticle ? (yTemp > y? +1 : -1) : (xTemp > x? +1 : -1) ;
            int moveCount = 1;
            
            if ( isVerticle )  { //moving vertically
                while (y + (moveCount * moveDirection) != yTemp) { //while the check is not equal too the move
                    if (!isEmpty(x, y + moveCount * moveDirection)) {
                        Console.WriteLine("piece in way");
                        piecesInWay = true;
                        break;
                    }
                    moveCount++;
                }
            }
            else if (!isVerticle) { // Horizontal movement
                while (x + moveCount * moveDirection != xTemp) { //while the check is not equal too the move
                    if (!isEmpty(x + moveCount * moveDirection, y)) {
                        Console.WriteLine("piece in way");
                        piecesInWay = true;
                        break;
                    }
                    moveCount++;
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
        (int xMove, int yMove) finalMove = (0, 0);

        while (true) {
            var (xTemp, yTemp) = GetPieceMove();
            bool isValidKingMove = (xTemp >= x - 1 && xTemp <= x + 1 && yTemp >= y - 1 && yTemp <= y + 1);

            if (isValidKingMove) { //valid king move
                if (isEmpty(xTemp, yTemp)) { //no piece there
                    finalMove = (xTemp, yTemp);
                    break;
                }
                else if (isEnemy(xTemp, yTemp)) {
                    finalMove = (xTemp, yTemp);
                    break;
                }
                else {
                    Console.WriteLine("that is your own piece, you cant move there. try again!");
                    continue;
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

            if (!isValidMove(xTemp, yTemp)){ continue; }
            
            bool isXY = (x == xTemp && y != yTemp)|| (x != xTemp && y == yTemp);
            
            // h/v unfinished
            if (isXY) { // horizontal or verticle
                bool onXorY = (xTemp == x && yTemp != y) || (xTemp != x && yTemp == y);
            
                //check if that space is empty or a enemy
                if (!isValidMove(xTemp, yTemp) || !onXorY) {
                    continue;
                }
            
                //whether the move is up or down
                bool isVerticle = (xTemp == x && yTemp != y);
                bool piecesInWay = false;
                int moveDirection = isVerticle ? (yTemp > y? +1 : -1) : (xTemp > x? +1 : -1) ;
                int moveCount = 1;
            
                if ( isVerticle )  { //moving vertically
                    while (y + (moveCount * moveDirection) != yTemp) { //while the check is not equal too the move
                        if (!isEmpty(x, y + moveCount * moveDirection)) {
                            Console.WriteLine("piece in way");
                            piecesInWay = true;
                            break;
                        }
                        moveCount++;
                    }
                }
                else if (!isVerticle) { // Horizontal movement
                    while (x + moveCount * moveDirection != xTemp) { //while the check is not equal too the move
                        if (!isEmpty(x + moveCount * moveDirection, y)) {
                            Console.WriteLine("piece in way");
                            piecesInWay = true;
                            break;
                        }
                        moveCount++;
                    }
                    Console.WriteLine("end of inner loop");
                }
           
                if (piecesInWay) 
                    continue;
            
                finalMove.xMove = xTemp;
                finalMove.yMove = yTemp;
                break;
                
            } // horizontal or verticle end

            else {
                //DIAGONAL DIAGONAL DIAGONAL
                int yDir = yTemp > y ? +1 : -1;
                int xDir = xTemp > x ? +1 : -1;
                bool isTempValid = true;
                int checkCount = 1;

                while (xTemp != x + (checkCount * xDir) && yTemp != y + (checkCount * yDir)) {
                    if (!isEmpty(x + (checkCount * xDir), y + (checkCount * yDir))) {
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
