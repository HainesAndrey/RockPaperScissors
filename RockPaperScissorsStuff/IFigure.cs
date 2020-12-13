using System.Collections.Generic;

namespace Task3.RockPaperScissorsStuff
{
    public interface IFigure
    {
        int Id { get; }
        string Name { get; }
        IReadOnlyCollection<int> DominantsIds { get; }

        CompareResult CompareTo(IFigure figure);
    }
}
