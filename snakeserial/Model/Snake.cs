using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MySnake.Model
{
    [Serializable]

    public class Snake : Drawer
    {

        public Snake(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body) { }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x > Console.WindowWidth)
                Game.GameOver = true;
            if (body[0].y > Console.WindowWidth)
                Game.GameOver = true;

            if (Game.snake.CollisionWithItSelf(Game.snake))
            {
                Console.Clear();
                Console.SetCursorPosition(30, 17);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("GAME OVER!");
                Game.GameOver = true;
                Console.ReadKey();
            }

            if (Game.snake.CanEat(Game.food))
            {
                Game.food.SetRandomPosition();
            }
            if (Game.snake.CollisionWithWall(Game.wall))
            {
                Game.GameOver = true;
                Console.Clear();
                Console.SetCursorPosition(30, 17);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("GAME OVER!");
                Console.ReadKey();
            }

        }

        public bool CanEat(food f)
        {
            if (body[0].x == f.body[0].x && body[0].y == f.body[0].y)
            {
                body.Add(new Point(f.body[0].x, f.body[0].y));
                Console.SetCursorPosition(f.body[0].x, f.body[0].y);
                Console.WriteLine(' ');
                return true;
            }
            return false;
        }

        public bool CollisionWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }    
        
        public bool CollisionWithItSelf(Snake s)
        {
            for(int i = 2; i < this.body.Count; i++)
            {
                if (this.body[0].x == this.body[i].x && this.body[0].y == this.body[i].y)
                    return true;
            }
            return false;
        }
    }
}