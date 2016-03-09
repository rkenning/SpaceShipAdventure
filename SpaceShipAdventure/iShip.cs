using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceshipCommander
{

    //Defined outside the IShip interface to support setstatus 
    //TODO May need to pop back and re-work this bit as x2 set of list to maintain

    interface IShip 
    {


        int Power { get; set; }
        int direction { get; set; }
        int volicity { get; set; }
        int engines { get; set; } // 1 on 0 off
        string ShipName { get; set; }
        Point Position { get; set; }

        void Draw(Graphics g);

     
        Ship.Status ShipStatus { get; set; }

        bool IsShipColliding(Rectangle r);
        void set_status(Ship.Status status);

        //void set_status(Iship.Status status);
    }
}
