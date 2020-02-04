using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
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
        private static readonly IViewCreator _fallbackViewCreator = new FallbackViewCreator();
        private static IViewCreator _viewCreator;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the view creator.
        /// </summary>
        public static IViewCreator ViewCreator
        {
            get => _viewCreator ?? _fallbackViewCreator;

            set => _viewCreator = value;
        }

        /// <summary>
        /// Gets the views that have been inflated.
        /// </summary>
        public static IDictionary<View, ViewConfig> InflatedViews { get; } = new Dictionary<View, ViewConfig>();
        #endregion

        #region Event Handlers
        public static void OnViewInflated(View view, IAttributeSet attrs)
        {
            var dictionary = view.ExtractAttributedViews(attrs);

            foreach (var keyValuePair in dictionary)
                InflatedViews[keyValuePair.Key] = keyValuePair.Value;
        }
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

        public static void Init(Activity activity, IViewCreator viewCreator)
        {
            Instance = new MessagingServiceImpl();
            ViewCreator = viewCreator;
            ActivityLifecycleCallbacks.Register(activity);
        }

        public static void Init(Application application, IViewCreator viewCreator)
        {
            Instance = new MessagingServiceImpl();
            ViewCreator = viewCreator;
            ActivityLifecycleCallbacks.Register(application);
        }

        public static void Init(Activity activity, IMessagingService messagingService, IViewCreator viewCreator)
        {
            Instance = messagingService;
            ViewCreator = viewCreator;
            ActivityLifecycleCallbacks.Register(activity);
        }

        public static void Init(Application application, IMessagingService messagingService, IViewCreator viewCreator)
        {
            Instance = messagingService;
            ViewCreator = viewCreator;
            ActivityLifecycleCallbacks.Register(application);
        }
        #endregion
    }
}
