using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{
    class Iship_player
    {
        public int Power;
        public int direction;
        public int volicity { get; set; }
        public int engines { get; set; } // 1 on 0 off
        public string ShipName;


        public enum Status
        {
            Moving,
            HitAstorid,
            HitLaser,
            Stopped,
            Nothing,
            Explode
        };

        public Status ShipStatus { get; set; }

       // void set_status(Iship.Status status);
    }
}
