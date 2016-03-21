using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;



namespace SpaceshipCommander
{
    class Commander
    {
        public int SelectedLevel;
        public IShip_Player playerShip;

        public Commander()
        {
            SelectedLevel = 2;
        }

        public void Game_Start()
        {
            playerShip = new Ship();
            playerShip.shipSetName("Player's Ship");
            playerShip.shipEnginesOn();
        }

        public void ProcessGameTick()
        {
        }

        public void ProcessGameEvent(GameEvent TempEvent)
        {
            Debug.WriteLine("My Log:"+TempEvent.GetType());
        }

    }
}
