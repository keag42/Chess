using System.Runtime.CompilerServices;

namespace Chess {

    public class Pieces : ChessBoard{
        private (int x, int y) position = (0, 0);
        private String type;
        private string name;
        private bool sideWhite;
        public Pieces(int xAxis, int yAxis, bool sideWhite, String type, string name) { //starting position constructor
            setPosition(xAxis, yAxis, type);
            this.sideWhite = sideWhite;
            position = (xAxis, yAxis);
            this.type = type;
            this.name = name;
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
        public override string ToString() { //possibly remove this
            return type + " ";
        }
        public static void PawnMove(int xAxis, int yAxis, bool isWhite) { 
            //starting position
            byte pawnStartingPosition = isWhite ? (byte)2 : (byte)7;
            //first move? 
            bool isFirstMove = (pawnStartingPosition == yAxis);
            
            //left move validation
             String leftAttack = getPosition(xAxis + 1, yAxis - 1);
             bool leftValid = !(leftAttack == "x " || leftAttack == "o ") && (xAxis != 1);
             
            //right move validation
             String rightAttack = getPosition(xAxis - 1, yAxis - 1);
             bool rightValid = !(rightAttack == "x " || rightAttack == "o ") && (xAxis != 8);
             
            //forward 1 move validation
             int frontMoveDirectionOne = isWhite ? 1 : -1; //not workin properly
             //need to make list into object to pass color
             String forwardMove = getPosition(xAxis, yAxis + frontMoveDirectionOne);
             bool frontValid = (forwardMove == "x " || forwardMove == "o ");
             
            //forward 2 move validation
            String forwardJump = getPosition(xAxis, yAxis - 2);
            bool frontJumpValid = ((forwardJump == "x " || forwardJump == "o ") && isFirstMove);

            string tempMove;
            while (true) {
                Console.WriteLine("where would you like to move this pawn? ex. e5, d3, a1");
                tempMove = Console.ReadLine();
                var (xTemp, yTemp) = letterToXY(tempMove);
                
                //for now this wont include first move
                if (xTemp == xAxis + 1 && yTemp == yAxis - 1 && leftValid) { //Left attack
                    setPosition(xTemp, yTemp, "P");
                    }
                else if (xTemp == xAxis - 1 && yTemp == yAxis - 1 && rightValid) { //right attack
                    setPosition(xTemp, yTemp, "P");
                    }
                else if (xTemp == xAxis && yTemp == yAxis + frontMoveDirectionOne && frontValid) {//move 1 space forward
                    setPosition(xTemp, yTemp, "P "); // need to make this not static and redo
                    }
                else {
                    Console.WriteLine("you cannot move there. try again.");
                    continue;
                }
                break;
            }
            
                
            replaceTile(xAxis, yAxis);
            PrintBoard();
        }//still in progress?
        public void HorseMove() {
            (int x, int y) = this.GetPiecePosition();
            int moveX;
            int moveY;
            bool isValid;
            while (true) {
                Console.WriteLine("where would you like to move this pawn? ex. e5, d3, a1");
                string tempMove = Console.ReadLine();
                var (xTemp, yTemp) = letterToXY(tempMove);
                
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
                if (getPosition(xTemp, yTemp) == "x " || getPosition(xTemp, yTemp) == "o ") {
                    moveX = xTemp;
                    moveY = yTemp;
                    break;
                    }
                else {
                    bool tileMovingToo = getPiecePositionValues(xTemp, yTemp).GetColor();
                    bool currentTile = this.GetColor();
                    if (tileMovingToo == currentTile) {
                        Console.WriteLine("that's your piece you cant move there. try again.");
                        continue;
                    }
                    else {
                        string tempName = getPiecePositionValues(xTemp, yTemp).GetName();
                        Console.WriteLine($"{tempMove} takes {tempName}");
                        moveX = xTemp;
                        moveY = yTemp;
                        break;
                    }
                }
            }//end of while loop
            setPosition(moveX, moveY, this);
        }
        
        //public static void BishopMove() {}
        //public static void QueenMove() {}
        //public static void KingMove() {}
        
    }
}