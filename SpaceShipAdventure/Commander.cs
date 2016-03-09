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
        public IShip_Player playerShip { get; set; } 
        int tick_count = 0;

        public Commander()
        {

        }

        public void Game_Start()
        {
            //Initialise stuff
            // Create a new ship object
            playerShip = new Ship();
            playerShip.set_Ship_Name("Player's Ship");
            playerShip.enginesOn();
            

            
        }

        public void ProcessGameTick()
        {
            playerShip.enginesOn();
        }

        public void ProcessGameEvent(GameEvent TempEvent)
        {
            if (TempEvent.event_type == GameEvent.Event_Types.HitAstorid)
            {
                playerShip.rotateClockWise();
            }

            if (TempEvent.event_type == GameEvent.Event_Types.EdgeOfSpace)
            {
                playerShip.rotateClockWise();
            }


        }

    }
}
