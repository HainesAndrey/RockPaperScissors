using System;

namespace Task3.Menu
{
    public class MenuCommand : IMenuCommand
    {
        public int Id { get; }
        public string Title { get; }
        public Action Action { get; }

        public MenuCommand(int id, string title, Action action)
        {
            Id = id;
            Title = title;
            Action = action;
        }

        public virtual void Execute() => Action?.Invoke();

        public override string ToString() => $"{Id} - {Title}";
    }
}
