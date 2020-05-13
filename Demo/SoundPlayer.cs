using System.Diagnostics;

namespace Demo
{
    class SoundPlayer : ISoundSink
    {
        private int DeviceId { get; }

        public SoundPlayer(int deviceId)
        {
            this.DeviceId = deviceId;
        }

        public void Append(byte[] uncompressed)
        {
            Debug.WriteLine($"Playing {uncompressed.Length} bytes on device #{this.DeviceId}");
        }

        public void Dispose() { }
    }
}