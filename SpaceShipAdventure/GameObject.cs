using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceshipCommander
{
    public class GameObject : IGameObject, IGameObject_Player
    {
        protected Image TheImage = null;
        public Point Position = new Point(50, 50);
        public GamePosition TempPosition;
        public Rectangle ImageBounds = new Rectangle(0, 0, 5, 5);
        public Rectangle MovingBounds = new Rectangle();
        

        //Exposed method via IGameObject for use by player
        public int getPositionX()
        {
            return Position.X;
        }

        public int getPositionY()
        {
            return Position.Y;
        }

        public GamePosition GetPosition()
        {
            TempPosition = new GamePosition(Position.X, Position.Y);
            return TempPosition;
        }

        public GameObject(string fileName)
        {
            TheImage = Image.FromFile(fileName);
            ImageBounds.Width = TheImage.Width - 2;
            ImageBounds.Height = TheImage.Height - 2;
            GameDictionary.addGameObject(this);
        }

        public GameObject()
        {
            TheImage = null;
        }


        public int Width
        {
            get
            {
                return ImageBounds.Width;
            }
        }

        public int Height
        {
            get
            {
                return ImageBounds.Height;
            }
        }


        public virtual int GetWidth()
        {
            return ImageBounds.Width;
        }

        public Image GetImage()
        {
            return TheImage;
        }

        public virtual Rectangle GetBounds()
        {
            return MovingBounds;
        }

        public virtual void UpdateBounds()
        {
            MovingBounds = ImageBounds;
            MovingBounds.Offset(Position);
        }


        public virtual void Draw(Graphics g)
        {
            UpdateBounds();
            g.DrawImage(TheImage, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
        }


    }
}





