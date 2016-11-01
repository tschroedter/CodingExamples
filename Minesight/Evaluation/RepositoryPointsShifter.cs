using System.Collections.Generic;
using System.Linq;
using Evaluation.Interfaces.Geometry.Calculators;
using Evaluation.Interfaces.Repositories;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Evaluation
{
    [ProjectComponent(Lifestyle.Transient)]
    public sealed class RepositoryPointsShifter : IRepositoryPointsShifter
    {
        private readonly IShiftPointCalculator m_Calculator;

        public RepositoryPointsShifter([NotNull] IShiftPointCalculator calculator)
        {
            m_Calculator = calculator;
        }

        public void Shift(IPointsRepository repository,
                          IPoint3D shiftByPoint3D)
        {
            List <IPoint3D> shiftedPoints = repository.All()
                                                      .Select(point3D => m_Calculator.Calculate(point3D,
                                                                                                shiftByPoint3D))
                                                      .ToList();

            repository.Clear();
            repository.AddRange(shiftedPoints);
        }
    }
}