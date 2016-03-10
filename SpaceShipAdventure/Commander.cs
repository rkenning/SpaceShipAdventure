using System;
using System.Collections.Generic;


namespace SpaceshipCommander
{
    class Commander
    {
        public IShip_Player playerShip { get; set; } 
        int tick_count = 0;

        public Commander()
        {

        }

        public void Game_Start()
        {
            //Initialise stuff
            // Create a new ship object
            playerShip = new Ship(100,200);
            playerShip.shipSetName("Player's Ship");
            playerShip.shipEnginesOn();
            
            
        }

        public void ProcessGameTick()
        {
            playerShip.shipEnginesOn();
        }

        public void ProcessGameEvent(GameEvent TempEvent)
        {
            if (TempEvent.event_type == GameEvent.Event_Types.HitAstorid)
            {
                playerShip.shipRotateClockWise();
            }

            if (TempEvent.event_type == GameEvent.Event_Types.EdgeOfSpace)
            {
                playerShip.shipRotateClockWise();
            }


        }

    }
}
