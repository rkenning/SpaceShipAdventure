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

            //TODO Horrible hard coded level data, must replace with JSON level loader
            switch (tempLevel)
            {
                case 1:
                    leveldata.Add(new FinishGate(1000, 200));
                    break;
                case 2:
                    leveldata.Add(new Asteroid(710, 200));
                    leveldata.Add(new FinishGate(1000, 200));
                    break;
                case 3:
                    leveldata.Add(new Asteroid(500, 300));
                    leveldata.Add(new Asteroid(30, 300));
                    leveldata.Add(new Asteroid(410, 220));
                    leveldata.Add(new Asteroid(510, 220));
                    leveldata.Add(new Asteroid(610, 220));
                    leveldata.Add(new Asteroid(710, 220));
                    leveldata.Add(new FinishGate(1000, 200));
                    break;
            }
            return leveldata;
        }



    }
}
