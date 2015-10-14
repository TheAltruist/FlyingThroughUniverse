using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingThroughUniverse
{
    public partial class FrmMain : Form
    {
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

            Stars = new List<Star>();
            CreateStars();
            TmrTime.Interval = 10;
            TmrTime.Enabled = true;
            TmrTime.Start();
        }

        
        private void TmrTime_Tick(object sender, EventArgs e)
        {
            foreach (var star in Stars)
            {
                Circle(Color.Black, star.X, star.Y, star.Distance);

                star.Move();

                Circle(Color.White, star.X, star.Y, star.Distance);
            }
            
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
            var canvas = new Canvas(Width, Height);
            for (var i = 0; i < totalStars; i++)
            {
                Stars.Add(new Star(canvas, randomSeed));
            }
        }

        private void FrmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TmrTime.Stop();
            Environment.Exit(0);
        }
    }
}
