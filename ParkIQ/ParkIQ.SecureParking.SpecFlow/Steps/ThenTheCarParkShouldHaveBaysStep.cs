using NUnit.Framework;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;
using TechTalk.SpecFlow;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class ThenTheCarParkShouldHaveBaysStep : BaseStep
    {
        [Then(@"the car park should have (.*) bays")]
        public void ThenTheCarParkShouldHaveBays(int numberOfBays)
        {
            Assert.AreEqual(numberOfBays,
                            CarPark.NumberOfBays);
        }
    }
}