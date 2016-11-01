using System.Collections.Generic;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules;
using GameOfLive.Interfaces.Rules.Rules;
using JetBrains.Annotations;

namespace GameOfLive.Board.Rules
{
    public class Engine : IEngine
    {
        private readonly IRuleRepository m_Repository;

        public Engine([NotNull] IRuleRepository repository)
        {
            m_Repository = repository;
        }

        public void ApplyRules(IEnumerable <ICellInformation> cells)
        {
            foreach ( ICellInformation information in cells )
            {
                ApplyRulesToCellInformation(information);
            }
        }

        private void ApplyRulesToCellInformation(ICellInformation information)
        {
            foreach ( IRule <ICellInformation> rule in m_Repository.Rules )
            {
                rule.ClearConditions();
                rule.Initialize(information);

                if ( rule.IsValid() )
                {
                    rule.Apply(information);
                    break;
                }
            }
        }
    }
}