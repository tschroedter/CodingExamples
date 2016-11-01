using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Evaluation.Interfaces;
using Fclp;
using JetBrains.Annotations;

namespace Evaluation.Console
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private const string DefaultPointText = "0.0 0.0 0.0";

        private static void Main(string[] args)
        {
            FluentCommandLineParser <ApplicationArguments> parser = CreateParser();
            ICommandLineParserResult result = parser.Parse(args);

            if ( result.HasErrors )
            {
                System.Console.WriteLine(result.ErrorText);

                return;
            }

            using ( var container = new WindsorContainer() )
            {
                container.Install(FromAssembly.This());

                var finder = container.Resolve <IClosestPointsFinder>();
                finder.Run(parser.Object);
                DisplayIds(finder.ClosestIds);
                container.Release(finder);
            }
        }

        private static void DisplayIds([NotNull] IEnumerable <int> ids)
        {
            string text = string.Join(",",
                                      ids);

            System.Console.WriteLine("ID(s) of closest points: {0}",
                                     text);

            System.Console.ReadLine();
        }

        private static FluentCommandLineParser <ApplicationArguments> CreateParser()
        {
            var parser = new FluentCommandLineParser <ApplicationArguments>();

            parser.Setup(arg => arg.Source)
                  .As('s',
                      "source")
                  .WithDescription("The name of the CSV file containing points to be used as source.")
                  .SetDefault("Points.csv");

            parser.Setup(arg => arg.NumberOfClosestPoints)
                  .As('n',
                      "numberOfClosestPoints")
                  .SetDefault(1);

            parser.Setup(arg => arg.Verbose)
                  .As('v',
                      "verbose")
                  .WithDescription("Show additional information.")
                  .SetDefault(false);

            parser.Setup(arg => arg.QueryPointCoordinates)
                  .As('q',
                      "queryPoint")
                  .WithDescription("The query point’s X, Y, Z coordinates, e.g. -q=\"-1.0 2.0 3.0\"")
                  .SetDefault(DefaultPointText);

            parser.Setup(arg => arg.ShiftPointCoordinates)
                  .As('m',
                      "moveByVector")
                  .WithDescription("The shift vector’s X, Y, Z coordinates, e.g. -q=\"-1.0 2.0 3.0\"")
                  .SetDefault(DefaultPointText);

            return parser;
        }
    }
}