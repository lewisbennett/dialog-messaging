using Android.Content;
using Android.Util;
using Android.Views;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Core.Platforms.Droid.ViewManager
{
    public interface IViewManager
    {
        #region Properties
        /// <summary>
        /// Gets the active Snackbar anchor views, if any.
        /// </summary>
        Dictionary<Context, View> SnackbarAnchorViews { get; }

        /// <summary>
        /// Gets the active Snackbar containers, if any.
        /// </summary>
        Dictionary<Context, View> SnackbarContainers { get; }

        /// <summary>
        /// Gets a cache of inflated views with DialogMessaging attributes.
        /// </summary>
        Dictionary<View, (string, bool)> ViewCache { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Inflates a view.
        /// </summary>
        /// <param name="layoutResId">The layout resource ID of the layout to inflate.</param>
        /// <param name="container">The view container, if any.</param>
        /// <param name="attachToRoot">Whether to attach this view ot the root view.</param>
        /// <param name="callback">A callback containing the newly inflated view, its dialog element and auto hide setting. Only invoked if the view has a DialogMessaging attribute.</param>
        View InflateView(int layoutResId, ViewGroup container, bool attachToRoot, Action<View, string, bool> callback = null);

        /// <summary>
        /// Called when a view has been inflated.
        /// </summary>
        /// <param name="view">The inflated view.</param>
        /// <param name="attrs">The view's attributes.</param>
        void OnViewInflated(View view, IAttributeSet attrs);
        #endregion
    }
}
