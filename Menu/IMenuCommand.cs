using System;

namespace Task3.Menu
{
    public interface IMenuCommand
    {
        int Id { get; }
        string Title { get; }
        Action Action { get; }

        void Execute();
    }
}
