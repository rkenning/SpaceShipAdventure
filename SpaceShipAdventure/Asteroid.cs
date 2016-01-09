using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceShipAdventure

{
     class  Asteroid : GameObject
    {

        public Asteroid(int positionX, int positionY): base(@"..\..\images\Astroid1.png")
		{
            Position.X = positionX;
            Position.Y = positionY;

        }

        public override  void Draw(Graphics g)
        {

            base.Draw(g);
        }


    }
}