using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using EZInput;
using Game.maze;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
        

        // ConsoleUtils Get = new ConsoleUtils();
        maze_ v = new maze_();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (i == 0 || i == 30-1 || j == 0 || j == 99)
                        v.maze__[i, j] = "#";
                    else
                        v.maze__[i, j] =" ";
                    
                }
            }
            int option = 0;
            Console.Write("1.Play");
            Console.WriteLine(" ");
            Console.WriteLine("2.Instructions");
            option = int.Parse(Console.ReadLine());
            
             if (option == 1)
                play(v);
        }
        static void play(maze_ v)
        {
            Console.Clear();
         int x = 15;
         int y = 15;
            mazef(v);
          //  Console.ReadKey();
           // Thread.Sleep(1000);
            player(ref x,ref y,v);

        }
         /*static string[,] maze()
        {

                string[,] maze_ = new string[34, 100];
            for (int row = 0; row < 34; row++)
            {
                for (int column = 0; column < 100; column++)
                {
                    if (row == 0 || row == 33 || column == 0 || column == 99)
                    {
                        Console.Write("#");
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            return maze_;
        }*/

        static void player(ref int x,ref int y,maze_ v)
        {
            int b = 0;
            int t = 0;
            bool running = false;
            int i = 2;
            bool run = false;
            int j = x;
            int count = 0;
            int n = 5;
            player_char(x, y, v, n);
            while (true)
            {
                /*b = x;
                t = y;*/
              //  
              if ((Keyboard.IsKeyPressed(Key.Space)|| run==true))
                {
                    
                    bullet(ref t,ref b, x, y,ref run,v);
                    
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveup(ref x, ref y, v);
                    //run = false;
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                   // run = false;
                    movedown(ref x, ref y, v);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                   // run = false;
                    moveleft(ref x, ref y, v);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                   // run = false;
                    moveright(ref x, ref y, v);
                }
                count++;
                /*if(run==true)
                {
                    Thread.Sleep(50);
                }*/
                if (count == 3)
                {
                    enemy(ref count, ref i, ref j,ref running,v);
                }
                Thread.Sleep(100);
            }
                   // Console.ReadKey();
                
            
        }
        static void bullet( ref int t,ref int b,int x,int y,ref bool run, maze_ v)
        {
            
            if (run == false)
            {
                 b = x;
                 t = y;
                run = true;
            }
            if (v.maze__[t - 1, b] == " ")
            {
                
                Console.SetCursorPosition(b, t);
                Console.Write(".");
                Console.SetCursorPosition(b, t+1);
                Console.Write(" "); 
                t--;
                Thread.Sleep(50);
                
            }
            /*else if(v.maze__[t - 1, b] == "#")
            {
                Console.SetCursorPosition(b, t + 1);
                Console.Write(" ");
                run = false;
            }*/
            else
            {
                Console.SetCursorPosition(b, t+1);
                Console.Write(" ");
                run = false;
                
            }
           /* if(v.maze__[t - 1, b] != "#")
            {
               *//* Console.SetCursorPosition(10, 10);

                Console.WriteLine("Runned");*//*
                Console.SetCursorPosition(b, t);
                Console.Write(" ");
                run = false;
            }*/

        }
        static void player_char(int x, int y,maze_ v, int n)
        {
            Console.SetCursorPosition(x, y);
                Console.WriteLine(" .");
                Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("||");
            if (n == 0 || n==1 ||n==2 ||n==3 || n==4)
            {
                v.maze__[y, x] = ".";
                v.maze__[y + 1, x] = "||";
            }           
            Console.ReadKey();
        }
        static void moveup(ref int x, ref int y,maze_ v)
        {
            if (v.maze__[y - 1,x] != "#")
            {
                int n = 1;
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine("  ");
                v.maze__[y + 1, x]=" ";
                    y--;
                player_char(x, y, v, n);
               // Thread.Sleep(100);
            }
        }
       
        static void movedown(ref int x, ref int y,maze_ v)
        {
           /* Console.SetCursorPosition(y + 1, x);
            Console.WriteLine(y);*/
            if (v.maze__[y + 3, x] != "#")
            {
                int n = 2;
                Console.SetCursorPosition(x+1, y);
                Console.WriteLine(" ");
                v.maze__[y, x + 1] = " ";
                y+=1;
                player_char(x, y, v, n);
             //   Thread.Sleep(100);
            }
        }
        static void moveright(ref int x, ref int y,maze_ v)
        {
            if (v.maze__[y, x + 2] != "#")
            {
                int n = 3;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" ");
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine(" ");
                v.maze__[y, x] = " ";
                v.maze__[y + 1, x] = " ";
                    x += 1;
                player_char(x, y, v, n);
             //   Thread.Sleep(100);
            }
        }
        static void moveleft(ref int x, ref int y, maze_ v)
        {
           /* Console.SetCursorPosition(y, x - 1);
            Console.WriteLine(x);*/
            if (v.maze__[y, x - 1] != "#")
            {
                int n = 4;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("  ");
                Console.SetCursorPosition(x + 1, y + 1);
                Console.WriteLine(" ");
                v.maze__[y, x] = "  ";
                v.maze__[y + 1, x + 1] = " ";
                    x -= 1;
                player_char(x, y, v, n);
              //  Thread.Sleep(100);
            }
        }
        static void enemy(ref int count,ref int x,ref int y,ref bool running,maze_ v)
        {
            /*Console.SetCursorPosition(97,10);
            Console.Write(x);
*/
            if (x < 96 && running==false)
            {
                Console.SetCursorPosition(x, 3);
                Console.WriteLine("||");
                v.maze__[3, x]="||";
                Console.SetCursorPosition(x, 4);
                Console.WriteLine(".");
                v.maze__[4, x] = ".";
                Console.SetCursorPosition(x - 1, 3);
                Console.WriteLine(" ");
                v.maze__[3, x - 1] = " ";
                Console.SetCursorPosition(x - 1, 4);
                Console.WriteLine(" ");
                v.maze__[4,x-1] = " ";
                Thread.Sleep(100);
                x++;
                count = 0;
            }
                 else if (x <= 96)
                    {
                running = true;
                        
                            Console.SetCursorPosition(x, 3);
                            Console.WriteLine("||");
                v.maze__[3, x]="||";
                            Console.SetCursorPosition(x, 4);
                            Console.WriteLine(".");
                v.maze__[4, x] = ".";
                            Console.SetCursorPosition(x +2, 3);
                            Console.WriteLine(" ");
                v.maze__[3, x + 2] = " ";
                            Console.SetCursorPosition(x + 1, 4);
                            Console.WriteLine(" ");
                v.maze__[4, x + 1] = " ";
                            Thread.Sleep(100);
                            x--;
                if(x==2)
                {
                    running = false;
                }
                    count = 0;
                    }
                    
                
            
        }
        static void mazef(maze_ v)
        {
            for (int i = 0; i < v.maze__.GetLength(0); i++)
            {
                for (int j = 0; j < v.maze__.GetLength(1); j++)
                {
                    Console.Write(v.maze__[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

    }
