using System;
using Task3.Menu;
using Task3.RockPaperScissorsStuff;

namespace Task3
{
    class Program
    {
        private readonly static MenuWorker m_menu = new MenuWorker();
        private static IConsoleGame m_game;

        public static void Main(string[] args)
        {
            BuildGame();
            InitAndPlayGame(m_game, args);
            DestroyGame();
            Console.ReadKey();
        }

        private static void BuildGame()
        {
            m_game = new RockPaperScissors(m_menu);
            m_game.NeedToPrintMsg += PrintMsg;
        }

        private static void PrintMsg(string msg) =>
            Console.WriteLine(msg);

        private static void InitAndPlayGame(IConsoleGame game, string[] args)
        {
            if (game.Init(args))
                while (game.NeedToPlay)
                    game.Play();
        }

        private static void DestroyGame() =>
            m_game.NeedToPrintMsg -= PrintMsg;
    }
}
