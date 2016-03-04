using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{
    class GameEvent
    {
        public enum Event_Types
        {
            Astoride,
            HitAstorid,
            EdgeOfSpace,
            LaserHit,
            Stopped,
            Explode
        };

        public Event_Types event_type;
        public int laser_source_vector;

        public GameEvent(Event_Types event_type_)
            {
            event_type = event_type_;
            }


    }
}
