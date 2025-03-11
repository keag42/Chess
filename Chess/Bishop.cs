namespace Chess {
    public class Bishop : Pieces{
        private (int x, int y) position = (0, 0);

        //starting position constructor
        public Bishop(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "B");
            position = (xAxis, yAxis);
        }

        //Bishop Move method
        
        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}