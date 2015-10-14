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
        private Canvas Canvas { get; set; }

        public Star(Canvas canvas, Random randomSeed)
        {
            RandomGenerator = randomSeed;
            Canvas = canvas;
            PositionRandomlyStarOnCanvas();
            Distance = 0;
            Speed = 0.025;
        }

        public void Move()
        {
            Distance += 0.1;

            //determine in which direction the star should be moving on the x axis
            var xcalc = (Math.Abs(Canvas.CenterX - X) * Speed) * (Distance * 0.2);
            X += (X > Canvas.CenterX ? 1 : -1) * xcalc;

            //determine in which direction the star should be moving on the y axis
            var ycalc = (Math.Abs(Canvas.CenterY - Y) * Speed) * (Distance * 0.2);
            Y += (Y > Canvas.CenterY ? 1 : -1) * ycalc;

            //see if the star has left the edge of the canvas
            if (IsOutOfCanvas()) RepositionStarOnCanvas();
        }
        public void RepositionStarOnCanvas()
        {
            PositionRandomlyStarOnCanvas(); 
            Distance = 0;
        }

        public bool IsOutOfCanvas()
        {
            return X > Canvas.MaxWidth || X < 0 || Y > Canvas.MaxHeight || Y < 0;
        }

        private void PositionRandomlyStarOnCanvas()
        {
            //makes sure that the star is not in the exact center of the canvas
            do
            {
                X = RandomGenerator.Next(0, Canvas.MaxWidth);
                Y = RandomGenerator.Next(0, Canvas.MaxHeight);
            } while (Math.Abs(X - Canvas.CenterX) < 0.1 && Math.Abs(Y - Canvas.CenterY) < 0.1);
        }
    }
}