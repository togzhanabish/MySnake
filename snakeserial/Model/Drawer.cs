using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.Model
{
    [Serializable]
    public class Drawer
    {
        public ConsoleColor color;
        public List<Point> body = new List<Point>();
        public char sign;

        public Drawer() { }

        public Drawer(ConsoleColor color, char sign, List<Point> body)
        {
            this.body = body;
            this.color = color;
            this.sign = sign;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            for(int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }

        public void save()
        {
            Type t = this.GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }                                                           

        public void resume()
        {
            Type t = this.GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            if(t == typeof(Wall))
                Game.wall = bf.Deserialize(fs) as Wall;
            if (t == typeof(Snake))
                Game.snake = bf.Deserialize(fs) as Snake;
            if (t == typeof(food))
                Game.food = bf.Deserialize(fs) as food;
            fs.Close();
        }
    }
}