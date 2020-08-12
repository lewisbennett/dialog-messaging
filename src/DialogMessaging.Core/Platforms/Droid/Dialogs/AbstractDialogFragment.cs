using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public abstract class AbstractDialogFragment : DialogFragment, View.IOnClickListener
    {
        #region Properties
        /// <summary>
        /// Gets the collection of views that have event handlers assigned to them.
        /// </summary>
        public IDictionary<View, string> EventHandlerViews { get; } = new Dictionary<View, string>();
        #endregion

        #region Event Handlers
        public void OnClick(View view)
        {
            var viewExists = EventHandlerViews.TryGetValue(view, out string dialogElement);

            if (viewExists)
                OnRegisteredViewClick(dialogElement, view);
        }

        public virtual void OnRegisteredViewClick(string dialogElement, View view)
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Registers a view to send click events to this dialog.
        /// </summary>
        /// <param name="dialogElement">The dialog element.</param>
        /// <param name="view">The view to register click events for.</param>
        public void RegisterForClickEvents(string dialogElement, View view)
        {
            if (view == null)
                return;

            view.SetOnClickListener(this);
            EventHandlerViews.Add(view, dialogElement);
        }
        #endregion

        #region Constructors
        protected AbstractDialogFragment()
            : base()
        {
        }

        protected AbstractDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }

    public abstract class AbstractDialogFragment<TConfig> : AbstractDialogFragment, IValueAssigner
        where TConfig : IBaseConfig
    {
        #region Fields
        private bool _canRunDismiss;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the config being used for the dialog.
        /// </summary>
        public TConfig Config { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="viewConfig">The view configuration.</param>
        public virtual void AssignValue(ViewConfig viewConfig)
        {
            switch (viewConfig.DialogElement)
            {
                case DialogElement.Title:

                    if (string.IsNullOrWhiteSpace(Config.Title) || !viewConfig.View.TrySetText(Config.Title))
                        viewConfig.HideElementIfNeeded();

                    break;

                case DialogElement.Message:

                    if (string.IsNullOrWhiteSpace(Config.Message) || !viewConfig.View.TrySetText(Config.Message))
                        viewConfig.HideElementIfNeeded();

                    break;
            }

            MessagingServiceCore.InflatedViews.Remove(viewConfig.View);
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public virtual void CreateDialog(AlertDialog.Builder builder)
        {
            builder.SetTitle(Config.Title);
            builder.SetMessage(Config.Message);
        }
        #endregion

        #region Lifecycle
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RetainInstance = true;

            if (Config == null)
            {
                Config = MessagingServiceCore.RetrieveInstance<TConfig>(savedInstanceState);

                if (Config == null)
                {
                    ShowsDialog = false;
                    Dismiss();

                    return;
                }
            }

            _canRunDismiss = true;

            if (Config.StyleID != null)
                SetStyle(DialogFragmentStyle.NoFrame, (int)Config.StyleID);

            Cancelable = Config.Cancelable;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (Config.LayoutID == null)
                return base.OnCreateView(inflater, container, savedInstanceState);

            return MessagingServiceCore.ViewCreator.CreateView(this, (int)Config.LayoutID, container, false);
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            if (Config.LayoutID != null)
                return base.OnCreateDialog(savedInstanceState);

            var builder = new AlertDialog.Builder(Context, Config.StyleID ?? 0);

            CreateDialog(builder);

            return builder.Create();
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);

            if (_canRunDismiss)
                Config.DismissedAction?.Invoke();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            _canRunDismiss = false;
            MessagingServiceCore.SaveInstance(outState, Config);
        }

        public override void OnDestroyView()
        {
            if (Dialog != null && RetainInstance)
                Dialog.SetDismissMessage(null);

            base.OnDestroyView();
        }
        #endregion

        #region Constructors
        protected AbstractDialogFragment()
            : base()
        {
        }

        protected AbstractDialogFragment(TConfig config)
            : base()
        {
            Config = config;
        }

        protected AbstractDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
