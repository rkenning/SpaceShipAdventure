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
        private FinishGate theFinish = new FinishGate(1000, 300);

        private Commander PlayerCommander = new Commander();

        Iship TheShip;

        double lastGameEventTick = 0;
        GameEvent lastGameEvent;

        private void GameWindow_Load(object sender, EventArgs e)
        {
            TimerVal = 0.0;
            PlayerCommander.Game_Start();
            TheShip = (Iship)PlayerCommander.playerShip;

        }


        //Intialise Game Objects
        void InitializeAsteroids()
        {
            Asteroids[0] = new Asteroid(500, 300);
            Asteroids[1] = new Asteroid(1300, 300);
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
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            //            InitializeAllGameObjects(true);
            InitializeAsteroids();
        }


        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            Bitmap curBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            Graphics g1 = Graphics.FromImage(curBitmap);
            Graphics g = e.Graphics;

            Single textRight = 1050f;

            PointF power = new PointF(textRight, 1f);
            PointF direction = new PointF(textRight, 15f);
            PointF X_Cord = new PointF(textRight, 30f);
            PointF Y_Cord = new PointF(textRight, 45f);
            PointF Engines = new PointF(textRight, 60f);
            PointF Time = new PointF(textRight, 75f);

            for (int j = 0; j < Asteroids.Length; j++)
            {
                Asteroids[j].Draw(g1);
            }

            if (TheShip != null)
            {
                theFinish.Draw(g1);
                TheShip.Draw(g1);


                // Draw the UI
                using (Font arialFont = new Font("Arial", 10))
                {
                    g1.DrawString("Ship Power:" + TheShip.Power.ToString(), arialFont, Brushes.Red, power);
                    g1.DrawString("Direction:" + TheShip.direction.ToString(), arialFont, Brushes.Red, direction);
                    g1.DrawString("X Cord:" + TheShip.Position.X.ToString(), arialFont, Brushes.Red, X_Cord);
                    g1.DrawString("Y Cord:" + TheShip.Position.Y.ToString(), arialFont, Brushes.Red, Y_Cord);
                    g1.DrawString("Engines:" + TheShip.engines.ToString(), arialFont, Brushes.Red, Engines);
                    g1.DrawString("Tick:" + TimerVal.ToString(), arialFont, Brushes.Red, Time);
                }


            };

            g.DrawImage(curBitmap, 0, 0);



        }



        private void button1_Click(object sender, EventArgs e)
        {
            time_GameTick.Enabled = true;



        }

        private void time_GameTick_Tick(object sender, EventArgs e)
        {



            if (TheShip != null)
            {
                int last_x = TheShip.Position.X;
                int last_y = TheShip.Position.Y;
                // Calculate Ship movement if the engines are running
                if (TheShip.engines == 1)
                {

                    TheShip.Position.X = GraphicUtil.new_x(TheShip.volicity, TheShip.direction, TheShip.Position.X);
                    TheShip.Position.Y = GraphicUtil.new_y(TheShip.volicity, TheShip.direction, TheShip.Position.Y);
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
                            TheShip.engines = 0;
                            TheShip.Position.X = GraphicUtil.new_x(TheShip.volicity -15 , TheShip.direction , TheShip.Position.X);
                            TheShip.Position.Y = GraphicUtil.new_y(TheShip.volicity -15, TheShip.direction  , TheShip.Position.Y);

                                PlayerCommander.ProcessGameEvent(new GameEvent(GameEvent.Event_Types.HitAstorid));
                                lastGameEvent = new GameEvent(GameEvent.Event_Types.HitAstorid);
                                lastGameEventTick = TimerVal;
                        }
                    }
                }

                /* Check for the screen edges and stop the ship */
                if (TheShip.Position.Y < 0 || TheShip.Position.Y > ClientRectangle.Height - 50 || TheShip.Position.X < 0 || TheShip.Position.X > ClientRectangle.Width - 50)
                {
                    TheShip.set_status(Ship.Status.Stopped);

                        TheShip.engines = 0;
                        TheShip.Position.X = GraphicUtil.new_x(TheShip.volicity -15, TheShip.direction , TheShip.Position.X);
                        TheShip.Position.Y = GraphicUtil.new_y(TheShip.volicity-15, TheShip.direction , TheShip.Position.Y);
                        PlayerCommander.ProcessGameEvent(new GameEvent(GameEvent.Event_Types.EdgeOfSpace));
                        lastGameEventTick = TimerVal;
                }

                /* Check the Ship has reached the finish */
                if (TheShip.IsShipColliding(theFinish.GetBounds()))
                {
                    time_GameTick.Enabled = false;
                    MessageBox.Show("Ship : [" + TheShip.ShipName + "], finish level in :" + TimerVal.ToString() + " ticks");

                };

            };


            //Draw the screen
            Invalidate();

            if (TheShip != null)
            {
                //Post screen update check for ship explosion
                if (TheShip.ShipStatus == Ship.Status.Explode)
                {
                    time_GameTick.Enabled = false;
                    MessageBox.Show("Game Over!");
                    this.Close();
                }
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
