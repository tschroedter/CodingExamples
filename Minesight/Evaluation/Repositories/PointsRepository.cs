using System.Collections.Generic;
using System.Linq;
using Evaluation.Interfaces.Repositories;
using Evaluation.Interfaces.Shapes;
using Selkie.Windsor;

namespace Evaluation.Repositories
{
    [ProjectComponent(Lifestyle.Transient)]
    public sealed class PointsRepository : IPointsRepository
    {
        private readonly Dictionary <int, IPoint3D> m_Points = new Dictionary <int, IPoint3D>();

        public IPoint3D Get(int key)
        {
            IPoint3D point;

            return !m_Points.TryGetValue(key,
                                         out point)
                       ? null
                       : point;
        }

        public IEnumerable <IPoint3D> All()
        {
            return m_Points.Values.ToArray();
        }

        public void Add(IPoint3D instance)
        {
            m_Points [ instance.Id ] = instance;
        }

        public void Remove(IPoint3D instance)
        {
            m_Points.Remove(instance.Id);
        }

        public int Count()
        {
            return m_Points.Keys.Count;
        }

        public void Clear()
        {
            m_Points.Clear();
        }

        public void AddRange(IEnumerable <IPoint3D> points)
        {
            foreach ( IPoint3D point in points )
            {
                m_Points.Add(point.Id,
                             point);
            }
        }
    }
}