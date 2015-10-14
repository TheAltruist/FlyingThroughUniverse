using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingThroughUniverse
{
    public partial class FrmMain : Form
    {
        protected Canvas CanvasSurface { get; set; }
        protected List<Star> Stars { get; set; }
        
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
            Stars = new List<Star>();
            CreateStars();
            Travel();
        }

        private void Travel()
        {
            var observableStars = Stars.Select(star => star).ToObservable(Scheduler.Default);
            observableStars.ObserveOn(Scheduler.CurrentThread).Subscribe(star =>
            {
                Circle(Color.Black, star.X, star.Y, star.Distance);
                star.Move();
                Circle(Color.White, star.X, star.Y, star.Distance);
            }, Travel);
        }

        private void Circle(Color color, double x, double y, double diameter)
        {
            var myGraphics = CreateGraphics();
            myGraphics.FillEllipse(new SolidBrush(color), (float)x, (float)y, (float)diameter, (float)diameter);
        }
        private void CreateStars()
        {
            const int totalStars = 100;
            var randomSeed = new Random();
            
            for (var i = 0; i < totalStars; i++)
            {
                Stars.Add(new Star(CanvasSurface, randomSeed));
            }
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
