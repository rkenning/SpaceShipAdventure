using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceshipCommander

{
    class Ship : GameObject
    {
        public int Power;
        public int direction;
        public int volicity { get; set; }
        public int engines { get; set; } // 1 on 0 off
        public string ShipName;

        private Image ShipExplode = Image.FromFile(@"..\..\images\ship_explode.png");
        //private Image ShipShoot = Image.FromFile("ship_explode.png");

        private Image ShipMove0 = Image.FromFile(@"..\..\images\Ship\Ship0.png");
        private Image ShipMove45 = Image.FromFile(@"..\..\images\Ship\Ship45.png");
        private Image ShipMove90 = Image.FromFile(@"..\..\images\Ship\Ship90.png");
        private Image ShipMove135 = Image.FromFile(@"..\..\images\Ship\Ship135.png");
        private Image ShipMove180 = Image.FromFile(@"..\..\images\Ship\Ship180.png");
        private Image ShipMove225 = Image.FromFile(@"..\..\images\Ship\Ship225.png");
        private Image ShipMove270 = Image.FromFile(@"..\..\images\Ship\Ship270.png");
        private Image ShipMove315 = Image.FromFile(@"..\..\images\Ship\Ship315.png");



        public enum Status
        {
            Moving,
            HitAstorid,
            HitLaser,
            Stopped,
            Nothing,
            Explode
        };


        public Status ShipStatus { get; set; }

        public void set_status(Ship.Status status)
        {
            ShipStatus = status;
            if (status == Ship.Status.Stopped)
            {
                engines = 0;
            }


        }

        public void enginesOn()
        {
            engines = 1;
        }



        public Ship() : base(@"..\..\images\Ship\Ship90.png")
        {
            Position.X = 10;
            Position.Y = 300;
            volicity = 4;
            Power = 100;
            ShipStatus = Status.Stopped;
            direction = 90;
        }


        public void set_direction(int direction_)
        {
            direction = direction_;
        }

        public void rotateCounterClockWise()
        {
            direction -= 45;
            if (direction < 0)
            { direction = 315; };
        }

        public void rotateClockWise()
        {
            direction += 45;
            if (direction > 360)
            { direction = 45; };
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
            Image tempShip = TheImage;

            if (direction == 0 || direction == 360)
            {
                tempShip = ShipMove0;
            }
            if (direction == 45)
            {
                tempShip = ShipMove45;
            }
            if (direction ==135)
            {
                tempShip = ShipMove135;
            }
            if (direction == 180)
            {
                tempShip = ShipMove180;
            }
            if (direction == 225)
            {
                tempShip = ShipMove225;
            }
            if (direction == 270)
            {
                tempShip = ShipMove270;
            }
            if (direction == 225)
            {
                tempShip = ShipMove225;
            }
            if (direction == 315)
            {
                tempShip = ShipMove315;
            }

            //Check status of the ship
            // Moving
            // Stationaty
            // Exploded
            // Shooting

            switch (this.ShipStatus)
            {
                case Status.HitAstorid:
                    break;
                case Status.HitLaser:
                    break;
                case Status.Moving:
                    UpdateBounds();
                    break;
                case Status.Stopped:
                    break;
                case Status.Explode:
                    tempShip = ShipExplode;
                    break;
            }

            UpdateBounds();
            g.DrawImage(tempShip, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
            draw_Shield(g);

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
                    this.engines = 0; // Turn off the engines as we have been hit
                    this.ShipStatus = Status.Explode;

                }
                //this.engines = 0; // Turn off the engines as we have been hit
                return true;


            }

            return false;
        }



    }
}