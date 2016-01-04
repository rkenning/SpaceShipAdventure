using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SpaceShipAdventure
{
    public partial class GameWindow : Form
    {

        private Ship TheShip = new Ship();

        private Asteroid[] Asteroids = new Asteroid[6];

        void InitializeAsteroids()
        {
            Asteroids[0] = new Asteroid(200, 100);
            Asteroids[1] = new Asteroid(300, 300);
            Asteroids[2] = new Asteroid(410, 220);
            Asteroids[3] = new Asteroid(750, 500);
            Asteroids[4] = new Asteroid(800, 400);
        }




        private FinishGate theFinish = new FinishGate();

        private double TimerVal;

        public GameWindow()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //            InitializeAllGameObjects(true);
            InitializeAsteroids();




        }


        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            TheShip.Draw(g);

            Asteroids[1].Draw(g);

            /* for (int i = 0; i < kNumberOfShields; i++)
             {
                 Shields[i].Draw(g);
             }

             //			g.FillRectangle(Brushes.Black, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
             TheMan.Draw(g);
             TheScore.Draw(g);
             TheHighScore.Draw(g);
             _livesIndicator.Draw(g);

             if (ActiveBullet)
             {
                 TheBullet.Draw(g);
             }

             if (SaucerStart)
             {
                 CurrentSaucer.Draw(g);
             }

             for (int i = 0; i < kNumberOfRows; i++)
             {
                 TheInvaders = InvaderRows[i];
                 TheInvaders.Draw(g);
             }*/
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            TimerVal = 0.0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time_GameTick.Enabled = true;



        }

        private void time_GameTick_Tick(object sender, EventArgs e)
        {
            //Check for Any Collisions  


            //Checl fpr 

            TimerVal = TimerVal + 0.01;
            lblTime.Text = TimerVal.ToString();
            TheShip.Position.X = TheShip.Position.X + 2;
            Invalidate();



            for (int j = 0; j < Asteroids.Length; j++)
            {
                //Check for astoride collisions
                if (Asteroids[j].IsShipColliding(TheShip.GetBounds()))
                {
                    TheShip.BeenHit = true;
                    //   PlaySoundInThread("2.wav", 1);
                }
            }

        }
    }
}
