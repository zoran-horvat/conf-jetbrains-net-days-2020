using System;

namespace Demo
{
    public interface ISoundSink : IDisposable
    {
        void Append(byte[] uncompressed);
    }
}