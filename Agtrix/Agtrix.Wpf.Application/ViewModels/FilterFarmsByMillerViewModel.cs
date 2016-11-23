using System.Collections.Generic;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.Wpf.Application.Interfaces.ViewModels;
using Agtrix.Wpf.Application.Services.Events;
using Agtrix.Wpf.Application.ViewModels.Events;
using Caliburn.Micro;
using JetBrains.Annotations;

namespace Agtrix.Wpf.Application.ViewModels
{
    public class FilterFarmsByMillerViewModel
        : PropertyChangedBase,
          IFilterFarmsByMillerViewModel,
          IHandle <MillersChangedEvent>
    {
        public FilterFarmsByMillerViewModel(
            [NotNull] IEventAggregator eventAggregator)
        {
            m_EventAggregator = eventAggregator;

            m_EventAggregator.Subscribe(this);

            m_EventAggregator.PublishOnBackgroundThread(new MillersRequestEvent());
        }

        public IEnumerable <IMiller> Millers { get; private set; }

        public IMiller CurrentMiller { get; private set; }

        public IMiller SelectedMiller
        {
            get
            {
                return CurrentMiller;
            }
            set
            {
                if ( CurrentMiller == value )
                {
                    return;
                }
                CurrentMiller = value;

                NotifyOfPropertyChange(() => SelectedMiller);
                NotifyOfPropertyChange(() => CurrentMiller);
            }
        }

        private readonly IEventAggregator m_EventAggregator;

        public void Handle(MillersChangedEvent message)
        {
            Millers = message.Millers;
            SelectedMiller = Millers.FirstOrDefault();

            NotifyOfPropertyChange(() => Millers);
        }

        public void Filter()
        {
            var filter = new FilterByMillerEvent
                         {
                             MillerId = SelectedMiller.Id
                         };

            m_EventAggregator.PublishOnBackgroundThread(filter);
        }

        public void Reset()
        {
            m_EventAggregator.PublishOnBackgroundThread(new ResetFiltersEvent());
        }
    }
}