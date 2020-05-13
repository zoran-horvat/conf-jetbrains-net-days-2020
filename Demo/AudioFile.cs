using System.Diagnostics;
using System.IO;

namespace Demo
{
    class AudioFile : ISoundSink
    {
        private FileInfo Destination { get; }

        public AudioFile(FileInfo destination)
        {
            this.Destination = destination;
        }

        public void Append(byte[] uncompressed)
        {
            byte[] compressed = this.Compress(uncompressed);
            Debug.WriteLine($"Writing compressed sound to {this.Destination.Name}");
            File.WriteAllBytes(this.Destination.FullName, compressed);
        }

        private byte[] Compress(byte[] sound)
        {
            Debug.WriteLine($"Compressing {sound.Length} bytes of sound");
            return sound;
        }

        public void Dispose() { }
    }
}