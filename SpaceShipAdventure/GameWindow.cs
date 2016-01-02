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
        private Asteroid AnAstroid = new Asteroid(200,100);
        private Asteroid AnAstroid2 = new Asteroid(300, 300);
        private Asteroid AnAstroid3 = new Asteroid(410, 220);
        private Asteroid AnAstroid4 = new Asteroid(750, 500);
        private Asteroid AnAstroid5 = new Asteroid(800, 400);
        private FinishGate theFinish = new FinishGate();

        private double TimerVal;

        public GameWindow()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

//            InitializeAllGameObjects(true);

      

        

        }


        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            TheShip.Draw(g);
            AnAstroid.Draw(g);
            AnAstroid2.Draw(g);
            AnAstroid3.Draw(g);
            AnAstroid4.Draw(g);
            AnAstroid5.Draw(g);
            theFinish.Draw(g);

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
        }
    }
}
