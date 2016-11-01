using System.Collections.Generic;
using System.Linq;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules.Conditions;

namespace GameOfLive.Board.Rules.Rules
{
    public abstract class BaseCellInformationRule
    {
        private readonly List <ICondition> m_Conditions = new List <ICondition>();

        protected List <ICondition> Conditions
        {
            get
            {
                return m_Conditions;
            }
        }

        public int Priority
        {
            get
            {
                return GetPriority();
            }
        }

        public void ClearConditions()
        {
            m_Conditions.Clear();
        }

        public bool IsValid()
        {
            return m_Conditions.All(x => x.IsSatisfied());
        }

        public IEnumerable <ICondition> GetConditions()
        {
            return m_Conditions;
        }

        public abstract void Initialize(ICellInformation info);

        public abstract ICellInformation Apply(ICellInformation info);

        public abstract int GetPriority();
    }
}