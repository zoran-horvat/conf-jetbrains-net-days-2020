using System;
using System.IO;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo destination = new FileInfo("music.mp3");
            Func<ISoundSink> sinkFactory = () => new SoundPlayer(0);

            using (SoundEditor editor = new SoundEditor(sinkFactory))
            {
                editor.AddSilence(TimeSpan.FromSeconds(2));
                editor.GenerateTone();
                editor.AddSilence(TimeSpan.FromSeconds(2));
            }
        }
    }
}
