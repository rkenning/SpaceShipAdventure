using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace SpaceshipCommander

{
    class Ship : GameObject, IShip, IShip_Player
    {
        public new Point Position { get; set; }

        public int ShieldPower { get; set; }
        public int direction { get; set; }
        public int volicity { get; set; }
        public int Engines { get; set; } // 1 on 0 off
        public string ShipName { get; set; }

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

        public GamePosition getShipPosition()
        {
            GamePosition ShipPosition = new GamePosition(Position.X, Position.Y);
            return ShipPosition;
        }

        public void shipSetStatus(Ship.Status status)
        {
            ShipStatus = status;
            if (status == Ship.Status.Stopped)
            {
                Engines = 0;
            }


        }

        public void shipSetName(string ship_name)
        {
            this.ShipName = ship_name;
        }

        public void shipEnginesOn()
        {
            Engines = 1;
        }



        public Ship()
        {
            TheImage = ShipMove90;
            ImageBounds.Width = TheImage.Width - 2;
            ImageBounds.Height = TheImage.Height - 2;
            Position = new Point(100, 200);
            //without the need to pass the System.Drawing.Point object

            volicity = 2;
            ShieldPower = 100;
            ShipStatus = Status.Stopped;
            direction = 90;
        }


        public void shipRotateCounterClockWise()
        {
            direction -= 45;
            if (direction < 0)
            { direction = 315; };
        }

        public void shipRotateClockWise()
        {
            direction += 45;
            if (direction > 360)
            { direction = 45; };
        }


        public Point shipGetPosition()
        {
            return Position;
        }


        public List<IGameObject> ShipScan()
        {
            return GameDictionary.getGameObjects(getShipPosition(), 300);
        }

        public override void UpdateBounds()
        {
            /* Didn't want to have an override updatebounds however IShip interface cannot reference GameObject class position
            resulting in a mix of Position values.  Position is now local to this class so require update bounds localy
            TODO there must be a better way to do this!
            */
            MovingBounds = ImageBounds;
            MovingBounds.Offset(Position);
        }

        private void draw_Shield(Graphics g)
        {

            Pen SheildPen = new Pen(Color.FromArgb(ShieldPower + 10, 255, 36, 72), 5);
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
            if (direction == 135)
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
                //Decrease the shield power 
                ShieldPower -= 5;
                if (ShieldPower <= 0)
                {
                    this.Engines = 0; // Turn off the engines as we have been hit
                    this.ShipStatus = Status.Explode;

                }
                //this.engines = 0; // Turn off the engines as we have been hit
                return true;


            }

            return false;
        }



    }
}