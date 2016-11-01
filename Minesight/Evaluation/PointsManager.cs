using System.Collections.Generic;
using Evaluation.Interfaces;
using Evaluation.Interfaces.Repositories;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Evaluation
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class PointsManager : IPointsManager
    {
        private readonly IPointsRepository m_Repository;
        private readonly IRepositoryPointsShifter m_RepositoryShifter;

        public PointsManager([NotNull] IPointsRepository repository,
                             [NotNull] IRepositoryPointsShifter repositoryShifter)
        {
            m_Repository = repository;
            m_RepositoryShifter = repositoryShifter;
        }

        public IPoint3D Get(int key)
        {
            return m_Repository.Get(key);
        }

        public IEnumerable <IPoint3D> All()
        {
            return m_Repository.All();
        }

        public void Add(IPoint3D instance)
        {
            m_Repository.Add(instance);
        }

        public void Clear()
        {
            m_Repository.Clear();
        }

        public void Remove(IPoint3D instance)
        {
            m_Repository.Remove(instance);
        }

        public int Count()
        {
            return m_Repository.Count();
        }

        public void Shift(IPoint3D shiftByPoint3D)
        {
            m_RepositoryShifter.Shift(m_Repository,
                                      shiftByPoint3D);
        }

        public void AddRange(IEnumerable <IPoint3D> points)
        {
            m_Repository.AddRange(points);
        }
    }
}