using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Console
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public class SolutionHelper
    {
        public string ArrayToString(IEnumerable <int> array)
        {
            return string.Join(",",
                               array);
        }
    }
}