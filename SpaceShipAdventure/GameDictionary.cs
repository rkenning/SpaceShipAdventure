using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipCommander
{

    

    static class GameDictionary
    {
        public static List<IGameObject> GameList = new List<IGameObject>();

  
        public static void addGameObject(GameObject TempObject)
        {
            GameList.Add(TempObject);
        }

        public static List<IGameObject> getGameObjects()
        {
            return GameList;
        }

    }
}
