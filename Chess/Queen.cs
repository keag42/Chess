namespace Chess {
    public class Queen : Pieces{
        private (int x, int y) position = (0, 0);

        //starting position constructor
        public Queen(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "Q");
            position = (xAxis, yAxis);
        }

        //Queen Move method
        
        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}