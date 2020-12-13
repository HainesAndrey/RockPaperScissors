using System.Collections.Generic;
using System.Linq;
using Task3.Menu;

namespace Task3
{
    public abstract class ConsoleGameBase : IConsoleGame
    {
        protected MenuWorker m_menu;
        protected List<IMenuCommand> m_commands;
        public bool NeedToPlay { get; private set; }

        public event NeedToPrintMsgEventHandler NeedToPrintMsg;

        public ConsoleGameBase(MenuWorker menu)
        {
            NeedToPlay = true;
            m_menu = menu;
        }

        public abstract bool Init(string[] args);
        public abstract void Play();
        public virtual void Stop() => NeedToPlay = false;
        protected void PrintMsg(string msg) => NeedToPrintMsg?.Invoke(msg);

        protected virtual void SetDefaultCommands()
        {
            m_commands.Add(new MenuCommand(0, "exit", Stop));
            m_menu.SetCommands(m_commands);
        }
    }
}
