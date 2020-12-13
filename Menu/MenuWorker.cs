using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3.Menu
{
    public class MenuWorker
    {
        private readonly List<IMenuCommand> m_commands = new List<IMenuCommand>();

        public void SetCommands(List<IMenuCommand> commands)
        {
            m_commands.Clear();
            m_commands.AddRange(commands);
        }
            
        public bool WaitAndExecuteCommand()
        {
            var cmdId = InputCommandId();
            if (m_commands.FirstOrDefault(x => x.Id == cmdId) is IMenuCommand cmd)
            {
                cmd.Execute();
                return true;
            }
            return false;
        }
            
        private int? InputCommandId()
        {
            Console.Write("Enter your move: ");
            var cmd = GetCommandById(Console.ReadLine());
            return cmd?.Id;
        }

        private IMenuCommand GetCommandById(string idString)
        {
            if (int.TryParse(idString, out var id))
            {
                return m_commands.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public override string ToString() =>
            "Available moves:\n" + string.Join("\n", m_commands);
    }
}
