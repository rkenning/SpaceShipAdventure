using System;
using System.Collections.Generic;
using System.Drawing;
/*
namespace SpaceshipCommander
{
    class Commander
    {
        public IShip_Player playerShip;
        public int SelectedLevel;
        int finishX, finishY;


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
                if (temp2.GetType() == typeof(FinishGate))
                {
                    finishX= temp2.getPositionX();
                    finishY= temp2.getPositionY();
                }
            };


        }

        public void ProcessGameTick()
        {
            playerShip.shipEnginesOn();
            Point temppoint = playerShip.shipGetPosition();
            if (temppoint.X == finishX)
            {
                if (temppoint.Y < finishY)
                {
                    playerShip.shipRotateClockWise();
                    playerShip.shipRotateClockWise();
                }



                if (temppoint.Y > finishY)
                {
                    playerShip.shipRotateCounterClockWise();
                    playerShip.shipRotateCounterClockWise();
                }
            }
        }

        public void ProcessGameEvent(GameEvent TempEvent)
        {
            if (TempEvent.event_type == GameEvent.Event_Types.HitAstorid)
            {
                playerShip.shipRotateCounterClockWise();
            }

            if (TempEvent.event_type == GameEvent.Event_Types.EdgeOfSpace)
            {
                playerShip.shipRotateClockWise();
            }


        }

    }
}
*/