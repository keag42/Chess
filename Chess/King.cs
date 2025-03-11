namespace Chess {
    public class King : Pieces{
        private (int x, int y) position = (0, 0);

        //starting position constructor
        public King(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "K");
            position = (xAxis, yAxis);
        }

        //Horse Move method
        
        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}