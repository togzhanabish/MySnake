using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.Model
{
    [Serializable]
    public class food : Drawer
    {

        public food(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body)
        {
            SetRandomPosition();
        }

        public void SetRandomPosition()
        {
            int x = new Random().Next(0, 70);
            int y = new Random().Next(0, 35);

            body[0] = new Point(x, y);
            while(foodinwall(Game.wall) || foodinsnake(Game.snake))
            {
                x = new Random().Next(0, 70);
                y = new Random().Next(0, 35);

                body[0] = new Point(x, y);
            }


        }  
        public bool foodinwall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }

        public bool foodinsnake(Snake w)
        {
            foreach (Point p in w.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
    }
}