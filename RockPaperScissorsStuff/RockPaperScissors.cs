using Ocura.Helper;
using System.Collections.Generic;
using System.Linq;
using Task3.Menu;
using Task3.Properties;

namespace Task3.RockPaperScissorsStuff
{
    public class RockPaperScissors : ConsoleGameBase
    {
        private IEnumerable<IFigure> m_figures;
        private IFigure m_userFigure;
        private readonly Bot m_bot;

        public RockPaperScissors(MenuWorker menu) : base(menu)
        {
            m_bot = new Bot();
        }

        public override bool Init(string[] args)
        {
            var result = ValidateAndSetFigures(args);
            if (result)
                SetFigures(args);
            else
                PrintMsg(Resources.ArgsErrorMsg);
            return result;
        }

        private bool ValidateAndSetFigures(string[] args) =>
            args.Length % 2 != 0 &&
            args.Length >= 3 &&
            args.Distinct().Count() == args.Length;

        private void SetFigures(string[] args)
        {
            m_figures = args.Select((arg, i) =>
                new Figure(i + 1, arg, args.Length));
            m_bot.SetFigures(m_figures);
            SetCommands();
        }

        private void SetCommands()
        {
            m_commands = m_figures.Select(it =>
                    new MenuCommand<IFigure>(it, () => m_userFigure = it))
                .ToList<IMenuCommand>();
            SetDefaultCommands();
        }

        public override void Play()
        {
            m_bot.MakeTurn();
            PrintMsg($"------New game------\nHMAC:\n{m_bot.Hmac}\n{m_menu}");
            if (m_menu.WaitAndExecuteCommand() && NeedToPlay)
                CheckWinner();
        }

        private void CheckWinner()
        {
            var result = m_userFigure.CompareTo(m_bot.SelectedFigure);
            var msg = $"Computer move: {m_bot.SelectedFigure.Name}\n" +
                $"{EnumHelper.Description(result)}\nHMAC key: {m_bot.Key}";
            PrintMsg(msg);
        }
    }
}
