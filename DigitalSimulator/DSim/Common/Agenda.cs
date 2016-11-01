using System.Collections.Generic;
using System.Linq;
using Selkie.Windsor;

namespace DSim.Common
{
    [ProjectComponent(Lifestyle.Transient)]
    public class Agenda : IAgenda
    {
        private static int s_NextId = 1;
        private readonly SortedSet <ITimedTask> m_TimedTasks = new SortedSet <ITimedTask>();

        public Agenda()
        {
            Id = s_NextId++;
            Name = Id.ToString();
        }

        public int Id { get; private set; } // todo testing
        public string Name { get; set; } // todo testing, move into constructor

        public void Schedule(int time,
                             ITask task)
        {
            m_TimedTasks.Add(new TimedTask(time,
                                           task)); // todo factory
        }

        public void Run()
        {
            while ( m_TimedTasks.Any() )
            {
                ITimedTask timedTask = m_TimedTasks.First();
                m_TimedTasks.Remove(timedTask);
                timedTask.Run();
            }
        }
    }
}