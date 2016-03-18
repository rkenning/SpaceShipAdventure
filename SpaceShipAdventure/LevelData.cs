using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{
    class Level
    {
        public List<Asteroid> Asteroids = new List<Asteroid>();
        public FinishGate theFinish;

        List<object> levelData;

        public void PopulateLevelData(int LevelNumber)
        {
            levelData = LevelLoader.LoadLevel(LevelNumber);

            foreach (object temp in levelData)
            {
                if (temp.GetType() == typeof(Asteroid))
                {
                    Asteroid tmpAst = (Asteroid)temp;
                    Asteroids.Add(tmpAst);
                }
                if (temp.GetType() == typeof(FinishGate))
                {
                    theFinish = (FinishGate)temp;
                }

            }


        }
    }
}
