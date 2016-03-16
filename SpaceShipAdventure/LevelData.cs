using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{
    class LevelData
    {
        private Asteroid[] Asteroids = new Asteroid[99];
        private FinishGate theFinish;

        public void LoadLevelData(int LevelNumber)
        {
            LevelLoader.LoadLevel(LevelNumber);
        }
    }
}
