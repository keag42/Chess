using System.Runtime.CompilerServices;

namespace Chess {

    public class Pawn : Pieces{
        private (int x, int y) position = (0, 0);

        //starting position constructor
        public Pawn(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "P");
            position = (xAxis, yAxis);
        }


        public static void Valid_Tiles(int xAxis, int yAxis, bool isWhite) {
            //left attack
            
           
           // if (leftAttack == "x" || leftAttack == "o") {
                
           // }
        }
        public static void PawnMove(int xAxis, int yAxis, bool isWhite) { //Still in progress
            //starting position
            byte pawnStartingPosition = isWhite ? (byte)2 : (byte)7;
            //first move? 
            bool isFirstMove = (pawnStartingPosition == yAxis);
            //left move validation
             String leftAttack = ChessBoard.getPosition(xAxis + 1, yAxis - 1);
             bool leftValid = !(leftAttack == "x " || leftAttack == "o ") && (xAxis != 1);
            //right move validation
             String rightAttack = ChessBoard.getPosition(xAxis - 1, yAxis - 1);
             bool rightValid = !(rightAttack == "x " || rightAttack == "o ") && (xAxis != 8);
            //forward 1 move validation
             String forwardMove = ChessBoard.getPosition(xAxis, yAxis - 1);
             bool frontValid = (forwardMove == "x " || forwardMove == "o ");
            //forward 2 move validation
            String forwardJump = ChessBoard.getPosition(xAxis, yAxis - 2);
            bool frontJumpValid = ((forwardJump == "x " || forwardJump == "o ") && isFirstMove);
             
            
             Console.WriteLine("where would you like to move this pawn? ex. e5, d3, a1");
             string tempMove = Console.ReadLine();
             var (xTemp, yTemp) = letterToXY(tempMove);
             
             //for now this wont include first move
             
             if (xTemp == xAxis + 1 && yTemp == yAxis - 1 && leftValid) { //Left attack
                 setPosition(xTemp, yTemp, "P");
             }
             else if (xTemp == xAxis - 1 && yTemp == yAxis - 1 && rightValid) { //left attack
                 setPosition(xTemp, yTemp, "P");
             }
             else if (xTemp == xAxis && yTemp == yAxis - 1 && frontValid) { //move 1 space forward
                 setPosition(xTemp, yTemp, "P");
             }
             
             
             replaceTile(xAxis, yAxis);
             PrintBoard();
        }

        public override string ToString() { //possibly remove this
            return "P";
        }

        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}