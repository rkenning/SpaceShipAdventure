using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceShipAdventure

{
     class Ship : GameObject
    {

        public Ship(): base("ship.png")
		{
            Position.X = 10;
            Position.Y = 220;

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