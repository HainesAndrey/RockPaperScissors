using System;
using Task3.RockPaperScissorsStuff;

namespace Task3.Menu
{
    public class MenuCommand<T> : MenuCommand where T: IFigure
    {
        public T Figure { get; set; }

        public MenuCommand(T figure, Action action) : base(figure.Id, figure.Name, action)
        {
            Figure = figure;
        }

        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("Your move: " + Title);
        }
    }
}
