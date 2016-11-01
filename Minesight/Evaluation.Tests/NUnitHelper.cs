using System;
using System.Collections.Generic;
using System.Linq;
using Evaluation.Common;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Evaluation.Tests
{
    public static class NUnitHelper
    {
        private const double Tolerance = 0.00001;

        public static void AssertDouble(double expected,
                                        double actual)
        {
            AssertDouble(expected,
                         actual,
                         "");
        }

        public static void AssertDouble(double expected,
                                        double actual,
                                        [NotNull] string text)
        {
            string prefix = string.IsNullOrEmpty(text)
                                ? ""
                                : text + ": ";

            Assert.True(Math.Abs(expected - actual) < Tolerance,
                        "{0} expected = {1} but actual is {2}".Inject(prefix,
                                                                      expected,
                                                                      actual));
        }

        public static void AssertPoint3D([NotNull] IPoint3D expected,
                                         [NotNull] IPoint3D actual)
        {
            Assert.AreEqual(expected.Id,
                            actual.Id,
                            "Ids don't match");

            AssertDouble(expected.X,
                         actual.X,
                         "X");

            AssertDouble(expected.Y,
                         actual.Y,
                         "Y");

            AssertDouble(expected.Z,
                         actual.Z,
                         "Z");

            Assert.AreEqual(expected.Description,
                            actual.Description,
                            "Description doesn't match!");
        }

        public static void AssertPoint3Ds([NotNull] IEnumerable <IPoint3D> expected,
                                          [NotNull] IEnumerable <IPoint3D> actual)
        {
            IPoint3D[] expectedArray = expected.ToArray();
            IPoint3D[] actualArray = actual.ToArray();

            Assert.AreEqual(expectedArray.Length,
                            actualArray.Length,
                            "Length is different!");

            foreach ( IPoint3D point in expectedArray )
            {
                IPoint3D other = actualArray.FirstOrDefault(x => x.Id == point.Id);

                Assert.NotNull(other,
                               "Did not find expected point with ID {0}!".Inject(point.Id));

                AssertPoint3D(point,
                              other);
            }
        }

        public static void AssertDoubles([NotNull] IEnumerable <double> expected,
                                         [NotNull] IEnumerable <double> actual)
        {
            double[] expectedArray = expected.ToArray();
            double[] actualArray = actual.ToArray();

            Assert.AreEqual(expectedArray.Length,
                            actualArray.Length,
                            "Length is different!");

            for ( var i = 0 ; i < expectedArray.Length ; i++ )
            {
                double expectedValue = expectedArray [ i ];
                double actualValue = actualArray [ i ];

                AssertDouble(expectedValue,
                             actualValue,
                             "[{0}]".Inject(i));
            }
        }

        public static void AssertIntegers(IEnumerable <int> expected,
                                          IEnumerable <int> actual)
        {
            int[] expectedArray = expected.ToArray();
            int[] actualArray = actual.ToArray();

            Assert.AreEqual(expectedArray.Length,
                            actualArray.Length,
                            "Length is different!");

            for ( var i = 0 ; i < expectedArray.Length ; i++ )
            {
                int expectedValue = expectedArray [ i ];
                int actualValue = actualArray [ i ];

                Assert.AreEqual(expectedValue,
                                actualValue,
                                "[{0}] Expected value {1} but actual is {2}!".Inject(i,
                                                                                     expectedValue,
                                                                                     actualValue));
            }
        }
    }
}