using System;
using System.Collections.Generic;


namespace SpaceshipCommander
{
    class Commander
    {
        public IShip_Player playerShip;
        public int SelectedLevel;


        public Commander()
        {
            SelectedLevel = 1;
        }

        public void Game_Start()
        {
            //Initialise stuff
            // Create a new ship object
            playerShip = new Ship();
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
