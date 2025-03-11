namespace Chess {
    public class Horse : Pieces{
        private (int x, int y) position = (0, 0);

        //starting position constructor
        public Horse(int xAxis, int yAxis) {
            setPosition(xAxis, yAxis, "H");
            position = (xAxis, yAxis);
        }

        //Horse Move method
        
        //method for getting location
        public (int, int) getPosition() {
            return position;
        }
    }
}