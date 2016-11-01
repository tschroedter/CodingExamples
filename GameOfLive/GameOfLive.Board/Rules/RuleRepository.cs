using System.Collections.Generic;
using System.Linq;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules.Rules;
using JetBrains.Annotations;

namespace GameOfLive.Board.Rules
{
    public class RuleRepository : IRuleRepository
    {
        private readonly IEnumerable <IRule <ICellInformation>> m_Rules;

        public RuleRepository([NotNull] IEnumerable <IRule <ICellInformation>> rules)
        {
            m_Rules = rules.OrderBy(x => x.Priority).ToArray();
        }

        public IEnumerable <IRule <ICellInformation>> Rules
        {
            get
            {
                return m_Rules;
            }
        }
    }

    public interface IRuleRepository
    {
        IEnumerable <IRule <ICellInformation>> Rules { get; }
    }
}