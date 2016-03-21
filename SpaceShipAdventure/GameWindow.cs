using System;
using System.Drawing;
using System.Windows.Forms;


namespace SpaceshipCommander
{
    public partial class GameWindow : Form
    {

        //Define Game Objects
        Level LevelData = new Level();
        private Commander PlayerCommander = new Commander();
        IShip TheShip;

        double lastGameEventTick = 0;
        GameEvent lastGameEvent;

        private void GameWindow_Load(object sender, EventArgs e)
        {

            //Get level data based on 
            LevelData.PopulateLevelData(PlayerCommander.SelectedLevel);

            TimerVal = 0.0;
            PlayerCommander.Game_Start();
            TheShip = (IShip)PlayerCommander.playerShip;

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
        }


        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            Bitmap curBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            Graphics g1 = Graphics.FromImage(curBitmap);
            Graphics g = e.Graphics;

            //Draw the astorides
            foreach (Asteroid tempAsteriod in LevelData.Asteroids)
            {
                tempAsteriod.Draw(g1);
            }

            if (TheShip != null)
            {
                LevelData.theFinish.Draw(g1);
                TheShip.Draw(g1);
                //Draw the ship UI
                GameUI.Draw(g1, TheShip, TimerVal,PlayerCommander);
            };

            //Draw the back image to the front
            g.DrawImage(curBitmap, 0, 0);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            time_GameTick.Enabled = true;



        }

        private void time_GameTick_Tick(object sender, EventArgs e)
        {


            TickLoop();
            TickLoop();
            TickLoop();

        }

  

        private void cmdStop_Click(object sender, EventArgs e)
        {
            time_GameTick.Enabled = false;
        }


        public void TickLoop()
        {
            if (TheShip != null)
            {
                int last_x = TheShip.Position.X;
                int last_y = TheShip.Position.Y;
                // Calculate Ship movement if the engines are running
                if (TheShip.Engines == 1)
                {


                    TheShip.Position = new Point(MovementUtil.new_x(TheShip.volicity, TheShip.direction, TheShip.Position.X)
                    , MovementUtil.new_y(TheShip.volicity, TheShip.direction, TheShip.Position.Y));
                    //TheShip.set_status(Ship.Status.Moving);
                };


                //------------  Collisions -------------------------

                //Check Astorides

                //TheShip.ShipStatus = Ship.Status.Nothing;
                foreach (Asteroid tempAsteriod in LevelData.Asteroids)
                {
                    //Check for astoride collisions whith ships
                    if (TheShip.IsShipColliding(tempAsteriod.GetBounds()))
                    {
                        if (!(TheShip.ShipStatus == Ship.Status.Explode))
                        {
                            TheShip.ShipStatus = Ship.Status.HitAstorid;
                            TheShip.Engines = 0;
                            TheShip.Position = new Point(MovementUtil.new_x(TheShip.volicity - 5, TheShip.direction, TheShip.Position.X)
                            , MovementUtil.new_y(TheShip.volicity - 5, TheShip.direction, TheShip.Position.Y));

                            PlayerCommander.ProcessGameEvent(new GameEvent(GameEvent.Event_Types.HitAstorid));
                            lastGameEvent = new GameEvent(GameEvent.Event_Types.HitAstorid);
                            lastGameEventTick = TimerVal;
                        }
                    }
                }

                /* Check for the screen edges and stop the ship */
                if (TheShip.Position.Y < 2 || TheShip.Position.Y > ClientRectangle.Height - 60 || TheShip.Position.X < 2 || TheShip.Position.X > ClientRectangle.Width - 60)
                {
                    TheShip.shipSetStatus(Ship.Status.Stopped);

                    TheShip.Engines = 0;
                    TheShip.Position = new Point(MovementUtil.new_x(TheShip.volicity - 10, TheShip.direction, TheShip.Position.X),
                     MovementUtil.new_y(TheShip.volicity - 10, TheShip.direction, TheShip.Position.Y));
                    PlayerCommander.ProcessGameEvent(new GameEvent(GameEvent.Event_Types.EdgeOfSpace));
                    lastGameEventTick = TimerVal;
                }

                /* Check the Ship has reached the finish */
                if (TheShip.IsShipColliding(LevelData.theFinish.GetBounds()))
                {
                    time_GameTick.Enabled = false;
                    MessageBox.Show("Ship : [" + TheShip.ShipName + "], finish level in :" + TimerVal.ToString() + " ticks");
                    this.Close();
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

    }
}
