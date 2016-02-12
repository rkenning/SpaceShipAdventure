using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SpaceshipCommander
{
    public partial class GameWindow : Form
    {

        //Define Game Objects

        private Asteroid[] Asteroids = new Asteroid[5];
        private FinishGate theFinish = new FinishGate(1200, 300);

        private Commander PlayerCommander = new Commander();
        private Ship TheShip;

        double lastGameEventTick = 0;
        GameEvent lastGameEvent;


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
            //Graphics f = new Graphics( ;
            Graphics g = e.Graphics;


            for (int j = 0; j < Asteroids.Length; j++)
            {
                Asteroids[j].Draw(g);
            }

            if (TheShip != null)
            {
                TheShip.Draw(g);
                //Update UI details
                labStatus.Text = TheShip.ShipStatus.ToString();
                lblPower.Text = TheShip.Power.ToString();
                lblDirection.Text = TheShip.direction.ToString();
                lblX.Text = TheShip.Position.X.ToString();
                lblY.Text = TheShip.Position.Y.ToString();
                lblEngines.Text = TheShip.engines.ToString();
                lblTime.Text = TimerVal.ToString();


            };





        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            TimerVal = 0.0;
            PlayerCommander.Game_Start();
            TheShip = PlayerCommander.playerShip;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            time_GameTick.Enabled = true;



        }

        private void time_GameTick_Tick(object sender, EventArgs e)
        {

            // Calculate Ship movement if the engines are running
            if (TheShip.engines == 1)
            {
                TheShip.Position.X = GraphicUtil.new_x(3, TheShip.direction, TheShip.Position.X);
                TheShip.Position.Y = GraphicUtil.new_y(3, TheShip.direction, TheShip.Position.Y);
                TheShip.set_status(Ship.Status.Moving);
            };


            //------------  Collisions -------------------------
            
            //Check Astorides

            TheShip.ShipStatus = Ship.Status.Nothing;
            for (int j = 0; j < Asteroids.Length; j++)
            {
                //Check for astoride collisions whith ships
                if (TheShip.IsShipColliding(Asteroids[j].GetBounds()))
                {
                    if (!(TheShip.ShipStatus == Ship.Status.Explode))
                    {
                        TheShip.ShipStatus = Ship.Status.HitAstorid;

                        if (TimerVal - lastGameEventTick > 20)
                        {
                            PlayerCommander.ProcessGameEvent(new GameEvent(GameEvent.Event_Types.HitAstorid));
                            lastGameEvent = new GameEvent(GameEvent.Event_Types.HitAstorid);
                            lastGameEventTick = TimerVal;
                        }
                    }
                }
            }

            /* Check for the screen edges and stop the ship */
            if (TheShip.Position.Y < 0 || TheShip.Position.Y > 700 || TheShip.Position.X < 0 || TheShip.Position.X > 1400)
            {
                TheShip.set_status(Ship.Status.Stopped);
                if (TimerVal - lastGameEventTick > 10)
                {
                    PlayerCommander.ProcessGameEvent(new GameEvent(GameEvent.Event_Types.EdgeOfSpace));
                    lastGameEventTick = TimerVal;
                }
                }


            //------------  End of Collisions -------------------------

        
            
            

            //Draw the screen
            Invalidate();

            //Post screen update check for ship explosion
            if (TheShip.ShipStatus == Ship.Status.Explode)
            {
                time_GameTick.Enabled = false;
                MessageBox.Show("Game Over!");
                this.Close();
            }


            /*NOW Perform the players game tick code */
            PlayerCommander.ProcessGameTick();

            /* Finally Add to the timer variable */
            TimerVal = TimerVal + 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            testForm test = new testForm();
            test.Show();

        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            time_GameTick.Enabled = false;
        }


    }
}
