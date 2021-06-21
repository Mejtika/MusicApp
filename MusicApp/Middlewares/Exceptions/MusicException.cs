using System;

namespace MusicApp.Middlewares.Exceptions
{
    public abstract class MusicException : Exception
    {
        protected MusicException(string message) : base(message)
        {
        }
    }
}
