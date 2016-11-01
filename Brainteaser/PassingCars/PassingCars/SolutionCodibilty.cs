using System.Collections;
using System.Collections.Generic;

namespace PassingCars
{
    public class SolutionCodibilty
    {
        public int Solution(int[] eastWest)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            var passings = new Hashtable();

            for (int i = 0; i < eastWest.Length; i++)
            {
                for(int j = 0; j <eastWest.Length; j++)
                {
                    if (i==j)
                    {
                        continue;
                    }

                    var carPair = new CarPair(eastWest,
                                                     i,
                                                     j);

                    var hashCode = carPair.GetHashCode();
                    var isContains = passings.ContainsKey(hashCode);

                    if (carPair.IsValid &&
                        !isContains)
                    {
                        passings.Add(hashCode, carPair);
                    }
                }
            }

            var array = new CarPair[passings.Values.Count];
            passings.Values.CopyTo(array,0);

            return passings.Values.Count;
        } 
    }

    public class CarPair : IEqualityComparer<CarPair>
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as CarPair;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var one = (m_CarOne < m_CarTwo) ? m_CarOne : m_CarTwo;
                var two = (m_CarOne < m_CarTwo) ? m_CarTwo : m_CarOne;

                return (one * 397) ^ two;
            }
        }

        public bool Equals(CarPair other)
        {
            return (m_CarOne == other.m_CarOne &&
                    m_CarTwo == other.m_CarTwo) ||
                   (m_CarOne == other.m_CarTwo &&
                    m_CarTwo == other.m_CarOne);
        }

        private readonly bool m_IsValid;
        private readonly int m_CarOne;
        private readonly int m_CarTwo;

        public CarPair(int[] eastWest,
            int one,
            int two)
        {
            m_CarOne = one;
            m_CarTwo = two;

            if (one == two)
            {
                m_IsValid = false;
            }
            else
            {
                m_IsValid = eastWest[m_CarOne] != eastWest[m_CarTwo];
            }
        }

        public bool IsValid
        {
            get
            {
                return m_IsValid;
            }
        }

        public int CarOne
        {
            get { return m_CarOne; }
        }

        public int CarTwo
        {
            get { return m_CarTwo; }
        }

        public override string ToString()
        {
            var text = "[" + m_CarOne + " - " + m_CarTwo + "] " + m_IsValid;

            return text;
        }

        public bool Equals(CarPair x,
                           CarPair y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(CarPair obj)
        {
            return obj.GetHashCode();
        }
    }
}