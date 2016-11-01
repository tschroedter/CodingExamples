using JetBrains.Annotations;

namespace KataMinesweeper.Interfaces
{
    public interface IConsole
    {
        void WriteLine([NotNull] string text);

        [CanBeNull]
        string ReadLine();

        void Write(string format,
                   params object[] args);

        void WriteLine(string format,
                       params object[] args);
    }
}