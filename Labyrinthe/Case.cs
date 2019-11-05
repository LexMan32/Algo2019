using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe
{
    class Case
    {
        public bool IsVisited { get; set; }
        public List<Wall> ListWalls { get;}


        public Case()
        {
            ListWalls.Add(Wall.DOWN);
            ListWalls.Add(Wall.UP);
            ListWalls.Add(Wall.RIGHT);
            ListWalls.Add(Wall.LEFT);
        }

        public void RemoveWall(Wall wall)
        {
            ListWalls.Remove(wall);
        }
    }
}
