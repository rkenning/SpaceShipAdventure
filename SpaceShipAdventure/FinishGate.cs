using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceshipCommander

{
     class FinishGate : GameObject
    {

        public FinishGate(): base(@"..\..\images\FinishGate.png")
		{
            Position.X = 1200;
            Position.Y = 300;

        }

        public override  void Draw(Graphics g)
        {

            base.Draw(g);
            /*  if (Died)
                return;

            if (BeenHit == false)
            {
                base.Draw(g);
            }
            else
            {
                if (CountExplosion < 15)
                    DrawExplosion(g);
                else
                    Died = true;
            }*/

        }
    }
}