using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lightbike
{
    class Menu
    {
        public int iMenuCount = 0;

        public int StartMenu(int iSelection = 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int iIndentX = (Console.WindowWidth / 2) - 30;
            //Start menu
            WriteMenuAtPos("◄", iIndentX + 20, iSelection + 10, false);
            WriteMenuAtPos("Singleplayer", iIndentX, 10);
            WriteMenuAtPos("Multiplayer", iIndentX, 11);
            WriteMenuAtPos(Lightbike.LightbikeMain.sGamemode, iIndentX, 12);
            if (Lightbike.LightbikeMain.bSound)
            {
                WriteMenuAtPos("Sound On", iIndentX, 13);
            }
            else
            {
                WriteMenuAtPos("Sound Off", iIndentX, 13);
            }
            WriteMenuAtPos("Exit", iIndentX, 14);



            //Get user input
            bool bContinue = false;
            while (bContinue == false)
            {
                int iOldSelection = iSelection;
                ConsoleKeyInfo ckiKey;
                ckiKey = Console.ReadKey(true);
 
                switch (ckiKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            Sound.PlaySelectionSound();
                            if (iSelection != 0)
                            {
                                iSelection--;
                            }
                            else
                            {
                                iSelection = iMenuCount-1;
                            }
                            
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            Sound.PlaySelectionSound();

                            if (iSelection != iMenuCount-1)
                            {
                                iSelection++;
                            }
                            else
                            {
                                iSelection = 0;
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Sound.PlaySelectedSound();
                            bContinue = true;
                            break;
                        }
                }
                if (iOldSelection != iSelection)
                {
                    WriteMenuAtPos("◄", iIndentX + 20, iSelection + 10, false);
                    WriteMenuAtPos("   ", iIndentX + 20, iOldSelection + 10, false);
                }
            }
            return iSelection;
        }

        public void WriteMenuAtPos(string Text, int X = -1, int Y = -1, bool menu = true)
        {
            if (X != -1)
            {
                Console.CursorLeft = X;
            }
            if (Y != -1)
            {
                Console.CursorTop = Y;
            }
            Console.Write(Text);
            if (menu == true)
            {
                this.iMenuCount++;
            }

        }
    }
}
