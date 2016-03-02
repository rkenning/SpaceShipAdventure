using System.Drawing;
using System.Drawing.Drawing2D;


namespace SpaceshipCommander

{
     class FinishGate : GameObject
    {

        public int imageCount = 0;
        public int frameCount = 0;
        public Image img1 = Image.FromFile(@"..\..\images\FinishGate\FinishGate1.png");
        public Image img2 = Image.FromFile(@"..\..\images\FinishGate\FinishGate2.png");
        public Image img3 = Image.FromFile(@"..\..\images\FinishGate\FinishGate3.png");
        public Image img4 = Image.FromFile(@"..\..\images\FinishGate\FinishGate4.png");
        public Image img5 = Image.FromFile(@"..\..\images\FinishGate\FinishGate5.png");
        public Image img6 = Image.FromFile(@"..\..\images\FinishGate\FinishGate6.png");
        public Image img7 = Image.FromFile(@"..\..\images\FinishGate\FinishGate7.png");

        public FinishGate(int x_, int y_): base(@"..\..\images\FinishGate.png")
		{
            Position.X = x_;
            Position.Y = y_;

        }

        public override void  Draw(Graphics g)
        {

            frameCount += 1;
            if (frameCount == 10)
            { imageCount += 1;
                frameCount = 1;
            }
                
            Image temp = img1;
            if (imageCount == 8)
                { imageCount = 1; };
            switch (imageCount)
            {
                case 1:
                    temp = img1;
                    break;
                case 2:
                    temp = img2;
                    break;
                case 3:
                    temp = img3;
                    break;
                case 4:
                    temp = img4;
                    break;
                case 5:
                    temp = img5;
                    break;
                case 6:
                    temp = img6;
                    break;
                case 7:
                    temp = img7;
                    break;
            }

                    UpdateBounds();
            g.DrawImage(temp, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
            temp = null;
        }

        public void Draw2(Graphics g, int angle_)
        {
            
            UpdateBounds();
           // g.DrawImage(normalgate, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
           
        }




    }
}