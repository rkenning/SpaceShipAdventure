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

        //Define Game Objects
        private Ship TheShip = new Ship();
        private Asteroid[] Asteroids = new Asteroid[5];
        private FinishGate theFinish = new FinishGate();



        //Intialise Game Objects
        void InitializeAsteroids()
        {
            Asteroids[0] = new Asteroid(200, 100);
            Asteroids[1] = new Asteroid(300, 300);
            Asteroids[2] = new Asteroid(410, 220);
            Asteroids[3] = new Asteroid(750, 500);
            Asteroids[4] = new Asteroid(800, 400);
        }






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


            for (int j = 0; j < Asteroids.Length; j++)
            {
                Asteroids[j].Draw(g);
            }
            TheShip.Draw(g);




            //Update UI details
            labStatus.Text = TheShip.ShipStatus.ToString();
            lblPower.Text = TheShip.Power.ToString();

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

            //Check Astorides
            for (int j = 0; j < Asteroids.Length; j++)
            {
                //Check for astoride collisions whith ships
                if (TheShip.IsShipColliding(Asteroids[j].GetBounds()))
                {
                    if (!(TheShip.ShipStatus == Ship.Status.Explode))
                    {
                        TheShip.ShipStatus = Ship.Status.HitAstorid;
                        TheShip.AstoidCollid();
                    }
                }
            }

            //Perform movement
            TimerVal = TimerVal + 1;
            lblTime.Text = TimerVal.ToString();

            if (!(TheShip.ShipStatus == Ship.Status.Explode))
            {
                //TODO Move the ship movement out
                if ((TheShip.ShipStatus == Ship.Status.HitAstorid) == false)
                {
                    TheShip.ShipStatus = Ship.Status.Moving;
                    TheShip.Position.X = TheShip.Position.X + 3;
                }
            }
            //Draw the screen
            Invalidate();

            if (TheShip.ShipStatus == Ship.Status.Explode)
            {
                time_GameTick.Enabled = false;
                MessageBox.Show("Game Over!");
                this.Close();
            }
        }
    }
}
