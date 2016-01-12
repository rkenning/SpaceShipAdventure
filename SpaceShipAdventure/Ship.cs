using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceShipAdventure

{
    class Ship : GameObject
    {
        public int Power;
        public int direction;

        private Image ShipExplode =  Image.FromFile(@"..\..\images\ship_explode.png");
        //private Image ShipShoot = Image.FromFile("ship_explode.png");
        private Image ShipMoving = Image.FromFile(@"..\..\images\ship_move.png");



        public enum Status
        {
            Moving,
            HitAstorid,
            HitLaser,
            Stopped,
            Explode
        };




        public Status ShipStatus { get; set; }

        public void set_status(Ship.Status status)
        {
            ShipStatus = status;
        }

        public Ship() : base(@"..\..\images\ship.png")
        {
            Position.X = 10;
            Position.Y = 300;
            Power = 100;
            ShipStatus = Status.Stopped;
            direction = 90;
        }


        private void draw_Shield(Graphics g)
        {

            Pen SheildPen = new Pen(Color.FromArgb(Power + 10, 255, 36, 72), 5);
            //Rectangle sheildrect 

            Rectangle sheildBound = this.GetBounds();
            //Grow base rectangle for shield base
            sheildBound.Inflate(15, 15);
            g.DrawEllipse(SheildPen, sheildBound);
        }


        public override void Draw(Graphics g)
        {
            //Check status of the ship
            // Moving
            // Stationaty
            // Exploded
            // Shooting

            switch (this.ShipStatus)
            {
                case Status.HitAstorid:
                    UpdateBounds();
                    g.DrawImage(TheImage, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
                    draw_Shield(g);
                    break;
                case Status.HitLaser:
                    UpdateBounds();
                    g.DrawImage(TheImage, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
                    draw_Shield(g);
                    break;
                case Status.Moving:
                    UpdateBounds();
                    g.DrawImage(ShipMoving, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
                    draw_Shield(g);
                    break;
                case Status.Stopped:
                    UpdateBounds();
                    g.DrawImage(TheImage, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
                    draw_Shield(g);
                    break;
                case Status.Explode:
                    UpdateBounds();
                    g.DrawImage(ShipExplode, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
                    
                    break;
            }

            //TODO - Apply the staus above

            //Draw the sheild



        }

        public bool IsShipColliding(Rectangle r)
        {

            //TODO Work through the collision process
            if (this.GetBounds().IntersectsWith(r))
            {
                Power -= 1;
                if (Power <= 0)
                {
                    this.ShipStatus = Status.Explode;
                    
                }
                     
                return true;


            }

            return false;
        }

  

    }
}