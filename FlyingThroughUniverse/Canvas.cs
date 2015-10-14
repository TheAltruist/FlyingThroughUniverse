namespace FlyingThroughUniverse
{
    public class Canvas
    {
        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public double CenterX { get; set; }
        public double CenterY { get; set; }

        public Canvas(int maxWidth, int maxHeight)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            CenterX = (double)MaxWidth / 2;
            CenterY = (double)MaxHeight / 2;
        }
    }
}