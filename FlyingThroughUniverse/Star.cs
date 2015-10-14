using System;

namespace FlyingThroughUniverse
{
    public class Star
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance { get; set; }
        public double Speed { get; set; }
        private Random RandomGenerator { get; set; }
        private int MaxCanvasWidth { get; set; }
        private int MaxCanvasHeight { get; set; }
        private double CanvasCenterX { get; set; }
        private double CanvasCenterY { get; set; }

        public Star(int maxCanvasWidth, int maxCanvasHeight, Random randomSeed)
        {
            RandomGenerator = randomSeed;
            MaxCanvasWidth = maxCanvasWidth;
            MaxCanvasHeight = maxCanvasHeight;
            CanvasCenterX = (double)MaxCanvasWidth / 2;
            CanvasCenterY = (double)MaxCanvasHeight / 2;

            PositionRandomlyStarOnCanvas();
            Distance = 0;
            Speed = 0.025;
        }

        public void Move()
        {
            Distance += 0.1;

            //determine in which direction the star should be moving on the x axis
            var xcalc = (Math.Abs(CanvasCenterX - X) * Speed) * (Distance * 0.2);
            X += (X > CanvasCenterX ? 1 : -1) * xcalc;

            //determine in which direction the star should be moving on the y axis
            var ycalc = (Math.Abs(CanvasCenterY - Y) * Speed) * (Distance * 0.2);
            Y += (Y > CanvasCenterY ? 1 : -1) * ycalc;

            //see if the star has left the edge of the screen
            if (IsOutOfCanvas()) RepositionStarOnCanvas();
        }
        public void RepositionStarOnCanvas()
        {
            PositionRandomlyStarOnCanvas(); 
            Distance = 0;
        }

        public bool IsOutOfCanvas()
        {
            return X > MaxCanvasWidth || X < 0 || Y > MaxCanvasHeight || Y < 0;
        }

        private void PositionRandomlyStarOnCanvas()
        {
            //makes sure that the star is not in the exact center of the canvas
            do
            {
                X = RandomGenerator.Next(0, MaxCanvasWidth);
                Y = RandomGenerator.Next(0, MaxCanvasHeight);
            } while (Math.Abs(X - CanvasCenterX) < 0.1 && Math.Abs(Y - CanvasCenterY) < 0.1);
        }
    }
}