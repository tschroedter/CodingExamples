using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class UserOutput : IUserOutput
    {
        private readonly IConsole m_Console;
        private readonly IDisplayPlayingField m_DisplayPlayingFieldField;

        public UserOutput([NotNull] IConsole console,
                          [NotNull] IDisplayPlayingFieldFactory factory,
                          [NotNull] IHintField hintField,
                          [NotNull] IPlayingField playingField)
        {
            m_Console = console;
            m_DisplayPlayingFieldField = factory.Create(hintField,
                                                        playingField);
        }

        public void DisplayPlayingField()
        {
            m_Console.WriteLine("Minefield:");
            m_Console.WriteLine(m_DisplayPlayingFieldField.ToString());
        }
    }
}