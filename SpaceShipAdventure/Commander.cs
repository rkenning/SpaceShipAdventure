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
        public Ship playerShip { get; set; }

        int engine_count;
        public Commander()
        { }

        public void Game_Start()
        {
            //Initialise stuff
            // Create a new ship object

            playerShip = new Ship();
            playerShip.direction = 90;
            playerShip.enginesOn();
            engine_count = 0;
        }

        public void ProcessGameTick()
        {

            if (playerShip.Position.Y==200)
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
                playerShip.rotateCounterClockWise();
                playerShip.rotateCounterClockWise();
                playerShip.enginesOn();
            }


        }

    }
}
