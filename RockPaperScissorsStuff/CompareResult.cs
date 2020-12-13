using System.ComponentModel;

namespace Task3.RockPaperScissorsStuff
{
    public enum CompareResult
    {
        [Description("You win")]
        Win,

        [Description("You loose")]
        Loose,

        [Description("Draw")]
        Draw
    }
}
