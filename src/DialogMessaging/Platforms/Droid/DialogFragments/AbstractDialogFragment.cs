using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.DialogFragments
{
    public abstract class AbstractDialogFragment : DialogFragment, View.IOnClickListener, IValueAssigner
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

    public abstract class AbstractDialogFragment<TConfig> : AbstractDialogFragment
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
        /// <param name="dialogElement">The dialog element extracted from the view.</param>
        public override void AssignValue(KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
            base.AssignValue(dialogElement);

            if (dialogElement.Key.Equals(DialogElement.Message))
            {
                if (!string.IsNullOrWhiteSpace(Config.Message) && dialogElement.Value.Item1.TrySetText(Config.Message))
                    return;

                dialogElement.HideElementIfNeeded();

                return;
            }
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public virtual void CreateDialog(AlertDialog.Builder builder)
        {
            builder.SetMessage(Config.Message);
        }
        #endregion

        #region Lifecycle
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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

            _canRunDismiss = true;
            SetStyle(DialogFragmentStyle.NoFrame, Config.StyleID ?? 0);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (Config.LayoutID == null)
                return base.OnCreateView(inflater, container, savedInstanceState);

            return new CustomLayoutInflater(Context, this).Inflate((int)Config.LayoutID, null, false);
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
            MessagingService.SaveInstance(outState, Config);
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
