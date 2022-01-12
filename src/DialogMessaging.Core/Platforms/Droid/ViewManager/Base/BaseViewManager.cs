using System;
using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using DialogMessaging.Infrastructure;
using DialogMessaging.Schema;

namespace DialogMessaging.Core.Platforms.Droid.ViewManager.Base;

public abstract class BaseViewManager : IViewManager
{
    #region Protected Methods
    protected virtual View InflateView(Context context, int layoutResId, ViewGroup container, bool attachToRoot)
    {
        return LayoutInflater.From(context).Inflate(layoutResId, container, attachToRoot);
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the active Snackbar anchor views, if any.
    /// </summary>
    public Dictionary<Context, View> SnackbarAnchorViews { get; } = new();

    /// <summary>
    ///     Gets the active Snackbar containers, if any.
    /// </summary>
    public Dictionary<Context, View> SnackbarContainers { get; } = new();

    /// <summary>
    ///     Gets a cache of inflated views with DialogMessaging attributes.
    /// </summary>
    public Dictionary<View, (string, bool)> ViewCache { get; } = new();
    #endregion

    #region Public Methods
    /// <summary>
    ///     Inflates a view.
    /// </summary>
    /// <param name="layoutResId">The layout resource ID of the layout to inflate.</param>
    /// <param name="container">The view container, if any.</param>
    /// <param name="attachToRoot">Whether to attach this view ot the root view.</param>
    /// <param name="callback">
    ///     A callback containing the newly inflated view, its dialog element and auto hide setting. Only
    ///     invoked if the view has a DialogMessaging attribute.
    /// </param>
    public virtual View InflateView(int layoutResId, ViewGroup container, bool attachToRoot, Action<View, string, bool> callback = null)
    {
        var view = InflateView(MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity, layoutResId, container, attachToRoot);

        // If no callback has been provided there isn't any point trying to find any attributes.
        if (callback != null)
            // Find the subviews with DialogMessaging attributes and assign values.
            foreach (var subview in view.Find(v => MessagingServiceCore.ViewManager.ViewCache.ContainsKey(v)))
            {
                var (dialogElement, autoHide) = MessagingServiceCore.ViewManager.ViewCache[subview];

                callback.Invoke(subview, dialogElement, autoHide);
            }

        return view;
    }

    /// <summary>
    ///     Called when a view has been inflated.
    /// </summary>
    /// <param name="view">The inflated view.</param>
    /// <param name="attrs">The view's attributes.</param>
    public virtual void OnViewInflated(View view, IAttributeSet attrs)
    {
        if (view.Context.ObtainStyledAttributes(attrs, Resource.Styleable.DialogMessaging) is TypedArray dialogMessagingStyleAttributes)
        {
            var dialogElement = dialogMessagingStyleAttributes.GetString(Resource.Styleable.DialogMessaging_DialogElement);

            if (!string.IsNullOrWhiteSpace(dialogElement))
                switch (dialogElement)
                {
                    // Snackbar anchor views and containers need to be stored seperately to dialog views.
                    case DialogElement.SnackbarAnchorView:

                        SnackbarAnchorViews[view.GetActivity()] = view;

                        return;

                    case DialogElement.SnackbarContainer:

                        SnackbarContainers[view.GetActivity()] = view;

                        return;

                    default:

                        ViewCache[view] = (dialogElement, dialogMessagingStyleAttributes.GetBoolean(Resource.Styleable.DialogMessaging_AutoHide, true));

                        return;
                }
        }
    }
    #endregion
}