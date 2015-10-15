using System;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace FlyingThroughUniverse
{
    public partial class FrmMain : Form
    {
        protected Canvas CanvasSurface { get; set; }
        
        public FrmMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            ForeColor = Color.White;

            CanvasSurface = new Canvas(Width, Height);
            Travel(CreateObservableUniverse());
        }

        private void Travel(IObservable<Star> observableStars)
        {
            observableStars.ObserveOn(Scheduler.CurrentThread).Subscribe(star =>
            {
                Circle(Color.Black, star.X, star.Y, star.Distance);
                star.Move();
                Circle(Color.White, star.X, star.Y, star.Distance);
            });
        }

        private IObservable<Star> CreateObservableUniverse()
        {
            const int totalStars = 100;
            var randomSeed = new Random();
            var stars = Enumerable.Range(0, totalStars)
                .Select(x => new Star(CanvasSurface, randomSeed))
                .ToList()
                .ToObservable(Scheduler.Default)
                .Repeat();
            return stars;
        }

        private void Circle(Color color, double x, double y, double diameter)
        {
            var myGraphics = CreateGraphics();
            myGraphics.FillEllipse(new SolidBrush(color), (float)x, (float)y, (float)diameter, (float)diameter);
        }

        private void FrmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            CanvasSurface.CenterX = e.X;
            CanvasSurface.CenterY = e.Y;
        }
    }
}
