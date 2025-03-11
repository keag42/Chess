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
        
        
        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}