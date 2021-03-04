using Android.App;
using Android.Content;
using Android.Text;
using Android.Views;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DialogMessaging.Core.Platforms.Droid
{
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Gets the activity that the view belongs to.
        /// </summary>
        public static Activity GetActivity(this View view)
        {
            var context = view.Context;

            while (context is ContextWrapper contextWrapper)
            {
                if (context is Activity activity)
                    return activity;

                context = contextWrapper.BaseContext;
            }

            return null;
        }

        /// <summary>
        /// Finds all subviews that meet the query.
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
        /// Safely invoked an action on the UI thread.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        public static void SafeRunOnUIThread(this Activity activity, Action action)
        {
            activity.RunOnUiThread(() =>
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            });
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
