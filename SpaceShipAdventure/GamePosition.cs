using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{
    public class GamePosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GamePosition (int X_, int Y_)
        {
            X = X_;
            Y = Y_;
        }

    }
}
