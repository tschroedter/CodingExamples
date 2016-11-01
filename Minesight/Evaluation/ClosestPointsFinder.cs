using System;
using System.Collections.Generic;
using System.Linq;
using Evaluation.Interfaces;
using Evaluation.Interfaces.Geometry.Calculators;
using Evaluation.Interfaces.Importers;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Evaluation
{
    // todo move some of the Console.WriteLine calls to the program class
    // todo integration tests
    [ProjectComponent(Lifestyle.Transient)]
    public class ClosestPointsFinder : IClosestPointsFinder
    {
        private const double Tolerance = 1E-6;
        private readonly IPointToPointsCalculator m_Calculator;
        private readonly IDisplayApplicationArguments m_DisplayArguments;
        private readonly ICsvIntoRepositoryLoader m_Loader;
        private readonly IPointsManager m_Manager;

        public ClosestPointsFinder([NotNull] ICsvIntoRepositoryLoader loader,
                                   [NotNull] IPointsManager manager,
                                   [NotNull] IPointToPointsCalculator calculator,
                                   [NotNull] IDisplayApplicationArguments displayArguments)
        {
            m_Loader = loader;
            m_Manager = manager;
            m_Calculator = calculator;
            m_DisplayArguments = displayArguments;

            ClosestIds = new int[0];
        }

        public void Run(IApplicationArguments args)
        {
            DisplayOptions(args);
            LoadSource(args.Source);
            ShiftPoints(args.GetShiftVector3D());
            FindClosestIds(args);
        }

        public IEnumerable <int> ClosestIds { get; private set; }

        private void DisplayOptions([NotNull] IApplicationArguments args)
        {
            if ( !args.Verbose )
            {
                return;
            }

            m_DisplayArguments.Display(args);
        }

        private void LoadSource([NotNull] string filename)
        {
            m_Loader.LoadFromCsvFile(filename);

            Console.WriteLine("Loading points from '{0}'...Done!",
                              filename);

            Console.WriteLine("Points in repository: {0}",
                              m_Manager.Count());
        }

        private void ShiftPoints([NotNull] IPoint3D shiftByPoint3D)
        {
            if ( !IsShiftRequired(shiftByPoint3D) )
            {
                Console.WriteLine("Shifting is not required!");

                return;
            }

            m_Manager.Shift(shiftByPoint3D);

            Console.WriteLine("Shifting all points by 'X: {0} Y: {1} Z: {2}'...Done!",
                              shiftByPoint3D.X,
                              shiftByPoint3D.Y,
                              shiftByPoint3D.Z);
        }

        private static bool IsShiftRequired([NotNull] IPoint3D point3D)
        {
            return !( Math.Abs(point3D.X) < Tolerance ) ||
                   !( Math.Abs(point3D.Y) < Tolerance ) ||
                   !( Math.Abs(point3D.Z) < Tolerance );
        }

        private IEnumerable <int> FindIdsOfClosestPoints([NotNull] IPoint3D fromPoint3D)
        {
            m_Calculator.Calculate(fromPoint3D);

            return m_Calculator.Ids();
        }

        private void FindClosestIds([NotNull] IApplicationArguments args)
        {
            IEnumerable <int> ids = FindIdsOfClosestPoints(args.GetQueryPoint3D());
            IEnumerable <int> selectedIds = ids.Take(args.NumberOfClosestPoints).ToArray();

            ClosestIds = selectedIds;
        }
    }
}