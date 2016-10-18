using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;


namespace SpaceshipCommander
{
    class Commander
    {
        public IShip_Player playerShip;
        public int SelectedLevel;
        int count = 0;


        public Commander()
        {
            SelectedLevel = 3;
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
            List<IGameObject_Player> TempList = playerShip.ShipScan();

            foreach (IGameObject_Player TempObj in TempList)
            {
                if (TempObj.GetType().ToString() == "SpaceshipCommander.FinishGate")
                {
                    if (playerShip.getShipPosition().X > TempObj.getPositionX())
                    {
                        int test = playerShip.getTargetAngle(TempObj);

                       
                        Debug.WriteLine("Ship Direction=" + playerShip.GetDirection());

                        Debug.WriteLine(Math.Abs(test - playerShip.GetDirection()));
                        if (Math.Abs(test - playerShip.GetDirection()) > 60)
                        {
                            while (Math.Abs(test - playerShip.GetDirection()) > 60)
                            {
                                playerShip.shipRotateClockWise();
                                Debug.WriteLine("Ship Direction=" + playerShip.GetDirection());
                                Debug.WriteLine("GAte Direction=" + playerShip.getTargetAngle(TempObj));
                                Debug.WriteLine("Diff=" + Math.Abs(test - playerShip.GetDirection()));
                            }
                        }
                    }
                }
                if (TempObj.GetType().ToString() == "SpaceshipCommander.Asteroid")
                {
                    
                    //TempObj.

                    count += 1;
                    if (count > 7)
                    {
                        playerShip.shipRotateCounterClockWise();
                        Debug.WriteLine("Count is :"+count);
                        count = 0;
                    }
                    else if(count ==4)
                    {
                        playerShip.shipRotateCounterClockWise();
                        Debug.WriteLine("Count is :" + count);
                    }

                    else
                    {
                        playerShip.shipRotateClockWise();
                        //                        playerShip.shipRotateClockWise();
                        Debug.WriteLine("Count is :" + count);
                    }
                        Debug.WriteLine("Ship Direction=" + playerShip.GetDirection());
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
                Debug.WriteLine("Edge of space - Turning clockwise");
                playerShip.shipRotateClockWise();
            }


        }

    }
}
