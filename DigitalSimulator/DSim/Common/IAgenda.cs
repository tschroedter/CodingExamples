using JetBrains.Annotations;

namespace DSim.Common
{
    public interface IAgenda
    {
        string Name { get; set; }

        void Schedule(int time,
                      [NotNull] ITask task);

        void Run();
    }
}