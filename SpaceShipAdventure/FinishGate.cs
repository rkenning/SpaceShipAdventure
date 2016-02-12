using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceshipCommander

{
     class FinishGate : GameObject
    {
        public Image normalgate = Image.FromFile(@"..\..\images\FinishGate.png");
        public Image glowgate1 = Image.FromFile(@"..\..\images\FinishGate.png");
        public Image glowgate2 = Image.FromFile(@"..\..\images\FinishGate.png");
        public Image glowgate3 = Image.FromFile(@"..\..\images\FinishGate.png");
        public Image glowgate4 = Image.FromFile(@"..\..\images\FinishGate.png");

        public FinishGate(int x_, int y_): base(@"..\..\images\FinishGate.png")
		{
            Position.X = x_;
            Position.Y = y_;

        }

        public  void Draw(Graphics g, int angle_)
        {
            Image temp = normalgate;
            UpdateBounds();
            g.DrawImage(temp, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
            temp = null;
        }

        public void Draw2(Graphics g, int angle_)
        {
            
            UpdateBounds();
            g.DrawImage(normalgate, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
           
        }




    }
}