using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using JetBrains.Annotations;
using NLog;
using Selkie.Windsor;

namespace DSim.Common
{
    [ProjectComponent(Lifestyle.Transient)]
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public sealed class Disposer
        : IDisposer,
          IDisposable
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly Stack <Action> m_DisposeActions;
        private readonly object m_Owner;
        private volatile bool m_IsDisposed;

        public Disposer()
            : this(string.Empty)
        {
        }

        public Disposer([NotNull] object owner)
        {
            m_Owner = owner;
            m_DisposeActions = new Stack <Action>();
        }

        public string OwnerName
        {
            get
            {
                return m_Owner == null
                           ? "Unknown Object"
                           : m_Owner.GetType().Name;
            }
        }

        public bool IsDisposed
        {
            get
            {
                return m_IsDisposed;
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        public void Dispose()
        {
            m_IsDisposed = true;

            Action[] actions;

            lock ( m_DisposeActions )
            {
                actions = m_DisposeActions.ToArray();
                m_DisposeActions.Clear();
            }

            ExecuteActions(actions);
        }

        [DebuggerNonUserCode]
        public void VerifyNotDisposed()
        {
            if ( m_IsDisposed )
            {
                throw new ObjectDisposedException(OwnerName,
                                                  "The attempted operation can no longer be performed, " +
                                                  "this object has been disposed.");
            }
        }

        public T AddResource <T>(T resource) where T : class, IDisposable
        {
            Push(resource.Dispose);

            return resource;
        }

        public void AddResource(Action disposeAction)
        {
            Push(disposeAction);
        }

        private static void ExecuteActions([NotNull] IEnumerable <Action> actions)
        {
            Exception disposeException = null;

            foreach ( Action action in actions )
            {
                try
                {
                    action();
                }
                catch ( Exception exception )
                {
                    Logger.Error(exception,
                                 "Failed to execute a disposal action");

                    if ( disposeException == null )
                    {
                        disposeException = exception;
                    }
                }
            }

            if ( disposeException != null )
            {
                throw new TargetInvocationException(disposeException);
            }
        }

        private void Push([NotNull] Action disposeAction)
        {
            if ( m_IsDisposed )
            {
                disposeAction();
            }
            else
            {
                lock ( m_DisposeActions )
                {
                    m_DisposeActions.Push(disposeAction);
                }
            }
        }
    }
}