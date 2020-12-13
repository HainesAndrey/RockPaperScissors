using System.Collections.Generic;
using Task3.Menu;

namespace Task3
{
    public delegate void NeedToPrintMsgEventHandler(string msg);

    public interface IConsoleGame
    {
        bool NeedToPlay { get; }

        event NeedToPrintMsgEventHandler NeedToPrintMsg;

        bool Init(string[] args);
        void Play();
        void Stop();
    }
}
