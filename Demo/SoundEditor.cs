using System;
using System.Diagnostics;

namespace Demo
{
    public class SoundEditor : IDisposable
    {
        private ISoundSink SoundSink { get; set; }
        private Func<ISoundSink> SinkFactory { get; }

        public SoundEditor(Func<ISoundSink> sinkFactory)
        {
            this.SinkFactory = sinkFactory;
        }

        public void GenerateTone()
        {
            byte[] raw = new byte[1_000_000];
            this.DoTheMagic(raw);
            this.GetSoundSink().Append(raw);
        }

        public void AddSilence(TimeSpan duration)
        {
            int samplesPerSec = 88200;
            int bytesPerSample = 2;
            int bytesCount = (int) (samplesPerSec * bytesPerSample * duration.TotalSeconds);
            byte[] silence = new byte[bytesCount];
            this.GetSoundSink().Append(silence);
        }

        private ISoundSink GetSoundSink()
        {
            this.SoundSink = this.SoundSink ?? this.SinkFactory();
            return this.SoundSink;
        }

        private void DoTheMagic(byte[] signal)
        {
            Debug.WriteLine("Generating tone...");
        }

        public void Dispose()
        {
            this.SoundSink?.Dispose();
        }
    }
}
