using Android.App;
using Android.OS;
using Android.Views;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid;
using System.Collections.Generic;

namespace DialogMessaging.Infrastructure
{
    public static partial class MessagingServiceCore
    {
        #region Constant Values
        public const string BundleKey = "DialogMessagingConfigKey";
        #endregion

        #region Fields
        private static readonly IViewCreator _fallbackViewCreator = new FallbackViewCreator();
        private static long _savedInstanceCounter;
        private static readonly IDictionary<long, object> _savedInstances = new Dictionary<long, object>();
        private static IViewCreator _viewCreator;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the views that have been inflated.
        /// </summary>
        public static IDictionary<View, ViewConfig> InflatedViews { get; } = new Dictionary<View, ViewConfig>();

        /// <summary>
        /// Gets or sets the view creator
        /// </summary>
        public static IViewCreator ViewCreator
        {
            get => _viewCreator ?? _fallbackViewCreator;

            set => _viewCreator = value;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The presumed top level activity.</param>
        /// <param name="messagingService">The IMessagingService instance to use.</param>
        /// <param name="viewCreator">The IViewCreator.</param>
        public static void Init(Activity activity, IMessagingService messagingService, IViewCreator viewCreator)
        {
            ActivityLifecycleCallbacks.Register(activity);

            Instance = messagingService ?? new MessagingServiceImpl();

            ViewCreator = viewCreator;
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The presumed top level application.</param>
        /// <param name="messagingService">The IMessagingService instance to use.</param>
        /// <param name="viewCreator">The IViewCreator.</param>
        public static void Init(Application application, IMessagingService messagingService, IViewCreator viewCreator)
        {
            ActivityLifecycleCallbacks.Register(application);

            Instance = messagingService ?? new MessagingServiceImpl();

            ViewCreator = viewCreator;
        }

        /// <summary>
        /// Retrieves a saved instance, or default.
        /// </summary>
        public static TConfig RetrieveInstance<TConfig>(Bundle bundle)
            where TConfig : IBaseConfig
        {
            var saveId = bundle?.GetLong(BundleKey) ?? -1;

            if (!_savedInstances.TryGetValue(saveId, out object config))
                return default;

            _savedInstances.Remove(saveId);

            return config is TConfig tConfig ? tConfig : default;
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
    }
}
