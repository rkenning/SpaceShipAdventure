using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{
    


    static class LevelLoader
    {
        
        //Loads Finish details & Astorides

        public static List<object> LoadLevel(int tempLevel)
        {
            List<object> leveldata = new List<object>();

            leveldata.Add(new Asteroid(500, 300));
            leveldata.Add(new Asteroid(1300, 300));
            leveldata.Add(new Asteroid(410, 220));
            leveldata.Add(new FinishGate(1000, 300));
            return leveldata;
        }

        

    }
}
