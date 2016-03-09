using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{
    interface IShip_Player
    {


        void set_Ship_Name(String Ship_Name);
        void enginesOn();
        void rotateClockWise();
        void rotateCounterClockWise();



       // void set_status(Iship.Status status);
    }
}
