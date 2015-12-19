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

        public GameWindow()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

//            InitializeAllGameObjects(true);

      

        time_GameTick.Start();

        }


        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            TheShip.Draw(g);

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
    }
}
