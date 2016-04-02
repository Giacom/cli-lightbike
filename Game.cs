using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Timers;

namespace Lightbike
{
    class Game
    {
 
        private bool bGameOver = false;

        List<int> PrevX = new List<int>();
        List<int> PrevY = new List<int>();

        private int BikeX = 48;
        private int BikeY = 28;

        private int Bike2X = 48;
        private int Bike2Y = 29;

        private int GameSpeed = 40;
        bool dashOn1 = true;
        bool dashOn2 = true;
        public void StartGame()
        {
            long playerScore = 0;
            Lightbike.HUD.ClearHUD();
            ConsoleKeyInfo ckiKey;
            int iDirection = 0; // 0 = north, 1 = east, 2 = south, 3 = west
            int iOldDirection = 0;
            bool bCooldown = false; // true when there's a cooldown

            PrevX.Add(BikeX);
            PrevY.Add(BikeY);

            Console.CursorLeft = BikeX;
            Console.CursorTop = BikeY;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▲");
            Console.ReadKey(true);
            Sound.PlayStartSound();
            while (bGameOver == false)
            {
                while (Console.KeyAvailable == false)
                {
                    MoveBike(iDirection, iOldDirection);
                    iOldDirection = iDirection;
                    if (bGameOver == true)
                    {
                        break;
                    }

                    // System.Threading.Thread.Sleep(GameSpeed); // Commented out for .NET Core
                    Task.Delay(TimeSpan.FromMilliseconds(GameSpeed)).Wait(); // Comment out for normal .NET
                    playerScore += GameSpeed;
                }
                if (bGameOver == true)
                {
                    break;
                }

                if (bCooldown == false)
                {
                    ckiKey = Console.ReadKey(true);
                    bCooldown = true;

                    switch (ckiKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                if (iDirection != 2)
                                {
                                    iDirection = 0;
                                }
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (iDirection != 3)
                                {
                                    iDirection = 1;
                                }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (iDirection != 0)
                                {
                                    iDirection = 2;
                                }
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                if (iDirection != 1)
                                {
                                    iDirection = 3;
                                }
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                bGameOver = true;
                                break;
                            }
                    }
                    //MoveBike(iDirection, iOldDirection, false); haha don't
                }
                else
                {
                    bCooldown = false; 
                }
            }
            Sound.PlayCrashSound();
            ConsoleKeyInfo keyContinue = Console.ReadKey(true);
            while (keyContinue.Key != ConsoleKey.Enter)
            {
                keyContinue = Console.ReadKey(true);
            }
            Sound.PlaySelectedSound();
        }

