using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallGameChangeColor
{
    public partial class Form1 : Form
    {
        private int bw = 50;
        private int bh = 50;
        private int bpx = 0;
        private int bpy = 0;
        private int mStepx = 4;
        private int mStepy = 4;
        private int color = 1;

        private int bpx2 = 500;
        private int bpy2 = 0;
        private int mStepx2 = 4;
        private int mStepy2 = 4;


        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(this.BackColor);

            SolidBrush br = new SolidBrush(Color.Indigo);
            g.FillEllipse(br, bpx, bpy, bw, bh);
            g.FillEllipse(br, bpx2, bpy2, bw, bh);

            SolidBrush brGreen = new SolidBrush(Color.Green);
            SolidBrush brRed = new SolidBrush(Color.Red);
            SolidBrush brBlue = new SolidBrush(Color.Blue);
            SolidBrush brBlack = new SolidBrush(Color.Black);
            SolidBrush brPink = new SolidBrush(Color.Pink);

            if (bpx + bw == this.ClientSize.Width)
            {
                color = 1;
            }

            if (bpy + bh == this.ClientSize.Height)
            {
                color = 2;
            }

            if (bpx == 0)
            {
                color = 3;
            }

            if (bpy == 0)
            {
                color = 4;
            }

            if ( color ==1 )
            {
                g.FillEllipse(brBlack, bpx, bpy, bw, bh);
            }

            if ( color == 2)
            {
                g.FillEllipse(brBlue, bpx, bpy, bw, bh);
            }

            if (color == 3)
            {
                g.FillEllipse(brGreen, bpx, bpy, bw, bh);
            }

            if (color == 4)
            {
                g.FillEllipse(brPink, bpx, bpy, bw, bh);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            bpx += mStepx;
            bpx2 += mStepx2;

            if (bpx < 0 || bpx + bw > this.ClientSize.Width)
            {
                mStepx = -mStepx;


            }

            if (bpx2 < 0 || bpx2 + bw > this.ClientSize.Width)
            {
                mStepx2 = -mStepx2;


            }

            bpy += mStepy;
            bpy2 += mStepy2;


            if (bpy < 0 || bpy + bh > this.ClientSize.Height)
            {
                mStepy = -mStepy;
            }

            if (bpy2 < 0 || bpy2 + bh > this.ClientSize.Height)
            {
                mStepy2 = -mStepy2;
            }

            if (Math.Sqrt(Math.Pow(bpx - bpx2, 2) + Math.Pow(bpy - bpy2, 2)) < bh)
            {
                mStepy = -mStepy;
                mStepx = -mStepx;
                mStepx2 = -mStepx2;
                mStepy2 = -mStepy2;
            }

            this.Refresh();

        }
    }
}
