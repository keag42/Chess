namespace Chess {
    public class Rook : Pieces{
        private (int x, int y) position = (0, 0);

        //starting position constructor
        public Rook(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "R");
            position = (xAxis, yAxis);
        }

        //Rook Move method
        
        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}