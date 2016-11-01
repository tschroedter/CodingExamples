using System;
using JetBrains.Annotations;

namespace DSim.Common
{
    public class TimedTask
        : ITimedTask,
          IComparable
    {
        private static int s_Count;

        public TimedTask(int time,
                         [NotNull] ITask task)
        {
            Id = s_Count++;
            Time = time;
            Task = task;
        }

        private ITask Task { get; set; }

        public int CompareTo(object obj) // todo testing
        {
            var task = obj as ITimedTask;

            if ( task != null )
            {
                return CompareTo(task);
            }

            return -1;
        }

        public int Id { get; private set; }
        public int Time { get; private set; }

        public void Run()
        {
            Task.Run(Time);
        }

        public int CompareTo(ITimedTask other)
        {
            if ( Time == other.Time )
            {
                return Id - other.Id;
            }

            return Time - other.Time;
        }
    }
}