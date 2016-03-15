using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SpaceshipCommander
{
    interface IShip_Player
    {


        void shipSetName(String Ship_Name);
        void shipEnginesOn();
        void shipRotateClockWise();
        void shipRotateCounterClockWise();

        Point shipGetPosition();
     

       // void set_status(Iship.Status status);
    }
}
