using DSim.Common;
using JetBrains.Annotations;
using NUnit.Framework;
using Selkie.Windsor.Extensions;
using Should;

namespace DSim.Tests.Common
{
    [TestFixture]
    internal sealed class AgendaTests
    {
        [SetUp]
        public void Setup()
        {
            MockTask.ResetHistory();

            m_TaskOne = new MockTask("A");
            m_TaskTwo = new MockTask("B");

            m_Sut = new Agenda();
        }

        private Agenda m_Sut;
        private MockTask m_TaskOne;
        private MockTask m_TaskTwo;

        private class MockTask : ITask
        {
            private readonly string m_Name;

            public MockTask([NotNull] string name)
            {
                m_Name = name;
            }

            public static string History { get; private set; }

            public void Run(int time)
            {
                History += "({0},{1})".Inject(time,
                                              m_Name);
            }

            public static void ResetHistory()
            {
                History = "";
            }
        }

        [Test]
        public void Schedule_CallsRun_ForOneTask()
        {
            // Arrange
            m_Sut.Schedule(12,
                           m_TaskOne);

            // Act
            m_Sut.Run();

            // Assert
            MockTask.History.ShouldEqual("(12,A)");
        }

        [Test]
        public void Schedule_CallsRun_ForTwoTasks()
        {
            // Arrange
            m_Sut.Schedule(15,
                           m_TaskOne);
            m_Sut.Schedule(12,
                           m_TaskTwo);

            // Act
            m_Sut.Run();

            // Assert
            MockTask.History.ShouldEqual("(12,B)(15,A)");
        }
    }
}