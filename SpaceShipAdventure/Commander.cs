using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SpaceshipCommander
{
    class Commander
    {
        public IShip_Player playerShip;
        public int SelectedLevel;
        int finishX, finishY;


        public Commander()
        {
            SelectedLevel = 2;
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
                    GamePosition temppos = temp2.GetPosition();
                    
                }
            };


        }

        public void ProcessGameTick()
        {
            playerShip.shipEnginesOn();
            GamePosition temppoint = playerShip.getShipPosition();
            List<IGameObject> TempList =  playerShip.ShipScan();

            foreach (GameObject go in TempList)
            {
               if (go.GetType().ToString()== "SpaceshipCommander.FinishGate")
                {
                    if (playerShip.getShipPosition().X> go.getPositionX())
                    {
                        playerShip.shipRotateClockWise();
                    }

                }
            }



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
