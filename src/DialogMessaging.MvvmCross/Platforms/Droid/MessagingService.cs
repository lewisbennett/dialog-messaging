using Android.App;
using Android.Util;
using Android.Views;
using AndroidX.AppCompat.App;
using DialogMessaging.Core;
using DialogMessaging.Infrastructure;
using DialogMessaging.MvvmCross.Platforms.Droid.Infrastructure;
using DialogMessaging.Schema;

namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Event Handlers
        public static void OnViewInflated(View view, IAttributeSet attrs)
        {
            // Find and store/update all dialog based views.
            var dictionary = view.ExtractAttributedViews(attrs);

            foreach (var keyValuePair in dictionary)
                MessagingServiceCore.InflatedViews[keyValuePair.Key] = keyValuePair.Value;

            // Check to see if the view should be used as a Snackbar container for its context.
            var typedArray = view.Context.ObtainStyledAttributes(attrs, Resource.Styleable.DialogMessaging);

            if (typedArray != null)
            {
                var dialogElement = typedArray.GetString(Resource.Styleable.DialogMessaging_DialogElement);

                if (!string.IsNullOrWhiteSpace(dialogElement) && dialogElement.Equals(DialogElement.SnackbarContainer))
                    ActivityLifecycleCallbacks.SnackbarContainers[view.Context] = view;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The presumed top level Activity.</param>
        public static void Init(AppCompatActivity activity)
        {
            MessagingServiceCore.Init(activity, null, new MvvmCrossViewCreator());
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The presumed top level Application.</param>
        public static void Init(Application application)
        {
            MessagingServiceCore.Init(application, null, new MvvmCrossViewCreator());
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The presumed top level Activity.</param>
        /// <param name="messagingService">The IMessagingService to use.</param>
        public static void Init(AppCompatActivity activity, IMessagingService messagingService)
        {
            MessagingServiceCore.Init(activity, messagingService, new MvvmCrossViewCreator());
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The presumed top level Application.</param>
        /// <param name="messagingService">The IMessagingService to use.</param>
        public static void Init(Application application, IMessagingService messagingService)
        {
            MessagingServiceCore.Init(application, messagingService, new MvvmCrossViewCreator());
        }
        #endregion
    }
}
