using System;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.Wpf.Application.Interfaces.ViewModels;
using Agtrix.Wpf.Application.Services.Events;
using Agtrix.Wpf.Application.ViewModels.Events;
using Caliburn.Micro;
using JetBrains.Annotations;

namespace Agtrix.Wpf.Application.ViewModels
{
    public class PaddocksViewModel
        : PropertyChangedBase,
          IPaddocksViewModel,
          IHandle <SelectedFarmChangedEvent>,
          IHandle <PaddocksChangedEvent>
    {
        public PaddocksViewModel(
            [NotNull] IEventAggregator eventAggregator)
        {
            m_EventAggregator = eventAggregator;

            m_EventAggregator.Subscribe(this);

            Paddocks = new BindableCollection <IPaddock>();
        }

        public BindableCollection <IPaddock> Paddocks { get; private set; }
        public float TotalAreaInHectares { get; private set; }

        public Guid FarmId { get; set; }
        private readonly IEventAggregator m_EventAggregator;

        public void Handle(PaddocksChangedEvent message)
        {
            Paddocks.Clear();
            Paddocks.AddRange(message.Paddocks);

            TotalAreaInHectares = Paddocks.Sum(x => x.AreaInHectares);
            NotifyOfPropertyChange(() => TotalAreaInHectares);
        }

        public void Handle(SelectedFarmChangedEvent message)
        {
            FarmId = message.FarmId;

            var request = new PaddocksRequestEvent
                          {
                              FarmId = message.FarmId
                          };

            m_EventAggregator.PublishOnBackgroundThread(request);
        }

        public void AddPaddock()
        {
            var add = new PaddockCreateEvent
                      {
                          FarmId = FarmId
                      };

            m_EventAggregator.PublishOnBackgroundThread(add);
        }

        public void RemovePaddock([NotNull] IPaddock paddock)
        {
            var remove = new PadockRemoveEvent
                         {
                             PaddockId = paddock.Id
                         };

            m_EventAggregator.PublishOnBackgroundThread(remove);
        }
    }
}