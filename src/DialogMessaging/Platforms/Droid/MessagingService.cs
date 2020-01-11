using Android.App;
using Android.OS;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid;
using System.Collections.Generic;

namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Constant Values
        public const string BundleKey = "DialogMessagingConfigKey";
        #endregion

        #region Fields
        private static long _savedInstanceCounter;
        private static readonly IDictionary<long, object> _savedInstances = new Dictionary<long, object>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves a saved instance, or default.
        /// </summary>
        public static TConfig RetrieveInstance<TConfig>(Bundle bundle)
            where TConfig : IBaseConfig
        {
            var saveId = bundle?.GetLong(BundleKey) ?? -1;

            var success = _savedInstances.TryGetValue(saveId, out object config);

            if (!success)
                return default;

            _savedInstances.Remove(saveId);

            if (config is TConfig tConfig)
                return tConfig;

            return default;
        }

        /// <summary>
        /// Saves a dialog's instance state.
        /// </summary>
        /// <param name="bundle">The saved instance bundle.</param>
        /// <param name="config">The dialog config.</param>
        public static void SaveInstance(Bundle bundle, object config)
        {
            _savedInstanceCounter++;

            _savedInstances.Add(_savedInstanceCounter, config);
            bundle.PutLong(BundleKey, _savedInstanceCounter);
        }
        #endregion

        #region Initialization
        public static void Init(Activity activity)
        {
            Instance = new MessagingServiceImpl();
            ActivityLifecycleCallbacks.Register(activity);
        }

        public static void Init(Application application)
        {
            Instance = new MessagingServiceImpl();
            ActivityLifecycleCallbacks.Register(application);
        }

        public static void Init(Activity activity, IMessagingService messagingService)
        {
            Instance = messagingService;
            ActivityLifecycleCallbacks.Register(activity);
        }

        public static void Init(Application application, IMessagingService messagingService)
        {
            Instance = messagingService;
            ActivityLifecycleCallbacks.Register(application);
        }
        #endregion
    }
}
