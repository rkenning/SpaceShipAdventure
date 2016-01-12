using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShipAdventure
{
    class Player : Ship
    {

        public new void collide_action(Ship.Collide_Object temp1)
        {
            if (temp1 == Ship.Collide_Object.Astoride)
            {
                MessageBox.Show("A hit!");
            }
        }
    }
}
