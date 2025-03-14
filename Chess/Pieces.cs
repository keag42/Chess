namespace Chess {

    public class Pieces : ChessBoard{
        private (int x, int y) position = (0, 0);
        private String type;
        private bool sideWhite;
        public Pieces(int xAxis, int yAxis, bool sideWhite, String type) { //starting position constructor
            setPosition(xAxis, yAxis, type);
            this.sideWhite = sideWhite;
            position = (xAxis, yAxis);
            this.type = type;
        }
        
        public (int, int) getPosition() {
            return position;
        }
        public string getType() {
            return type;
        }
        public bool getColor() {
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
             String leftAttack = ChessBoard.getPosition(xAxis + 1, yAxis - 1);
             bool leftValid = !(leftAttack == "x " || leftAttack == "o ") && (xAxis != 1);
             
            //right move validation
             String rightAttack = ChessBoard.getPosition(xAxis - 1, yAxis - 1);
             bool rightValid = !(rightAttack == "x " || rightAttack == "o ") && (xAxis != 8);
             
            //forward 1 move validation
             int frontMoveDirectionOne = isWhite ? 1 : -1; //not workin properly
             //need to make list into object to pass color
             String forwardMove = ChessBoard.getPosition(xAxis, yAxis + frontMoveDirectionOne);
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
             else if (xTemp == xAxis && yTemp == yAxis + frontMoveDirectionOne && frontValid) { //move 1 space forward
                 setPosition(xTemp, yTemp, "P ");
             }
             
             replaceTile(xAxis, yAxis);
             PrintBoard();
        }//still in progress?
    }
}