using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public abstract class AbstractBottomSheetDialogFragment : BottomSheetDialogFragment, View.IOnClickListener, IValueAssigner
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
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="dialogElement">The dialog element extracted from the view.</param>
        public virtual void AssignValue(KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
        }

        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="dialogElements">The dialog elements that are attributed in the view.</param>
        public void AssignValues(IDictionary<string, Tuple<View, bool>> dialogElements)
        {
            if (dialogElements == null)
                return;

            foreach (var dialogElement in dialogElements)
                AssignValue(dialogElement);
        }

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

    public abstract class AbstractBottomSheetDialogFragment<TConfig> : AbstractBottomSheetDialogFragment
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
        /// <param name="dialogElement">The dialog element extracted from the view.</param>
        public override void AssignValue(KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
            base.AssignValue(dialogElement);

            switch (dialogElement.Key)
            {
                case DialogElement.Title:

                    if (!string.IsNullOrWhiteSpace(Config.Title) && dialogElement.Value.Item1.TrySetText(Config.Title))
                        return;

                    break;

                case DialogElement.Message:

                    if (!string.IsNullOrWhiteSpace(Config.Message) && dialogElement.Value.Item1.TrySetText(Config.Message))
                        return;

                    break;
            }

            dialogElement.HideElementIfNeeded();
        }
        #endregion

        #region Lifecycle
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RetainInstance = true;

            if (Config == null)
            {
                Config = MessagingService.RetrieveInstance<TConfig>(savedInstanceState);

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
            return new CustomLayoutInflater(Context, this).Inflate(Config.LayoutID ?? Resource.Layout.dialog_default_action_sheet_bottom, container, false);
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);

            Config.DismissedAction?.Invoke();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            MessagingService.SaveInstance(outState, Config);
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
