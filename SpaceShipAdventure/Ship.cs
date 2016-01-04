using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceShipAdventure

{
     class Ship : GameObject
    {
        int Power;



        public Ship(): base("ship.png")
		{
            Position.X = 10;
            Position.Y = 300;
            Power = 100;
            
        }

        public override  void Draw(Graphics g)
        {
            //Check status of the ship
            // Moving
            // Stationaty
            // Exploded
            // Shooting

            //TODO - Apply the staus above
            base.Draw(g);
        }

        public bool IsShipColliding(Rectangle r)
        {

            //TODO Work through the collision process
            if (TheBomb.GetBounds().IntersectsWith(r))
            {
                return true;
            }

            return false;
        }

    }
}