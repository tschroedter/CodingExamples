using System;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Interfaces;
using Selkie.Windsor;

namespace Evaluation
{
    [ExcludeFromCodeCoverage]
    [ProjectComponent(Lifestyle.Transient)]
    public sealed class DisplayApplicationArguments : IDisplayApplicationArguments
    {
        public void Display(IApplicationArguments args)
        {
            Console.WriteLine("Used options:");
            Console.WriteLine("-------------");
            Console.WriteLine("Source                  : {0}",
                              args.Source);
            Console.WriteLine("Query Point             : {0}",
                              args.GetQueryPoint3D());
            Console.WriteLine("Shift Vector            : {0}",
                              args.GetShiftVector3D());
            Console.WriteLine("Number of closest points: {0}",
                              args.NumberOfClosestPoints);
            Console.WriteLine();
        }
    }
}