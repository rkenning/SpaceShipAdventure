using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShipAdventure
{
    class Commander
    {
        public Ship playerShip { get; set; }
        public Commander()
        { }

        public void Game_Start()
        {
            //Initialise stuff
            // Create a new ship object

            //playerShip = new Ship();

        }

        public void GameTick()
        {

        }

        public void ProcessGameEvent(GameEvent TempEvent)
        {
            if (TempEvent.event_type == GameEvent.Event_Types.HitAstorid)
            {
                MessageBox.Show("Poo");
            }
        }

    }
}
