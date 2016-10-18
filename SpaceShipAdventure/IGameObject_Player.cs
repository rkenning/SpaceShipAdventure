using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceshipCommander
{
    interface IGameObject_Player
    {
        int getPositionX();
        int getPositionY();

        GamePosition GetPosition();
    }
}
