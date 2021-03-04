using Android.OS;
using DialogMessaging.Core.Platforms.Droid.Callbacks;
using DialogMessaging.Core.Platforms.Droid.ViewManager;
using System.Collections.Generic;

namespace DialogMessaging.Infrastructure
{
    public static partial class MessagingServiceCore
    {
        #region Constant Values
        public const string SavedInstanceBundleKey = "saved_instance_bundle_key";
        #endregion

        #region Fields
        private static long _savedInstanceCounter;
        private static readonly Dictionary<long, object> _savedInstances = new Dictionary<long, object>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the active <see cref="IDialogMessagingActivityLifecycleCallbacks" />.
        /// </summary>
        public static IDialogMessagingActivityLifecycleCallbacks ActivityLifecycleCallbacks { get; internal set; }

        /// <summary>
        /// Gets the active <see cref="IViewManager" />.
        /// </summary>
        public static IViewManager ViewManager { get; internal set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves a saved object using the key stored in a bundle.
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        public static T RetrieveInstance<T>(Bundle bundle)
            where T : class
        {
            var objectKey = bundle?.GetLong(SavedInstanceBundleKey) ?? -1;

            if (_savedInstances.TryGetValue(objectKey, out object saved))
            {
                _savedInstances.Remove(objectKey);

                return saved as T;
            }

            return null;
        }

        /// <summary>
        /// Saves an object, and stores the object key in the bundle.
        /// </summary>
        /// <param name="bundle">The bundle to store the object key inside.</param>
        /// <param name="toSave">The object to save.</param>
        public static void SaveInstance<T>(Bundle bundle, T toSave)
            where T : class
        {
            _savedInstances[_savedInstanceCounter] = toSave;

            bundle.PutLong(SavedInstanceBundleKey, _savedInstanceCounter);

            _savedInstanceCounter++;
        }
        #endregion
    }
}
