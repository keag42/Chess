namespace Chess {

    public class Pawn : Pieces{
        private (int x, int y) position = (0, 0);

        //starting position constructor
        public Pawn(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "P");
            position = (xAxis, yAxis);
        }

        //THINK THROUGH NOT READY YET
        /*
        public void PawnMove(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "P");
        }*/

        
       
        public static void PawnMove(int xAxis, int yAxis, bool isWhite) { //Still in progress
             byte pawnStartingPosition = isWhite ? (byte)2 : (byte)7;
             if(yAxis == pawnStartingPosition) {  //if its the first move 
                 
                Console.WriteLine("would you like to go forward one tile or two? 1, 2");
                byte tileChoice = Convert.ToInt16(Console.ReadLine()) == 1 ? (byte)1 : (byte)2;

                if (isWhite) {
                    ChessBoard.setPosition(xAxis, yAxis + tileChoice, "P"); //if white go one direction
                }
                else {
                    ChessBoard.setPosition(xAxis, yAxis - tileChoice, "P"); //if black go other direction
                }
                
             }
             
             //replace tile
             board2D[yAxis][xAxis] = yAxis % 2 == 0 ? (xAxis % 2 ==0 ? "X " : "O ") : (xAxis % 2 == 0 ? "O " : "X ");
            
        }
        
        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}