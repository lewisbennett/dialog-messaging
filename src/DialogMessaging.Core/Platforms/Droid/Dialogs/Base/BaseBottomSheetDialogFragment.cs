using System;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions.Base;
using DialogMessaging.Schema;
using Google.Android.Material.BottomSheet;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs.Base;

public abstract class BaseBottomSheetDialogFragment<TConfig> : BottomSheetDialogFragment
    where TConfig : class, IBaseDialogConfig
{
    #region Properties
    /// <summary>
    ///     Gets the configuration for the dialog.
    /// </summary>
    public TConfig Config { get; internal set; }
    #endregion

    #region Protected Methods
    protected virtual void ConfigureView(View view, string dialogElement, bool autoHide)
    {
        switch (view, dialogElement)
        {
            case (TextView textView, DialogElement.Message):

                if (string.IsNullOrWhiteSpace(Config.Message) && autoHide)
                    textView.Visibility = ViewStates.Gone;
                else
                    textView.Text = Config.Message;

                return;

            case (TextView textView, DialogElement.Title):

                if (string.IsNullOrWhiteSpace(Config.Title) && autoHide)
                    textView.Visibility = ViewStates.Gone;
                else
                    textView.Text = Config.Title;

                return;

            default:

                return;
        }
    }

    protected abstract int GetDefaultLayoutResourceID();
    #endregion

    #region Lifecycle
    public override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Config could be null because the dialog's state has been saved, or something has gone wrong.
        if (Config == null)
        {
            Config = MessagingServiceCore.RetrieveInstance<TConfig>(savedInstanceState);

            // If retrieving the configuration failed, don't attempt to show the dialog.
            if (Config == null)
            {
                ShowsDialog = false;
                Dismiss();

                return;
            }
        }

        if (Config.StyleResID.HasValue)
            SetStyle(StyleNoFrame, Config.StyleResID.Value);

        Cancelable = Config.Cancelable;
    }

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        return MessagingServiceCore.ViewManager.InflateView(Config.LayoutResID ?? GetDefaultLayoutResourceID(), container, false, ConfigureView);
    }

    public override void OnDismiss(IDialogInterface dialog)
    {
        base.OnDismiss(dialog);

        // If the state is saved then the dialog will be viewed again (the screen could be rotating), so don't run  the dismissed action.
        if (!IsStateSaved)
            Config.DismissedAction?.Invoke();
    }

    public override void OnSaveInstanceState(Bundle outState)
    {
        base.OnSaveInstanceState(outState);

        MessagingServiceCore.SaveInstance(outState, Config);
    }

    public override void OnDestroyView()
    {
        // Prevents an unknown exception.
        if (Dialog != null)
            Dialog.SetDismissMessage(null);

        base.OnDestroyView();
    }
    #endregion

    #region Constructors
    protected BaseBottomSheetDialogFragment()
    {
    }

    protected BaseBottomSheetDialogFragment(TConfig config)
    {
        Config = config;
    }

    protected BaseBottomSheetDialogFragment(IntPtr handle, JniHandleOwnership transfer)
        : base(handle, transfer)
    {
    }
    #endregion
}