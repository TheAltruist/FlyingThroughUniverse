namespace FlyingThroughUniverse
{
    public class Canvas
    {
        private int _maxHeight;
        private int _maxWidth;

        public int MaxWidth
        {
            get { return _maxWidth; }
            set
            {
                _maxWidth = value;
                CenterX = (double)_maxWidth / 2;
            }
        }

        public int MaxHeight
        {
            get { return _maxHeight; }
            set
            {
                _maxHeight = value;
                CenterY = (double)_maxHeight / 2;
            }
        }

        public double CenterX { get; private set; }
        public double CenterY { get; private set; }

        public Canvas(int maxWidth, int maxHeight)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            CenterX = (double)MaxWidth / 2;
            CenterY = (double)MaxHeight / 2;
        }
    }
}