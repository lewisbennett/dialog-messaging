using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using DialogMessaging.Core;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using Google.Android.Material.BottomSheet;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public abstract class AbstractBottomSheetDialogFragment : BottomSheetDialogFragment, View.IOnClickListener
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
        protected AbstractBottomSheetDialogFragment()
            : base()
        {
        }
        
        protected AbstractBottomSheetDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }

    public abstract class AbstractBottomSheetDialogFragment<TConfig> : AbstractBottomSheetDialogFragment, IValueAssigner
        where TConfig : IBaseConfig
    {
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

            if (Config.StyleID != null)
                SetStyle(StyleNoFrame, (int)Config.StyleID);

            Cancelable = Config.Cancelable;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return MessagingServiceCore.ViewCreator.CreateView(this, Config.LayoutID ?? Resource.Layout.dialog_default_action_sheet_bottom, container, false);
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);

            Config.DismissedAction?.Invoke();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

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
        protected AbstractBottomSheetDialogFragment()
            : base()
        {
        }

        protected AbstractBottomSheetDialogFragment(TConfig config)
            : base()
        {
            Config = config;
        }

        protected AbstractBottomSheetDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
