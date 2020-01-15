using Android.App;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
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

            var backgroundColor = config.BackgroundColor ?? config.BackgroundColorCalculator?.Invoke();

            if (backgroundColor != null)
                snackbar.View.SetBackgroundColor((Color)backgroundColor);

            if (!string.IsNullOrWhiteSpace(config.ActionButtonText))
            {
                snackbar.SetAction(config.ActionButtonText, (v) => config?.ActionButtonClickAction());

                var actionButtonTextColor = config.ActionButtonTextColor ?? config.ActionButtonTextColorCalculator?.Invoke();

                if (actionButtonTextColor != null)
                    snackbar.SetActionTextColor((Color)actionButtonTextColor);
            }

            var textView = snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_text);

            if (textView == null)
                return;

            var textColor = config.MessageTextColor ?? config.MessageTextColorCalculator?.Invoke();

            if (textColor != null)
                textView.SetTextColor((Color)textColor);

            if (config.MessageTypeface != null)
                textView.SetTypeface(config.MessageTypeface, config.MessageTypefaceStyle);
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

            try
            {
                textProperty.SetValue(view, text, null);
                return true;
            }
            catch (Exception e)
            {
                DM_Log.Error("TrySetText", $"Could not set text.\n{e.ToString()}");
                return false;
            }
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
