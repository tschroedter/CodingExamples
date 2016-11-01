using JetBrains.Annotations;

namespace WiseTechGlobal.ChequeWriter
{
    public interface IDollarsCentsToLongConverter
    {
        long Dollars { get; }
        long Cents { get; }
        void Convert([NotNull] string dollarAndCentsAmount);
    }
}