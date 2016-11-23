using Agtrix.Wpf.Application.Interfaces.ViewModels;
using Agtrix.Wpf.Application.ViewModels.Events;
using Caliburn.Micro;
using JetBrains.Annotations;

namespace Agtrix.Wpf.Application.ViewModels
{
    public class FilterFarmsByFarmNameViewModel
        : PropertyChangedBase,
          IFilterFarmsByFarmNameViewModel
    {
        public FilterFarmsByFarmNameViewModel(
            [NotNull] IEventAggregator eventAggregator)
        {
            m_EventAggregator = eventAggregator;

            m_EventAggregator.Subscribe(this);
        }

        private readonly IEventAggregator m_EventAggregator;

        public void Filter(string searchText)
        {
            var filter = new FilterByFarmNameEvent
                         {
                             SearchText = searchText
                         };

            m_EventAggregator.PublishOnBackgroundThread(filter);
        }

        public void Reset()
        {
            m_EventAggregator.PublishOnBackgroundThread(new ResetFiltersEvent());
        }
    }
}