using System.Globalization;
using JetBrains.Annotations;

namespace ParkIQ.Extensions
{
    public static class StringExtensions
    {
        [NotNull]
        [StringFormatMethod("format")]
        public static string Inject([NotNull] this string format,
                                    [NotNull] params object[] arguments)
        {
            return string.Format(CultureInfo.CurrentCulture,
                                 format,
                                 arguments);
        }
    }
}