        public void StartVersus()
        {
            Lightbike.HUD.ClearHUD();
            ConsoleKeyInfo ckiKey;
            int iDirection = 0; // 0 = north, 1 = east, 2 = south, 3 = west
            int iOldDirection = 0;
            bool bCooldown = false; // true when there's a cooldown

            int iDirection2 = 2; // 0 = north, 1 = east, 2 = south, 3 = west
            int iOldDirection2 = 2;
            bool bCooldown2 = false; // true when there's a cooldown

            PrevX.Add(BikeX);
            PrevY.Add(BikeY);
            PrevX.Add(Bike2X);
            PrevY.Add(Bike2Y);

            //I didn't know about the structures until I implemented the two lists with the X and Y axis stored in the list.
            //I could've done it much better and I could've organized the code much more. Maybe even start with multiplayer in mind
            //because I didn't do it in the start. Even a player class would've been a good idea. Oh well, maybe I can now do it in
            //XNA instead. First I will create a platformer that will help me learn and improve my programming skills.

            Console.CursorLeft = BikeX;
            Console.CursorTop = BikeY;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▲");

            Console.CursorLeft = Bike2X;
            Console.CursorTop = Bike2Y;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("▼");
            Console.ReadKey(true);
            Sound.PlayStartSound();

            while (bGameOver == false)
            {
                while (Console.KeyAvailable == false)
                {
                    MoveBike(iDirection, iOldDirection, false);
                    MoveBike(iDirection2, iOldDirection2, true);
                    iOldDirection = iDirection;
                    iOldDirection2 = iDirection2;
                    if (bGameOver == true)
                    {
                        break;
                    }
                    bCooldown = false;
                    bCooldown2 = false;
                    //System.Threading.Thread.Sleep(GameSpeed); // Commented out for .NET Core
                    Task.Delay(TimeSpan.FromMilliseconds(GameSpeed)).Wait(); // Comment out for normal .NET
                }

                if (bGameOver == true)
                {
                    break;
                }
 
                ckiKey = Console.ReadKey(true);
                if (bCooldown == false)
                {
                    switch (ckiKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                if (iDirection != 2)
                                {
                                    iDirection = 0;
                                }
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (iDirection != 3)
                                {
                                    iDirection = 1;
                                }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (iDirection != 0)
                                {
                                    iDirection = 2;
                                }
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                if (iDirection != 1)
                                {
                                    iDirection = 3;
                                }
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                bGameOver = true;
                                break;
                            }
                    }
                }
                else
                {
                    bCooldown = false;
                }

                if (bCooldown2 == false)
                {
                    switch (ckiKey.Key)
                    {
                        case ConsoleKey.W:
                            {
                                if (iDirection2 != 2)
                                {
                                    iDirection2 = 0;
                                }
                                break;
                            }
                        case ConsoleKey.D:
                            {
                                if (iDirection2 != 3)
                                {
                                    iDirection2 = 1;
                                }
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                if (iDirection2 != 0)
                                {
                                    iDirection2 = 2;
                                }
                                break;
                            }
                        case ConsoleKey.A:
                            {
                                if (iDirection2 != 1)
                                {
                                    iDirection2 = 3;
                                }
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                bGameOver = true;
                                break;
                            }
                    }
                }
                {
                    bCooldown2 = false;
                }

            }
            Sound.PlayCrashSound();
            ConsoleKeyInfo keyContinue = Console.ReadKey(true);
            while (keyContinue.Key != ConsoleKey.Enter)
            {
                keyContinue = Console.ReadKey(true);
            }
            Sound.PlaySelectedSound();
        
        }

        public bool IsPrevPos(int X, int Y)
        {
            for (int i = 0; i < PrevX.Count-1; i++)
            {
                if (PrevX[i] == X && PrevY[i] == Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void MoveBike(int iDirection, int iOldDirection, bool SecondPlayer = false)
        {
            if (SecondPlayer == false)
            {
                Console.CursorTop = BikeY;
                Console.CursorLeft = BikeX;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.CursorTop = Bike2Y;
                Console.CursorLeft = Bike2X;
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            if (SecondPlayer == false)
            {
                if ((!Lightbike.LightbikeMain.sGamemode.Equals("Mixed") & !Lightbike.LightbikeMain.sGamemode.Equals("Dashed")) | dashOn1 == true)
                {
                    dashOn1 = false;
                    switch (iDirection)
                    {
                        case 0:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 1) // Right
                                    {
                                        Console.Write("┘");
                                    }
                                    else if (iOldDirection == 3)
                                    {
                                        Console.Write("└");
                                    }
                                }
                                else
                                {
                                    Console.Write("│");
                                }
                                break;
                            }
                        case 1:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 0)
                                    {
                                        Console.Write("┌");
                                    }
                                    else if (iOldDirection == 2)
                                    {
                                        Console.Write("└");
                                    }
                                }
                                else
                                {
                                    Console.Write("─");
                                }
                                break;
                            }
                        case 2:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 1)
                                    {
                                        Console.Write("┐");
                                    }
                                    else if (iOldDirection == 3)
                                    {
                                        Console.Write("┌");
                                    }
                                }
                                else
                                {
                                    Console.Write("│");
                                }
                                break;
                            }

                        case 3:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 0)
                                    {
                                        Console.Write("┐");
                                    }
                                    else if (iOldDirection == 2)
                                    {
                                        Console.Write("┘");
                                    }
                                }
                                else
                                {
                                    Console.Write("─");
                                }
                                break;
                            }

                    }
                }
                else
                {
                    Console.Write(" ");
                    dashOn1 = true;
                }
            }
            else
            {
                if ((!Lightbike.LightbikeMain.sGamemode.Equals("Mixed") & !Lightbike.LightbikeMain.sGamemode.Equals("Dashed")) | dashOn2 == true)
                {
                    dashOn2 = false;
                    switch (iDirection)
                    {
                        case 0:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 1) // Right
                                    {
                                        Console.Write("┘");
                                    }
                                    else if (iOldDirection == 3)
                                    {
                                        Console.Write("└");
                                    }
                                }
                                else
                                {
                                    Console.Write("│");
                                }
                                break;
                            }
                        case 1:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 0)
                                    {
                                        Console.Write("┌");
                                    }
                                    else if (iOldDirection == 2)
                                    {
                                        Console.Write("└");
                                    }
                                }
                                else
                                {
                                    Console.Write("─");
                                }
                                break;
                            }
                        case 2:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 1)
                                    {
                                        Console.Write("┐");
                                    }
                                    else if (iOldDirection == 3)
                                    {
                                        Console.Write("┌");
                                    }
                                }
                                else
                                {
                                    Console.Write("│");
                                }
                                break;
                            }

                        case 3:
                            {
                                if (iDirection != iOldDirection)
                                {
                                    if (iOldDirection == 0)
                                    {
                                        Console.Write("┐");
                                    }
                                    else if (iOldDirection == 2)
                                    {
                                        Console.Write("┘");
                                    }
                                }
                                else
                                {
                                    Console.Write("─");
                                }
                                break;
                            }

                    }
                }
                else
                {
                    Console.Write(" ");
                    dashOn2 = true;
                }
            }
            switch (iDirection)
            {
                case 0:
                    {
                        if (!SecondPlayer)
                        {
                            BikeY--;
                        }
                        else
                        {
                            Bike2Y--;
                        }
                        break;
                    }
                case 1:
                    {
                        if (!SecondPlayer)
                        {
                            BikeX++;
                        }
                        else
                        {
                            Bike2X++;
                        }
                        break;
                    }
                case 2:
                    {
                        if (!SecondPlayer)
                        {
                            BikeY++;
                        }
                        else
                        {
                            Bike2Y++;
                        }
                        break;
                    }
                case 3:
                    {
                        if (!SecondPlayer)
                        {
                            BikeX--;
                        }
                        else
                        {
                            Bike2X--;
                        }
                        break;
                    }
            }
            if (!SecondPlayer)
            {
                if (BikeY == 0 || BikeY == Console.WindowHeight - 2 || BikeX == 0 || BikeX == (Console.WindowWidth + 60) / 2)
                {
                    if (Lightbike.LightbikeMain.sGamemode.Equals("No Walls") || Lightbike.LightbikeMain.sGamemode.Equals("Mixed"))
                    {
                        if (BikeY == 0)
                        {
                            BikeY = Console.WindowHeight - 3;
                        }
                        else if (BikeY == Console.WindowHeight - 2)
                        {
                            BikeY = 1;
                        }
                        else if (BikeX == 0)
                        {
                            BikeX = (Console.WindowWidth + 60) / 2 - 1;
                        }
                        else if (BikeX == (Console.WindowWidth + 60) / 2)
                        {
                            BikeX = 1;
                        }
                        MoveBike(iDirection, iOldDirection, false);
                        return;
                    }
                    else
                    {
                        bGameOver = true;
                    }
                }
                else if (IsPrevPos(BikeX, BikeY))
                {
                    bGameOver = true;
                }
                else
                {
                    Console.CursorTop = BikeY;
                    Console.CursorLeft = BikeX;
                    Console.ForegroundColor = ConsoleColor.Red;
                    switch (iDirection)
                    {
                        case 0:
                            {
                                Console.Write("▲");
                                break;
                            }
                        case 1:
                            {
                                Console.Write("►");
                                break;
                            }
                        case 2:
                            {
                                Console.Write("▼");
                                break;
                            }
                        case 3:
                            {
                                Console.Write("◄");
                                break;
                            }
                    }
                    if ((!Lightbike.LightbikeMain.sGamemode.Equals("Mixed") & !Lightbike.LightbikeMain.sGamemode.Equals("Dashed")) | dashOn1 == true)
                    {
                        PrevX.Add(BikeX);
                        PrevY.Add(BikeY);
                    }

                }
            }
            else
            {
                if (Bike2Y == 0 || Bike2Y == Console.WindowHeight - 2 || Bike2X == 0 || Bike2X == (Console.WindowWidth + 60) / 2)
                {
                    if (Lightbike.LightbikeMain.sGamemode.Equals("No Walls") || Lightbike.LightbikeMain.sGamemode.Equals("Mixed"))
                    {
                        if (Bike2Y == 0)
                        {
                            Bike2Y = Console.WindowHeight - 3;
                        }
                        else if (Bike2Y == Console.WindowHeight - 2)
                        {
                            Bike2Y = 1;
                        }
                        else if (Bike2X == 0)
                        {
                            Bike2X = (Console.WindowWidth + 60) / 2 - 1;
                        }
                        else if (Bike2X == (Console.WindowWidth + 60) / 2)
                        {
                            Bike2X = 1;
                        }
                        MoveBike(iDirection, iOldDirection, true);
                        return;
                    }
                    else
                    {
                        bGameOver = true;
                    }
                }
                else if (IsPrevPos(Bike2X, Bike2Y))
                {
                    bGameOver = true;
                }
                else
                {
                    Console.CursorTop = Bike2Y;
                    Console.CursorLeft = Bike2X;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    switch (iDirection)
                    {
                        case 0:
                            {
                                Console.Write("▲");
                                break;
                            }
                        case 1:
                            {
                                Console.Write("►");
                                break;
                            }
                        case 2:
                            {
                                Console.Write("▼");
                                break;
                            }
                        case 3:
                            {
                                Console.Write("◄");
                                break;
                            }
                    }
                    if ((!Lightbike.LightbikeMain.sGamemode.Equals("Mixed") & !Lightbike.LightbikeMain.sGamemode.Equals("Dashed")) | dashOn2 == true)
                    {
                        PrevX.Add(Bike2X);
                        PrevY.Add(Bike2Y);
                    }
                }
            }
        }
    }
}
