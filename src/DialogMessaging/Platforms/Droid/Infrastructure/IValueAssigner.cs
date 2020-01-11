using Android.Views;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Infrastructure
{
    public interface IValueAssigner
    {
        #region Public Methods
        void AssignValues(IDictionary<string, Tuple<View, bool>> dialogElements);
        #endregion
    }
}
