using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces.Vehicles;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class ThenTheVehiclesDetailsShouldLookLikeThisStep : BaseStep
    {
        [Then(@"the vehicles details should look like this:")]
        public void ThenTheVehiclesDetailsShouldLookLikeThis(Table table)
        {
            Line[] expected = table.CreateSet <Line>().ToArray();
            Line[] actual = ListOfVehicleDetails().ToArray();

            Assert.AreEqual(expected.Length,
                            actual.Length,
                            "Count()");

            for ( var i = 0 ; i < expected.Length ; i++ )
            {
                string expectedOutput = expected [ i ].Output;
                string actualOutput = actual [ i ].Output;

                Assert.AreEqual(expectedOutput,
                                actualOutput,
                                "[{0}]".Inject(i));
            }
        }

        private IEnumerable <Line> ListOfVehicleDetails()
        {
            var lines = new List <Line>();

            foreach ( IVehicle vehicle in CarPark.Vehicles )
            {
                var line = new Line
                           {
                               Output = vehicle.ToString()
                           };

                lines.Add(line);
            }

            return lines;
        }

        private class Line
        {
            public string Output { get; set; }
        }
    }
}