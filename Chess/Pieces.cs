using System.Runtime.CompilerServices;

namespace Chess {

    public class Pieces : ChessBoard {
        private (int x, int y) position = (0, 0);
        private String type;
        private string name;
        private bool sideWhite;

        public Pieces(int xAxis, int yAxis, bool sideWhite, String type, string name) {
            //starting position constructor
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
        public bool isEmpty(int x, int y) {
            return getPosition(x, y) == "x " || getPosition(x, y) == "o ";
        }

        public bool isEnemy(int x, int y) {
            return getPiecePositionValues(x, y).GetColor() != this.GetColor();
        }

         public (int, int) GetPieceMove() {
            Console.WriteLine($"where would you like to move this {name}? ex. e5, d3, a1");
            string tempMove = Console.ReadLine();
            var (xTemp, yTemp) = letterToXY(tempMove);
            return (xTemp, yTemp);
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
            (int x, int y) = GetPiecePosition();
            int moveX, moveY;
            while (true) {
                Console.WriteLine("where would you like to move this horse? ex. e5, d3, a1");
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
                if (isEmpty(xTemp, yTemp)) {
                    moveX = xTemp;
                    moveY = yTemp;
                    break;
                    }
                else {
                    if (isEnemy(xTemp, yTemp)) {
                        string tempName = getPiecePositionValues(xTemp, yTemp).GetName();
                        Console.WriteLine($"{tempMove} takes {tempName}");
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
            setPosition(moveX, moveY, this);
        }
        public void BishopMove() {
            (int x, int y) = GetPiecePosition();
            (int xMove, int yMove) finalMove = (0, 0);
            int xDir, yDir;
            
            while (true) {
                var (xTemp, yTemp) = GetPieceMove();
                if (xTemp == x && yTemp == y) {
                    Console.WriteLine("you are already there try again.");
                    continue;
                }//if its the same tile your on try again
                yDir = yTemp > y? +1 : -1;
                xDir = xTemp > x? +1 : -1;
                bool isTempValid = true;
                for (int i = 1; i <= 8; i++) {
                    int xCheck = x + (i*xDir), yCheck = y + (i*yDir);
                    if (xCheck == xTemp && yCheck == yTemp) {//if youve reached destination
                        break;
                        }
                    else if (!isEmpty(xCheck, yCheck)) {
                        isTempValid = false;
                        break;
                        }
                } //checks pathway to destination
                if (!isTempValid) {
                    Console.WriteLine("there is a piece in the way, choose a different move.");
                    continue;
                } // if theres a piece in the way ask again
                else {
                    if (isEmpty(xTemp, yTemp)) {
                        finalMove = (xTemp, yTemp);
                    }
                    else if (isEnemy(xTemp, yTemp)) {
                        finalMove = (xTemp, yTemp);
                    } // if it is the opposite team
                    else {
                        Console.WriteLine("that is your own piece you cannot move there.");
                        continue;
                    }
                }//end of validity check
            } // move validation
            setPosition(finalMove.xMove, finalMove.yMove, this);
        } // final bishop structure for now
        
        //public static void QueenMove() {}
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
            setPosition(finalMove.xMove, finalMove.yMove, this);
        }
        
    }
}