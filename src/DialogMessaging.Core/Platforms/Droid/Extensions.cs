﻿using Android.App;
using Android.Content;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using DialogMessaging.Core;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using Google.Android.Material.Snackbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DM_Log = DialogMessaging.Infrastructure.Log;

namespace DialogMessaging
{
    public static partial class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Applies styling to the snackbar based on configuration values.
        /// </summary>
        /// <param name="config">The snackbar configuration.</param>
        public static void ApplyStyling(this Snackbar snackbar, ISnackbarConfig config)
        {
            if (snackbar == null || config == null)
                return;

            if (config.BackgroundColor.HasValue)
                snackbar.View.SetBackgroundColor(config.BackgroundColor.Value);

            if (!string.IsNullOrWhiteSpace(config.ActionButtonText))
            {
                snackbar.SetAction(config.ActionButtonText, (v) => config?.ActionButtonClickAction());

                if (config.ActionButtonTextColor.HasValue)
                    snackbar.SetActionTextColor(config.ActionButtonTextColor.Value);
            }

            if (snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_text) is TextView textView)
            {
                if (config.MessageTextColor.HasValue)
                    textView.SetTextColor(config.MessageTextColor.Value);

                if (config.MessageTypeface != null)
                    textView.SetTypeface(config.MessageTypeface, config.MessageTypefaceStyle);
            }
        }

        /// <summary>
        /// Extracts attributed values from a view and its subviews, if any. Returns a dictionary where the key is the dialog element and the value is the target view and whether it should be hidden when no value is available.
        /// </summary>
        public static IDictionary<View, ViewConfig> ExtractAttributedViews(this View view, IAttributeSet attrs)
        {
            var dictionary = new Dictionary<View, ViewConfig>();

            if (view == null)
                return dictionary;

            var typedArray = view.Context.ObtainStyledAttributes(attrs, Resource.Styleable.DialogMessaging);

            if (typedArray != null)
            {
                var dialogElement = typedArray.GetString(Resource.Styleable.DialogMessaging_DialogElement);
                var hideWhenNotInUse = typedArray.GetBoolean(Resource.Styleable.DialogMessaging_HideWhenNotInUse, true);

                if (!string.IsNullOrWhiteSpace(dialogElement))
                    dictionary.Add(view, new ViewConfig { DialogElement = dialogElement, HideWhenNotInUse = hideWhenNotInUse, View = view });
            }

            if (view is ViewGroup viewGroup)
            {
                for (int i = 0; i < viewGroup.ChildCount; i++)
                {
                    foreach (var item in viewGroup.GetChildAt(i).ExtractAttributedViews(attrs))
                        dictionary[item.Key] = item.Value;
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Find a set of views that match a criteria within a view hierarchy.
        /// </summary>
        public static View[] Find(this View view, Func<View, bool> query)
        {
            var views = new List<View>();

            if (query.Invoke(view))
                views.Add(view);

            if (view is ViewGroup viewGroup)
            {
                for (var i = 0; i < viewGroup.ChildCount; i++)
                    views.AddRange(viewGroup.GetChildAt(i).Find(query));
            }

            return views.ToArray();
        }

        /// <summary>
        /// Hides a dialog element if needed.
        /// </summary>
        public static void HideElementIfNeeded(this ViewConfig viewConfig)
        {
            if (viewConfig.HideWhenNotInUse)
                viewConfig.View.Visibility = ViewStates.Gone;
        }

        /// <summary>
        /// Removes views associated with a context.
        /// </summary>
        public static void RemoveCachedViews(this Context context)
        {
            var removals = MessagingServiceCore.InflatedViews.Where(i => i.Value.View.Context == context).ToArray();

            foreach (var removal in removals)
                MessagingServiceCore.InflatedViews.Remove(removal);
        }

        /// <summary>
        /// Safely invokes an action on the UI thread.
        /// </summary>
        /// <param name="action">The action to perform on the UI thread.</param>
        public static void SafeRunOnUiThread(this Activity activity, Action action)
        {
            if (activity == null || action == null)
                return;

            activity.RunOnUiThread(() =>
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception e)
                {
                    DM_Log.Debug(string.Empty, e.ToString());
                }
            });
        }

        /// <summary>
        /// Sets the text property of a view, if available.
        /// </summary>
        /// <param name="text">The text to assign to the view.</param>
        public static bool TrySetText(this View view, string text)
        {
            if (view != null && view.GetType().GetProperty("Text") is PropertyInfo textProperty)
            {
                try
                {
                    textProperty.SetValue(view, text, null);
                    return true;
                }
                catch (Exception e)
                {
                    DM_Log.Error("TrySetText", $"Could not set text.\n{e}");
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the InputType as an Android InputTypes.
        /// </summary>
        public static InputTypes ToInputTypes(this InputType inputType)
        {
            return inputType switch
            {
                InputType.Decimal => InputTypes.ClassNumber | InputTypes.NumberFlagDecimal,
                InputType.Default => InputTypes.ClassText,
                InputType.EmailAddress => InputTypes.ClassText | InputTypes.TextVariationEmailAddress,
                InputType.Integer => InputTypes.ClassNumber,
                InputType.Name => InputTypes.ClassText | InputTypes.TextFlagCapWords,
                InputType.Password => InputTypes.ClassText | InputTypes.TextVariationPassword,
                InputType.PhoneNumber => InputTypes.ClassPhone,
                InputType.URI => InputTypes.ClassText | InputTypes.TextVariationUri,
                _ => InputTypes.ClassText,
            };
        }
        #endregion
    }
}
