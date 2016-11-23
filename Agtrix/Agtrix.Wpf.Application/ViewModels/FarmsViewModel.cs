using System;
using System.Collections.Generic;
using System.Linq;
using Agtrix.Wpf.Application.Dto;
using Agtrix.Wpf.Application.Interfaces.ViewModels;
using Agtrix.Wpf.Application.Services.Events;
using Agtrix.Wpf.Application.ViewModels.Events;
using Caliburn.Micro;
using JetBrains.Annotations;
using Selkie.Windsor;
using Selkie.Windsor.Extensions;

namespace Agtrix.Wpf.Application.ViewModels
{
    public class FarmsViewModel
        : PropertyChangedBase,
          IFarmsViewModel,
          IHandle <FarmsMillersChangedEvent>,
          IHandle <FilterByMillerEvent>,
          IHandle <ResetFiltersEvent>,
          IHandle <FilterByFarmNameEvent>,
          IHandle <FarmChangedEvent>
    {
        public FarmsViewModel(
            [NotNull] IEventAggregator eventAggregator,
            [NotNull] ISelkieLogger logger)
        {
            m_EventAggregator = eventAggregator;
            m_Logger = logger;

            AvailableFarms = new BindableCollection <IFarmMillerViewModel>();

            m_EventAggregator.Subscribe(this);

            m_EventAggregator.PublishOnBackgroundThread(new FarmsMillersRequestEvent());
        }

        public IFarmMillerViewModel SelectedAvailableFarm
        {
            get
            {
                return CurrentFarm;
            }
            set
            {
                if ( CurrentFarm == value )
                {
                    return;
                }
                CurrentFarm = value;

                NotifyOfPropertyChange(() => SelectedAvailableFarm);
                NotifyOfPropertyChange(() => CurrentFarm);

                m_EventAggregator.PublishOnBackgroundThread(new SelectedFarmChangedEvent
                                                            {
                                                                FarmId = CurrentFarm.FarmId
                                                            });
            }
        }

        public IFarmMillerViewModel CurrentFarm { get; private set; }

        public BindableCollection <IFarmMillerViewModel> AvailableFarms { get; private set; }

        private readonly IEventAggregator m_EventAggregator;
        private readonly ISelkieLogger m_Logger;

        public void Handle(FarmChangedEvent message)
        {
            FarmMillerDto dto = message.FarmMillerDto;

            IFarmMillerViewModel current = AvailableFarms.FirstOrDefault(x => x.FarmId == dto.FarmId);

            if ( current == null )
            {
                m_Logger.Warn("[FarmChangedEvent] " +
                              "Could not find Farm '{0}' with Id '{1}' ".Inject(dto.FarmName,
                                                                                dto.FarmId) +
                              "in AvailableFarms and ignoring it!");

                return; 
            }

            current.FarmType = dto.FarmType;
            current.FarmName = dto.FarmName;
            current.FieldsCode = dto.FieldsCode;
            current.Harvested = dto.Harvested;
            current.MillerId = dto.MillerId;
            current.MillerName = dto.MillerName;

            AvailableFarms.Refresh();
        }

        public void Handle(FarmsMillersChangedEvent message)
        {
            var models = new List <IFarmMillerViewModel>();

            foreach ( FarmMillerDto dto in message.FarmMillerDtos )
            {
                var model = new FarmMillerViewModel(dto);

                models.Add(model);
            }


            AvailableFarms.Clear();
            AvailableFarms.AddRange(models);

            SetSelectedAvailableFarm(message.SelectedFarmId);
        }

        public void Handle(FilterByFarmNameEvent message)
        {
            IEnumerable <IFarmMillerViewModel> filtered =
                AvailableFarms.Where(x => x.FarmName
                                           .Contains(message.SearchText))
                              .ToArray();

            AvailableFarms.Clear();
            AvailableFarms.AddRange(filtered);

            SetSelectedAvailableFarm(Guid.Empty);
        }

        public void Handle(FilterByMillerEvent message)
        {
            IEnumerable <IFarmMillerViewModel> filtered = AvailableFarms.Where(x => x.MillerId == message.MillerId)
                                                                        .ToArray();

            AvailableFarms.Clear();
            AvailableFarms.AddRange(filtered);

            SetSelectedAvailableFarm(Guid.Empty);
        }

        public void Handle(ResetFiltersEvent message)
        {
            m_EventAggregator.PublishOnBackgroundThread(new FarmsMillersRequestEvent());
        }

        public void Add()
        {
            m_EventAggregator.PublishOnBackgroundThread(new FarmCreateRequestEvent());
        }

        public void ResetFilters()
        {
            m_EventAggregator.PublishOnBackgroundThread(new FarmsMillersRequestEvent());
        }

        private void SetSelectedAvailableFarm(Guid farmId)
        {
            if ( AvailableFarms.Count == 0 )
            {
                return;
            }

            IFarmMillerViewModel viewModel = AvailableFarms.FirstOrDefault(x => x.FarmId == farmId);

            SelectedAvailableFarm = viewModel ?? AvailableFarms.First();
        }
    }
}