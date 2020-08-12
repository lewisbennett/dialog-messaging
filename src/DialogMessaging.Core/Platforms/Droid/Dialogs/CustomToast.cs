using Android.Content;
using Android.Widget;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class CustomToast : IValueAssigner
    {
        #region Properties
        /// <summary>
        /// Gets the config being used for the toast.
        /// </summary>
        public IToastConfig Config { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public Context Context { get; }

        /// <summary>
        /// Gets the toast.
        /// </summary>
        public Toast Toast { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="viewConfig">The view configuration.</param>
        public void AssignValue(ViewConfig viewConfig)
        {
            switch (viewConfig.DialogElement)
            {
                case DialogElement.Message:

                    if (!viewConfig.View.TrySetText(Config.Message))
                        viewConfig.HideElementIfNeeded();

                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Constructors
        public CustomToast(Context context, IToastConfig config)
        {
            Config = config;
            Context = context;

            Toast = Toast.MakeText(Context, config.Message, config.Duration);

            if (Config.LayoutID != null)
                Toast.View = MessagingServiceCore.ViewCreator.CreateView(this, (int)Config.LayoutID, null, false);
        }
        #endregion
    }
}
