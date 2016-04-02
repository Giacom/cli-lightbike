using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.IO;*/

namespace Lightbike
{
    // Soounds removed for .NET Core
    static class Sound
    {
        static public bool CheckSounds()
        {/*
            if (File.Exists("Content\\select2.wav") & File.Exists("Content\\select.wav") & File.Exists("Content\\start.wav") & File.Exists("Content\\crash.wav"))
           {
               return true;
           }
           else
           {
               return false;
           }*/
           return false;
        }

        static public void PlaySelectedSound()
        {
            if (Lightbike.LightbikeMain.bSound == true)
            {
                /*
                SoundPlayer selectSound = new SoundPlayer("Content\\select2.wav");
                selectSound.Play();*/
                //System.Threading.Thread.Sleep(100);
            }
        }
        static public void PlaySelectionSound()
        {
            if (Lightbike.LightbikeMain.bSound == true)
            {
                /*
                SoundPlayer selectSound = new SoundPlayer("Content\\select.wav");
                selectSound.Play();*/
                //System.Threading.Thread.Sleep(100);
            }
        }
        static public void PlayStartSound()
        {
            if (Lightbike.LightbikeMain.bSound == true)
            {
                /*
                SoundPlayer selectSound = new SoundPlayer("Content\\start.wav");
                selectSound.Play();*/
                //System.Threading.Thread.Sleep(100);
            }
        }
        static public void PlayCrashSound()
        {
            if (Lightbike.LightbikeMain.bSound == true)
            {
                /*
                SoundPlayer selectSound = new SoundPlayer("Content\\crash.wav");
                selectSound.Play();*/
                //System.Threading.Thread.Sleep(100);
            }
        }
    }
}
