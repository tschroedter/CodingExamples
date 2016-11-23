using System;
using System.Collections.Generic;
using System.Linq;
using Agtrix.DataAccess.Entities;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.Wpf.Application.Interfaces.ViewModels;
using Agtrix.Wpf.Application.Services.Events;
using Agtrix.Wpf.Application.ViewModels.Events;
using Caliburn.Micro;
using JetBrains.Annotations;

namespace Agtrix.Wpf.Application.ViewModels
{
    public class FarmViewModel
        : PropertyChangedBase,
          IFarmViewModel,
          IHandle <SelectedFarmChangedEvent>,
          IHandle <FarmChangedEvent>,
          IHandle <MillersChangedEvent>
    {
        public FarmViewModel(
            [NotNull] IEventAggregator eventAggregator)
        {
            m_EventAggregator = eventAggregator;

            m_EventAggregator.Subscribe(this);

            m_EventAggregator.PublishOnBackgroundThread(new MillersRequestEvent());

            PopulateAvailableFarmTypes();
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

        public IEnumerable <string> AvailableFarmTypes { get; private set; }

        public string CurrentAvailableFarmType { get; private set; }

        public string SelectedAvailableFarmType
        {
            get
            {
                return CurrentAvailableFarmType;
            }
            set
            {
                if ( CurrentAvailableFarmType == value )
                {
                    return;
                }
                CurrentAvailableFarmType = value;

                NotifyOfPropertyChange(() => SelectedAvailableFarmType);
                NotifyOfPropertyChange(() => CurrentAvailableFarmType);
            }
        }

        private readonly IEventAggregator m_EventAggregator;

        public Guid MillerId { get; set; }
        public Guid FarmId { get; set; }
        public string FieldsCode { get; set; }
        public string FarmName { get; set; }
        public DateTime Harvested { get; set; }
        public FarmType FarmType { get; set; }
        public string MillerName { get; set; }

        public void Apply()
        {
            var farm = new Farm
                       {
                           Id = FarmId,
                           MillerId = CurrentMiller.Id,
                           FieldsCode = FieldsCode,
                           Name = FarmName,
                           Harvested = Harvested,
                           FarmType = ( FarmType ) Enum.Parse(typeof( FarmType ),
                                                              CurrentAvailableFarmType)
                       };

            m_EventAggregator.PublishOnBackgroundThread(new FarmSaveEvent
                                                        {
                                                            Farm = farm
                                                        });
        }

        public void Handle(FarmChangedEvent message)
        {
            FarmId = message.FarmMillerDto.FarmId;
            FieldsCode = message.FarmMillerDto.FieldsCode;
            FarmName = message.FarmMillerDto.FarmName;
            Harvested = message.FarmMillerDto.Harvested;
            FarmType = message.FarmMillerDto.FarmType;
            MillerId = message.FarmMillerDto.MillerId;
            MillerName = message.FarmMillerDto.MillerName;

            SelectedMiller = Millers.FirstOrDefault(x => x.Id == MillerId);
            SelectedAvailableFarmType = Enum.GetName(typeof( FarmType ),
                                                     FarmType);

            NotifyOfPropertyChange("");
        }

        public void Handle([NotNull] MillersChangedEvent message)
        {
            Millers = message.Millers;
            SelectedMiller = Millers.FirstOrDefault();

            NotifyOfPropertyChange(() => Millers);
        }

        public void Handle([NotNull] SelectedFarmChangedEvent message)
        {
            var request = new FarmRequestEvent
                          {
                              FarmId = message.FarmId
                          };

            m_EventAggregator.PublishOnBackgroundThread(request);
        }

        private void PopulateAvailableFarmTypes()
        {
            string[] available = Enum.GetNames(typeof( FarmType )).ToArray();
            AvailableFarmTypes = available;

            NotifyOfPropertyChange(() => AvailableFarmTypes);

            if ( available.Length > 0 )
            {
                SelectedAvailableFarmType = available.First();
            }
        }
    }
}