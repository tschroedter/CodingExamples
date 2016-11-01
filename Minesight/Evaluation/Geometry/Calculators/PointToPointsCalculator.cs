using System.Collections.Generic;
using System.Linq;
using Evaluation.Interfaces;
using Evaluation.Interfaces.Geometry.Calculators;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Evaluation.Geometry.Calculators
{
    [ProjectComponent(Lifestyle.Transient)]
    public sealed class PointToPointsCalculator : IPointToPointsCalculator
    {
        private readonly IDistanceCalculator3D m_Calculator;
        private readonly IPointsManager m_Manager;
        private IOrderedEnumerable <DistanceInfo> m_SortedByDistance = new List <DistanceInfo>().OrderBy(x => x.Distance);

        public PointToPointsCalculator([NotNull] IPointsManager manager,
                                       [NotNull] IDistanceCalculator3D calculator)
        {
            m_Manager = manager;
            m_Calculator = calculator;
        }

        public void Calculate(IPoint3D fromPoint3D)
        {
            m_SortedByDistance = CalculateDistanceFromPoint3D(fromPoint3D);
        }

        public IEnumerable <double> Distances()
        {
            return m_SortedByDistance.Select(x => x.Distance).ToArray();
        }

        public IEnumerable <int> Ids()
        {
            return m_SortedByDistance.Select(x => x.Id).ToArray();
        }

        private IOrderedEnumerable <DistanceInfo> CalculateDistanceFromPoint3D([NotNull] IPoint3D fromPoint3D)
        {
            var sortedByDistance = new List <DistanceInfo>();

            IEnumerable <IPoint3D> otherPoints = m_Manager.All();

            foreach ( IPoint3D toPoint in otherPoints )
            {
                double distance = m_Calculator.Calculate(fromPoint3D,
                                                         toPoint);
                var info = new DistanceInfo
                           {
                               Id = toPoint.Id,
                               Distance = distance
                           };

                sortedByDistance.Add(info);
            }

            return sortedByDistance.OrderBy(x => x.Distance);
        }

        [ToString]
        private class DistanceInfo
        {
            public int Id { get; set; }
            public double Distance { get; set; }
        }
    }
}