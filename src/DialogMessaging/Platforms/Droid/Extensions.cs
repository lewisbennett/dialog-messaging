using Android.App;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid.Helper;
using System;
using System.Collections.Generic;
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

            var backgroundColor = ColorUtils.TryParseColor(config.BackgroundColorCalculator != null ? config.BackgroundColorCalculator.Invoke() : config.BackgroundColor);

            if (backgroundColor != null)
                snackbar.View.SetBackgroundColor((Color)backgroundColor);

            if (!string.IsNullOrWhiteSpace(config.ActionButtonText))
            {
                snackbar.SetAction(config.ActionButtonText, (v) => config?.ActionButtonClickAction());

                var actionButtonTextColor = ColorUtils.TryParseColor(config.ActionButtonTextColorCalculator != null ? config.ActionButtonTextColorCalculator.Invoke() : config.ActionButtonTextColor);

                if (actionButtonTextColor != null)
                    snackbar.SetActionTextColor((Color)actionButtonTextColor);
            }

            var textView = snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_text);

            if (textView == null)
                return;

            var textColor = ColorUtils.TryParseColor(config.TextColorCalculator != null ? config.TextColorCalculator.Invoke() : config.TextColor);

            if (textColor != null)
                snackbar.View.SetBackgroundColor((Color)textColor);
        }

        /// <summary>
        /// Applies styling to the toast based on configuration values.
        /// </summary>
        /// <param name="config">The toast configuration.</param>
        public static void ApplyStyling(this Toast toast, IToastConfig config)
        {
            if (toast == null || config == null || config.LayoutID == null)
                return;

            var view = LayoutInflater.From(Application.Context).Inflate((int)config.LayoutID, null, false);

            if (view == null)
            {
                Log.Error("Toast", "Could not display toast - custom layout was null after inflating.");
                return;
            }

            toast.View = view;
        }

        /// <summary>
        /// Extracts attributed values from a view and its subviews, if any. Returns a dictionary where the key is the dialog element and the value is the target view and whether it should be hidden when no value is available.
        /// </summary>
        public static IDictionary<string, Tuple<View, bool>> ExtractAttributedViews(this View view, IAttributeSet attrs)
        {
            if (view == null)
                return null;

            var dictionary = new Dictionary<string, Tuple<View, bool>>();

            var typedArray = view.Context.ObtainStyledAttributes(attrs, Resource.Styleable.DialogMessaging);

            if (typedArray != null)
            {
                var dialogElement = typedArray.GetString(Resource.Styleable.DialogMessaging_DialogElement);
                var hideWhenNotInUse = typedArray.GetBoolean(Resource.Styleable.DialogMessaging_HideWhenNotInUse, true);

                if (!string.IsNullOrWhiteSpace(dialogElement))
                    dictionary.Add(dialogElement, Tuple.Create(view, hideWhenNotInUse));
            }

            if (!(view is ViewGroup viewGroup))
                return dictionary;

            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                var dict = viewGroup.GetChildAt(i).ExtractAttributedViews(attrs);

                if (dict == null)
                    continue;

                foreach (var item in dict)
                    dictionary.Add(item.Key, item.Value);
            }

            return dictionary;
        }

        /// <summary>
        /// Hides a dialog element if needed.
        /// </summary>
        public static void HideElementIfNeeded(this KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
            if (dialogElement.Value.Item2)
                dialogElement.Value.Item1.Visibility = ViewStates.Gone;
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
                    action.Invoke();
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
            if (view == null)
                return false;

            var textProperty = view.GetType().GetProperty("Text");

            if (textProperty == null)
                return false;

            textProperty.SetValue(view, text, null);

            return true;
        }
        #endregion
    }
}
