using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Game;
using JetBrains.Annotations;

namespace Console
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public class SolutionLinkedList
    {
        private readonly SolutionHelper m_Helper;

        public SolutionLinkedList([NotNull] SolutionHelper helper)
        {
            m_Helper = helper;
        }

        public void Run(int numberOfPeopleStandingInACircle,
                        int numberOfPeopleToCountOverEachTime)
        {
            var factory = new CircleOfPeopleFactory();
            var circle = new Circle(factory);

            IEnumerable <int> result = circle.Run(numberOfPeopleStandingInACircle,
                                                  numberOfPeopleToCountOverEachTime).ToArray();

            int winner = result.Last();

            System.Console.WriteLine("The sequence of children as they are eliminated: {0}",
                                     m_Helper.ArrayToString(result));
            System.Console.WriteLine("The id of the winning child: {0}",
                                     winner);
        }
    }
}