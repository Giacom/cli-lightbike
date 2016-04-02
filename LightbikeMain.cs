using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Media;

namespace Lightbike
{
    class LightbikeMain
    {
        public static string sGamemode = "Standard";
        public static bool bSound = true;

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int iSelection = 0;
            bool bExit = false;
            //Console.SetWindowSize(128, 64);
            Console.CursorVisible = false;  
            Console.Title = "LightBike";
            if (Sound.CheckSounds())
            {
                Sound.PlayStartSound();
            }
            else
            {
                bSound = false;
            }
            //Add console position
            Lightbike.HUD.CreateHUD();
            while (bExit == false)
            {
                Menu menu = new Menu();
                iSelection = menu.StartMenu(iSelection);
                switch (iSelection)
                {
                    case 0: //Singleplayer
                        {
                            Game game = new Game();
                            game.StartGame();

                            break;
                        }
                    case 1: //Multiplayer
                        {
                            Game game = new Game();
                            game.StartVersus();
                            break;
                        }
                    case 2: //Mode
                        {
                            if (sGamemode == "Standard")
                            {
                                sGamemode = "Dashed";
                            }
                            else if (sGamemode == "Dashed")
                            {
                                sGamemode = "No Walls";
                            }
                            else if (sGamemode == "No Walls")
                            {
                                sGamemode = "Mixed";
                            }
                            else
                            {
                                sGamemode = "Standard";
                            }
                            break;
                        }
                    case 3:
                        {
                            if (bSound)
                            {
                                bSound = false;
                            }
                            else if (Sound.CheckSounds())
                            {
                                bSound = true;
                            }
                            break;
                        }
                    default:
                        {
                            bExit = true;
                            break;
                        }
                }
                Lightbike.HUD.ClearHUD();
            }
        }
    }
}
