using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DSim.Common
{
    public interface IDisposer
    {
        [NotNull]
        string OwnerName { get; }

        bool IsDisposed { get; }

        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        void Dispose();

        [DebuggerNonUserCode]
        void VerifyNotDisposed();

        [NotNull]
        T AddResource <T>([NotNull] T resource) where T : class, IDisposable;

        void AddResource([NotNull] Action disposeAction);
    }
}