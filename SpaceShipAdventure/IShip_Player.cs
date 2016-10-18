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
      
        int getTargetAngle(IGameObject_Player tempObj);
        int GetDirection();
        GamePosition getShipPosition();
        List<IGameObject_Player> ShipScan();


       // void set_status(Iship.Status status);
    }
}
