using System;
using System.Linq;
using Agtrix.DataAccess.Entities;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Agtrix.DataAccess.Repositories
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class PrePopulateRepositories
        : IPrePopulateRepositories
    {
        public PrePopulateRepositories(
            [NotNull] IMillersRepository millersRepository,
            [NotNull] IFarmsRepository farmsRepository,
            [NotNull] IPaddocksRepository paddocksRepository)
        {
            m_MillersRepository = millersRepository;
            m_FarmsRepository = farmsRepository;
            m_PaddocksRepository = paddocksRepository;
        }

        private const int MaxNumberOfMillers = 10;
        private const int MaxNumberOfFarms = 100;
        private const int MaxNumberOfPaddocks = 20;
        private readonly IFarmsRepository m_FarmsRepository;

        private readonly IMillersRepository m_MillersRepository;
        private readonly IPaddocksRepository m_PaddocksRepository;

        public void PrePopulate()
        {
            CreateMillers();
            CreateFarms();
            CreatePaddocks();
        }

        private void CreateFarms()
        {
            IMiller[] millers = m_MillersRepository.All.ToArray();

            for ( var i = 1 ; i <= MaxNumberOfFarms ; i++ )
            {
                Guid millerId = millers [ ( i - 1 ) % 10 ].Id;

                DateTime harvested = DateTime.Now
                                             .Subtract(TimeSpan.FromDays(i));

                var farm = new Farm
                           {
                               FieldsCode = "FieldsCode " + i,
                               FarmType = FarmType.Cane,
                               Name = "Farm " + i,
                               Harvested = harvested,
                               MillerId = millerId
                           };

                m_FarmsRepository.Save(farm);
            }
        }

        private void CreateMillers()
        {
            for ( var i = 1 ; i <= MaxNumberOfMillers ; i++ )
            {
                var miller = new Miller
                             {
                                 Id = Guid.NewGuid(),
                                 Name = "Miller " + i,
                                 Address = "Miller Address " + i
                             };

                m_MillersRepository.Save(miller);
            }
        }

        private void CreatePaddocks()
        {
            IFarm[] farms = m_FarmsRepository.All.ToArray();

            foreach ( IFarm farm in farms )
                for ( var i = 1 ; i <= MaxNumberOfPaddocks ; i++ )
                {
                    var paddock = new Paddock
                                  {
                                      FieldsCode = "Field Code " + i,
                                      AreaInHectares = i,
                                      FarmId = farm.Id
                                  };


                    m_PaddocksRepository.Save(paddock);
                }
        }
    }
}