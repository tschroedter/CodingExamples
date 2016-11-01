using System;
using System.Collections.Generic;

namespace XunitShould.Sdk
{
    internal class ExceptionComparer : IEqualityComparer <Exception>
    {
        public static readonly ExceptionComparer Instance = new ExceptionComparer();

        public bool Equals(Exception x,
                           Exception y)
        {
            return ( x.GetType() == y.GetType() ) && ( x.Message == y.Message );
        }

        public int GetHashCode(Exception obj)
        {
            return obj.GetHashCode();
        }
    }
}