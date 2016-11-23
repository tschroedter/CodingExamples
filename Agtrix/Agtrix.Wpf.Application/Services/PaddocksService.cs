using System;
using System.Linq;
using Agtrix.DataAccess.Entities;
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
    public class PaddocksService
        : BaseService,
          IPaddocksService,
          IHandle <PadockRemoveEvent>,
          IHandle <PaddockCreateEvent>,
          IHandle <PaddocksRequestEvent>
    {
        public PaddocksService(
            [NotNull] ISelkieLogger logger,
            [NotNull] IEventAggregator eventAggregator,
            [NotNull] IPaddocksRepository paddocksRepository)
            : base(logger)
        {
            m_EventAggregator = eventAggregator;
            m_PaddocksRepository = paddocksRepository;

            m_EventAggregator.Subscribe(this);
        }

        private readonly IEventAggregator m_EventAggregator;
        private readonly IPaddocksRepository m_PaddocksRepository;

        public void Handle([NotNull] PaddockCreateEvent message)
        {
            if ( Guid.Empty == message.FarmId )
            {
                return;
            }

            var paddock = new Paddock
                          {
                              FarmId = message.FarmId,
                              AreaInHectares = 0.0f,
                              FieldsCode = "New Fields Code",
                              Id = Guid.NewGuid()
                          };

            m_PaddocksRepository.Save(paddock);

            PublishPaddocksChangedEvent(paddock.FarmId);
        }

        public void Handle(PaddocksRequestEvent message)
        {
            PublishPaddocksChangedEvent(message.FarmId);
        }

        public void Handle([NotNull] PadockRemoveEvent message)
        {
            IPaddock paddock = m_PaddocksRepository.FindById(message.PaddockId);

            if ( paddock == null )
            {
                return;
            }

            m_PaddocksRepository.Remove(paddock);

            PublishPaddocksChangedEvent(paddock.FarmId);
        }

        private void PublishPaddocksChangedEvent(Guid farmId)
        {
            IQueryable <IPaddock> paddocks = m_PaddocksRepository.FindByFarmId(farmId);

            var changed = new PaddocksChangedEvent
                          {
                              Paddocks = paddocks
                          };

            m_EventAggregator.PublishOnBackgroundThread(changed);
        }
    }
}