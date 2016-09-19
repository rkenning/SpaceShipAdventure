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
        List<IGameObject> ShipScan(); //Scan the local area around the ship for game objects


        GamePosition getShipPosition();
     

       // void set_status(Iship.Status status);
    }
}
