using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceshipCommander
{
    class Commander
    {
        public Ship playerShip { get; set; } // TODO Impliment iShipPlayer (Only allowing limited functions)

        public Commander()
        { }

        public void Game_Start()
        {
            //Initialise stuff
            // Create a new ship object
           playerShip = new Ship();
            playerShip.ShipName = "Jen's Ship";
           playerShip.enginesOn();
        }

        public void ProcessGameTick()
        {

            //            if (playerShip.Position.Y==200)
            //                { playerShip.rotateClockWise(); }

            if (playerShip.Position.X == 330)
                { playerShip.rotateClockWise(); }

        }

        public void ProcessGameEvent(GameEvent TempEvent)
        {
            if (TempEvent.event_type == GameEvent.Event_Types.HitAstorid)
            {
                playerShip.rotateClockWise();
                playerShip.rotateClockWise();
                playerShip.enginesOn() ;
            }

            if (TempEvent.event_type == GameEvent.Event_Types.EdgeOfSpace)
            {
                playerShip.rotateCounterClockWise();
                playerShip.enginesOn();
            }


        }

    }
}
