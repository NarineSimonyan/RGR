using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    public class Program
    {
        public static void Main(string[] args)

        {
            int  FirstPlayerSize = 5;
            int SecondPlayerSize = 5;
            bool  Up = true; // Определяет, если направление мяча вверх
            bool Right = false; 
            int Player1 = 0;
            int Player2 = 0;
            Random randomGenerator = new Random();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Program pr = new Program();
           int[]  mass = pr.SetInitialPositions( FirstPlayerSize, SecondPlayerSize);
           // Console.Write("first{0}", mass[0]);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (mass[0] > 0)
                        {
                            mass[0]--;
                        }
                    }
                    else
                    {
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            if (mass[0] < Console.WindowHeight - FirstPlayerSize)
                            {
                                mass[0]++;
                            }
                        }
                    }
                }
                int randomNumber = randomGenerator.Next(1, 101);

                if (randomNumber <= 70)
                {
                    if ( Up == true)
                    {

                        if (mass[1] > 0)
                        {
                            mass[1]--;
                        }
                    }
                    else
                    {
                        if (mass[1] < Console.WindowHeight - SecondPlayerSize)
                        {
                            mass[1]++;
                        }
                    }
                }
                 if (mass[3] == 0)
               {
                 Up = false;
                }
            if (mass[3] == Console.WindowHeight - 1)
            {
                 Up = true;
            }
            if (mass[2] == Console.WindowWidth - 1)
            {
               mass[2] = Console.WindowWidth / 2;
               mass[3] = Console.WindowHeight / 2;
               Right = false;
                 Up = true;
                Player1++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Player 1 wins!");
                Console.ReadKey();
            }
            if (mass[2] == 0)
                {
                    mass[2] = Console.WindowWidth / 2;
                    mass[3] = Console.WindowHeight / 2;
                    Right = true;
                 Up = true;
                Player2++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Player 2 wins!");
                Console.ReadKey();
            }

            if (mass[2] < 3)
            {
                if ((mass[3] >= mass[0])&& (mass[3] < mass[0] +FirstPlayerSize))
                {
                    Right = true;
                }
            }

            if (mass[2] >= Console.WindowWidth - 3 - 1)
            {
                if (mass[3] >= mass[1]
                    && mass[3] < mass[1] + SecondPlayerSize)
                {
                    Right = false;
                }
            }

            if ( Up)
            {
                    mass[3]--;
            }
            else
            {
                    mass[3]++;
            }


            if (Right)
            {
                    mass[2]++;
            }
            else
            {
                    mass[2]--;
            }
               Console.Clear();
                for (int y = mass[0]; y < mass[0] +FirstPlayerSize; y++)
                {
                    Position(0, y, '|');
                    Position(1, y, '|');
                }

                for (int y = mass[1]; y < mass[1] + SecondPlayerSize; y++)
                {
                    Position(Console.WindowWidth - 1, y, '|');
                    Position(Console.WindowWidth - 2, y, '|');
                }
                Position(mass[2],mass[3],'O');
                Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
                Console.Write("{0}-{1}", Player1, Player2);
                Thread.Sleep(60);
            }
        }
        public static void Position(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        public int[] SetInitialPositions(int FirstPlayerSize,int SecondPlayerSize)
        {
            int firstPlayerPosition = 0;
            int secondPlayerPosition = 0;
            firstPlayerPosition = Console.WindowHeight  -FirstPlayerSize ;
             
            secondPlayerPosition = Console.WindowHeight - SecondPlayerSize ;
           int X = Console.WindowWidth / 2;
           int Y= Console.WindowHeight / 2;
            int[] mass = { firstPlayerPosition, secondPlayerPosition, X, Y};
            return mass;
        }
 
        
    }
}
