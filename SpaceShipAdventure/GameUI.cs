using System.Drawing;
using System;

namespace SpaceshipCommander
{
    static class GameUI
    {
        static public void Draw(Graphics g1, IShip tempShip, double timer, Commander tempCommander)
        {

            Single textRight = 1050f;

          
            PointF direction = new PointF(textRight, 15f);
            PointF X_Cord = new PointF(textRight, 30f);
            PointF Y_Cord = new PointF(textRight, 45f);
            PointF Engines = new PointF(textRight, 60f);
            PointF Time = new PointF(textRight, 75f);



            Brush ShieldPowerBrush = Brushes.Green;

            //Decide the colour of the sheild bar based on the ship power
            if (tempShip.ShieldPower > 80)
            {
                ShieldPowerBrush = Brushes.Green;
            }
            else if (tempShip.ShieldPower > 60)
            {
                ShieldPowerBrush = Brushes.YellowGreen;
            }
            else if (tempShip.ShieldPower > 40)
            {
                ShieldPowerBrush = Brushes.Yellow;
            }

            else if (tempShip.ShieldPower > 20)
            {
                ShieldPowerBrush = Brushes.OrangeRed;
            }
            else if (tempShip.ShieldPower > 1)
            {
                ShieldPowerBrush = Brushes.Red;
            }

            // Draw the UI
            using (Font arialFont = new Font("Arial", 10))
            {
                g1.DrawString("Level:" + tempCommander.SelectedLevel.ToString(), arialFont, Brushes.Red, new PointF(textRight, 1f));
                g1.DrawString("Direction:" + tempShip.direction.ToString(), arialFont, Brushes.Red, direction);
                g1.DrawString("X Cord:" + tempShip.Position.X.ToString(), arialFont, Brushes.Red, X_Cord);
                g1.DrawString("Y Cord:" + tempShip.Position.Y.ToString(), arialFont, Brushes.Red, Y_Cord);
                g1.DrawString("Engines:" + tempShip.Engines.ToString(), arialFont, Brushes.Red, Engines);
                g1.DrawString("Tick:" + timer.ToString(), arialFont, Brushes.Red, Time);

                //Power and power bar stuff
                g1.FillRectangle(ShieldPowerBrush, textRight, 110, tempShip.ShieldPower,10); 
                g1.DrawString("Ship Power:", arialFont, Brushes.Red, new PointF(textRight, 91f));
            }
        }
    }
}
