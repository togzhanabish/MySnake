using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySnake.Model;
using System.Threading;

namespace MySnake
{
    class Program
    {
        public static int d = 0;

        static void MoveSnake()
        {
            while(!Game.GameOver)
            {
                Game.Draw();
                switch(d)
                {
                    case 0:
                        Game.snake.Move(1, 0);
                        break;
                    case 1:
                        Game.snake.Move(0, 1);
                        break;
                    case 2:
                        Game.snake.Move(-1, 0);
                        break;
                    case 3:
                        Game.snake.Move(0, -1);
                        break;
                }
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            Game.Init();

            Thread t = new Thread(MoveSnake);

            t.Start();

            while (!Game.GameOver)
            {
                Game.Draw();

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        d = 3;
                        break;
                    case ConsoleKey.DownArrow:
                        d = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        d = 2;
                        break;
                    case ConsoleKey.RightArrow:
                        d = 0;
                        break;
                    case ConsoleKey.Escape:
                        Game.GameOver = true;
                        break;
                    case ConsoleKey.F2:
                        Game.snake.save();
                        break;
                    case ConsoleKey.F3:
                        Game.snake.resume();
                        break;
                }

                if (Game.snake.body.Count == 10)
                {
                    Game.wall.LoadLevel(3);
                }
                if (Game.snake.body.Count == 20)
                {
                    Game.wall.LoadLevel(4);
                }
                if(Game.snake.body.Count == 30)
                {
                    Game.wall.LoadLevel(5);
                }

            }

            }
        }
    }