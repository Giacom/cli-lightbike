using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lightbike
{
    static class HUD // Learn when best to use static classes
    {

        public static void CreateHUD()
        {

            Console.Clear();
            //Top Line
            Console.Write("┌");
            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                if (i != (Console.WindowWidth+60) / 2)
                {
                    Console.Write("─");
                }
                else
                {
                    Console.Write("┬");
                }
            }
            Console.Write("┐");
            //From top to bottom
            for (int i = 0; i < Console.WindowHeight - 3; i++)
            {
                Console.Write("│");
                for (int j = 0; j < Console.WindowWidth - 2; j++)
                {
                    if (j != (Console.WindowWidth+60) / 2)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("│");
                    }
                }
                Console.Write("│");
            }
            //Bottom line
            Console.Write("└");
            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                if (i != (Console.WindowWidth + 60) / 2)
                {
                    Console.Write("─");
                }
                else
                {
                    Console.Write("┴");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("┘");
            Console.CursorLeft = 100;
            Console.CursorTop = 2;
            Console.Write("Created by Giacom");
        }

        public static void ClearHUD()
        {
            Console.CursorTop = 1;
            Console.CursorLeft = 0;
            for (int i = 0; i < Console.WindowHeight - 3; i++)
            {
                Console.CursorLeft++;
                for (int j = 0; j < Console.WindowWidth - 2; j++)
                {
                    if (j != (Console.WindowWidth + 60) / 2)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.CursorLeft++;
                    }
                }
                Console.CursorTop++;
                Console.CursorLeft = 0;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = 100;
            Console.CursorTop = 2;
            Console.Write("Created by Giacom");
        }

    }
}
