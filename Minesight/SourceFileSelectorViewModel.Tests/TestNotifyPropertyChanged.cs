using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.Tests
{
    [ExcludeFromCodeCoverage]
    public sealed class TestNotifyPropertyChanged : IDisposable
    {
        private readonly string m_ExpectedPropertyName;
        private readonly INotifyPropertyChanged m_Model;
        private readonly List <string> m_PropertyNames = new List <string>();

        public TestNotifyPropertyChanged(INotifyPropertyChanged model,
                                         string expectedPropertyName = null)
        {
            m_Model = model;
            m_Model.PropertyChanged += OnPropertyChanged;
            m_ExpectedPropertyName = expectedPropertyName;
        }

        public bool IsRaisedNotified { get; private set; }
        public string PropertyName { get; private set; }

        public bool IsExpectedNotified
        {
            get
            {
                return m_PropertyNames.Contains(m_ExpectedPropertyName);
            }
        }

        public void Dispose()
        {
            m_Model.PropertyChanged -= OnPropertyChanged;
        }

        public bool IsNotified([NotNull] string propertyName)
        {
            return m_PropertyNames.Contains(propertyName);
        }

        private void OnPropertyChanged(object sender,
                                       PropertyChangedEventArgs e)
        {
            IsRaisedNotified = true;
            PropertyName = e.PropertyName;

            if ( !m_PropertyNames.Contains(e.PropertyName) )
            {
                m_PropertyNames.Add(e.PropertyName);
            }
        }
    }
}