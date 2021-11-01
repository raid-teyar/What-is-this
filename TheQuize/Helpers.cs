using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TheQuize
{
    public class Helpers
    {
        public void PlayMusic(string path, float volume = 1, bool repeat = false)
        {
            if (repeat)
            {
                AudioFileReader mp3 = new AudioFileReader(path);
                DirectSoundOut waveOut = new DirectSoundOut();
                LoopStream loop = new LoopStream(mp3);
                waveOut.Init(loop);
                mp3.Volume = volume;
                waveOut.Play();
            }
            else
            {
                AudioFileReader mp3 = new AudioFileReader(path);
                DirectSoundOut waveOut = new DirectSoundOut();
                waveOut.Init(mp3);
                mp3.Volume = volume;
                waveOut.Play();
            }
        }
    }
}
