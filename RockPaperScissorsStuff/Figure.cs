using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Task3.RockPaperScissorsStuff
{
    public class Figure : IFigure
    {
        public int Id { get; }
        public string Name { get; }
        public IReadOnlyCollection<int> DominantsIds { get; }

        public Figure(int id, string name, int countOther)
        {
            Id = id;
            Name = name;
            DominantsIds = new ReadOnlyCollection<int>(SetDominants(countOther));
        }

        private List<int> SetDominants(int countOther)
        {
            var list = new List<int>();
            var d = Id;
            for (int i = 0; i < countOther / 2; i++)
            {
                d = d % countOther + 1;
                list.Add(d);
            }
            return list;
        }

        public CompareResult CompareTo(IFigure figure)
        {
            if (Id == figure.Id) return CompareResult.Draw;
            return DominantsIds.Contains(figure.Id) ? CompareResult.Loose
                : CompareResult.Win;
        }
    }
}
