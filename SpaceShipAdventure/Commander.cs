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

            List<IGameObject> tempObj = GameDictionary.getGameObjects();

            foreach (IGameObject temp2 in tempObj)
            {
                if (temp2.GetType().ToString() == "SpaceshipCommander.FinishGate")
                {
                    int test = temp2.getPositionX();
                    int test2 = temp2.getPositionY();
                }
            };


        }

        public void ProcessGameTick()
        {
            playerShip.shipEnginesOn();
            if playerShip.
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
