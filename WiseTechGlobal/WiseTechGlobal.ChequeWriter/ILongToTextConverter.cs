using JetBrains.Annotations;

namespace WiseTechGlobal.ChequeWriter
{
    public interface ILongToTextConverter
    {
        [NotNull]
        string Text { get; }

        void Convert(long number);
    }
}