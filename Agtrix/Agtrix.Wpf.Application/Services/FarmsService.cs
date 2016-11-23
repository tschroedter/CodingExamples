using System;
using System.Collections.Generic;
using System.Linq;
using Agtrix.DataAccess.Entities;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using Agtrix.Wpf.Application.Dto;
using Agtrix.Wpf.Application.Interfaces.Services;
using Agtrix.Wpf.Application.Services.Events;
using Caliburn.Micro;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Agtrix.Wpf.Application.Services
{
    [ProjectComponent(Lifestyle.Startable)]
    public class FarmsService
        : BaseService,
          IFarmsService,
          IHandle <FarmSaveEvent>,
          IHandle <FarmRequestEvent>,
          IHandle <FarmCreateRequestEvent>,
          IHandle <FarmsMillersRequestEvent>
    {
        public FarmsService(
            [NotNull] ISelkieLogger logger,
            [NotNull] IEventAggregator eventAggregator,
            [NotNull] IFarmsRepository farmsRepository,
            [NotNull] IMillersRepository millersRepository)
            : base(logger)
        {
            m_EventAggregator = eventAggregator;
            m_FarmsRepository = farmsRepository;
            m_MillersRepository = millersRepository;

            m_EventAggregator.Subscribe(this);
        }

        private readonly IEventAggregator m_EventAggregator;
        private readonly IFarmsRepository m_FarmsRepository;
        private readonly IMillersRepository m_MillersRepository;

        public void Handle([NotNull] FarmCreateRequestEvent message)
        {
            IFarm farm = CreateNewFarm();
            m_FarmsRepository.Save(farm);

            PublishFarmsMillersChangedEvent(farm.Id);
        }

        public void Handle([NotNull] FarmRequestEvent message)
        {
            GetAndPublishFarm(message.FarmId);
        }

        public void Handle([NotNull] FarmSaveEvent message)
        {
            m_FarmsRepository.Save(message.Farm);

            GetAndPublishFarm(message.Farm.Id);
        }

        public void Handle(FarmsMillersRequestEvent message)
        {
            PublishFarmsMillersChangedEvent(message.SelectedFarmId);
        }

        private List <FarmMillerDto> CreateFarmMillerModels()
        {
            var farms = new List <FarmMillerDto>();

            foreach ( IFarm farm in m_FarmsRepository.All )
            {
                IMiller miller = m_MillersRepository.FindById(farm.MillerId); // todo maybe return default miller

                if ( miller == null )
                {
                    throw new ArgumentException("Unknown Miller with Id " + farm.MillerId + "!");
                }

                var dto = new FarmMillerDto // todo should use factory, check for other new statements in code 
                          {
                              FarmId = farm.Id,
                              FieldsCode = farm.FieldsCode,
                              FarmName = farm.Name,
                              Harvested = farm.Harvested,
                              FarmType = farm.FarmType,
                              MillerId = miller.Id,
                              MillerName = miller.Name
                          };

                farms.Add(dto);
            }

            return farms;
        }

        private IFarm CreateNewFarm()
        {
            IMiller defaultMiller = m_MillersRepository.All.First();

            var farm = new Farm
                       {
                           FieldsCode = "New Field Code",
                           Id = Guid.NewGuid(),
                           FarmType = FarmType.Cane,
                           Name = "New Farm",
                           Harvested = DateTime.Now,
                           MillerId = defaultMiller.Id
                       };

            return farm;
        }

        private void GetAndPublishFarm(Guid farmId)
        {
            IFarm farm = m_FarmsRepository.FindById(farmId);

            if ( farm == null )
            {
                return;
            }

            IMiller miller = m_MillersRepository.FindById(farm.MillerId);

            if ( miller == null )
            {
                return;
            }

            PublishFarmChangedEvent(farm,
                                    miller);
        }

        private void PublishFarmChangedEvent(IFarm farm,
                                             IMiller miller)
        {
            var dto = new FarmMillerDto
                      {
                          FarmId = farm.Id,
                          FieldsCode = farm.FieldsCode,
                          FarmName = farm.Name,
                          Harvested = farm.Harvested,
                          FarmType = farm.FarmType,
                          MillerId = miller.Id,
                          MillerName = miller.Name
                      };

            var changed = new FarmChangedEvent
                          {
                              FarmMillerDto = dto
                          };

            m_EventAggregator.PublishOnBackgroundThread(changed);
        }

        private void PublishFarmsMillersChangedEvent(Guid selectedFarmId)
        {
            List <FarmMillerDto> farms = CreateFarmMillerModels();

            var farmsChangedEvent = new FarmsMillersChangedEvent
                                    {
                                        FarmMillerDtos = farms,
                                        SelectedFarmId = selectedFarmId
                                    };

            m_EventAggregator.PublishOnBackgroundThread(farmsChangedEvent);
        }
    }
}