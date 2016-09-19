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

        public static List<IGameObject> getGameObjects(GamePosition TempPos, int Radius)
        {
            List<IGameObject> ScannedList = new List<SpaceshipCommander.IGameObject>();

            foreach (IGameObject tempObject in GameList)
            {
                if ((tempObject.getPositionX() <= (TempPos.X + Radius / 2)) &&
                    (tempObject.getPositionX() >= (TempPos.X - Radius / 2)) &&
                    (tempObject.getPositionY() <= (TempPos.Y + Radius / 2)) &&
                    (tempObject.getPositionY() >= (TempPos.Y - Radius / 2)))
                {
                    ScannedList.Add(tempObject);
                }
            }

            return ScannedList;
        }

    }
}
