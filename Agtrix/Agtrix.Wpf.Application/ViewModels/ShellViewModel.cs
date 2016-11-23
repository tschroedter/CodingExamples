using Agtrix.Wpf.Application.Interfaces.ViewModels;
using Agtrix.Wpf.Application.Interfaces.Views;
using Caliburn.Micro;
using JetBrains.Annotations;

namespace Agtrix.Wpf.Application.ViewModels
{
    public class ShellViewModel
        : PropertyChangedBase,
          IShellViewModel
    {
        public ShellViewModel(
            [NotNull] IEventAggregator eventAggregator,
            [NotNull] IFarmsViewModel farmsViewModel,
            [NotNull] IFarmViewModel farmViewModel,
            [NotNull] IPaddocksViewModel paddocksViewModel,
            [NotNull] IFilterFarmsByMillerViewModel filterFarmsByMillerViewModel,
            [NotNull] IFilterFarmsByFarmNameViewModel farmsByFarmNameViewModel)
        {
            Farms = farmsViewModel;
            Farm = farmViewModel;
            Paddocks = paddocksViewModel;
            FilterFarmsByMiller = filterFarmsByMillerViewModel;
            FilterFarmsByFarmName = farmsByFarmNameViewModel;

            eventAggregator.Subscribe(this);
        }

        public IFilterFarmsByFarmNameViewModel FilterFarmsByFarmName
        {
            get
            {
                return m_FilterFarmsByFarmNameViewModel;
            }
            set
            {
                if ( m_FilterFarmsByFarmNameViewModel == value )
                {
                    return;
                }

                m_FilterFarmsByFarmNameViewModel = value;

                NotifyOfPropertyChange(() => FilterFarmsByFarmName);
            }
        }

        public IFarmsViewModel Farms
        {
            get
            {
                return m_FarmsViewModel;
            }
            set
            {
                if ( m_FarmsViewModel == value )
                {
                    return;
                }

                m_FarmsViewModel = value;

                NotifyOfPropertyChange(() => Farms);
            }
        }

        public IPaddocksViewModel Paddocks
        {
            get
            {
                return m_PaddocksViewModel;
            }
            set
            {
                if ( m_PaddocksViewModel == value )
                {
                    return;
                }

                m_PaddocksViewModel = value;

                NotifyOfPropertyChange(() => Paddocks);
            }
        }

        public IFarmViewModel Farm
        {
            get
            {
                return m_FarmViewModel;
            }
            set
            {
                if ( m_FarmViewModel == value )
                {
                    return;
                }

                m_FarmViewModel = value;

                NotifyOfPropertyChange(() => Farm);
            }
        }

        public IFilterFarmsByMillerViewModel FilterFarmsByMiller
        {
            get
            {
                return m_FilterFarmsByMillerViewModel;
            }
            set
            {
                if ( m_FilterFarmsByMillerViewModel == value )
                {
                    return;
                }

                m_FilterFarmsByMillerViewModel = value;

                NotifyOfPropertyChange(() => FilterFarmsByMiller);
            }
        }

        private IFarmsViewModel m_FarmsViewModel;

        private IFarmViewModel m_FarmViewModel;

        private IFilterFarmsByFarmNameViewModel m_FilterFarmsByFarmNameViewModel;

        private IFilterFarmsByMillerViewModel m_FilterFarmsByMillerViewModel;

        private IPaddocksViewModel m_PaddocksViewModel;
    }
}