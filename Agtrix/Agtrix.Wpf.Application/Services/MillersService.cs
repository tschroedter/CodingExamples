using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using Agtrix.Wpf.Application.Interfaces.Services;
using Agtrix.Wpf.Application.Services.Events;
using Caliburn.Micro;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Agtrix.Wpf.Application.Services
{
    [ProjectComponent(Lifestyle.Startable)]
    public class MillersService
        : BaseService,
          IMillersService,
          IHandle <MillersRequestEvent>
    {
        public MillersService(
            [NotNull] ISelkieLogger logger,
            [NotNull] IEventAggregator eventAggregator,
            [NotNull] IMillersRepository millersRepository)
            : base(logger)
        {
            m_EventAggregator = eventAggregator;
            m_MillersRepository = millersRepository;

            m_EventAggregator.Subscribe(this);
        }

        private readonly IEventAggregator m_EventAggregator;
        private readonly IMillersRepository m_MillersRepository;

        public void Handle([NotNull] MillersRequestEvent message)
        {
            IMiller[] millers = m_MillersRepository.All.ToArray();

            var changed = new MillersChangedEvent
                          {
                              Millers = millers
                          };

            m_EventAggregator.PublishOnBackgroundThread(changed);
        }
    }
}