using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions.Base;
using DialogMessaging.Schema;
using AndroidX_AlertDialog = AndroidX.AppCompat.App.AlertDialog;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs.Base;

public abstract partial class BaseAppCompatDialogFragment<TConfig> : AppCompatDialogFragment
    where TConfig : class, IBaseDialogConfig
{
    #region Properties
    /// <summary>
    ///     Gets the configuration for the dialog.
    /// </summary>
    public TConfig Config { get; internal set; }
    #endregion

    #region Protected Methods
    protected virtual void ConfigureDialogBuilder(AndroidX_AlertDialog.Builder builder)
    {
        if (ShouldConfigureToBuilder(nameof(Config.Title)))
            builder.SetTitle(Config.Title);

        if (ShouldConfigureToBuilder(nameof(Config.Message)))
            builder.SetMessage(Config.Message);
    }

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

    protected virtual bool ShouldConfigureToBuilder(string configElement)
    {
        return configElement switch
        {
            nameof(Config.Message) => true,
            nameof(Config.Title) => true,
            _ => false
        };
    }
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
        // If a layout resource ID has been provided, create the view with the view manager.
        if (Config.LayoutResID.HasValue)
            return MessagingServiceCore.ViewManager.InflateView(Config.LayoutResID.Value, container, false, ConfigureView);

        return base.OnCreateView(inflater, container, savedInstanceState);
    }

    public override Dialog OnCreateDialog(Bundle savedInstanceState)
    {
        // If a layout resource ID has been provided, don't try to create the dialog.
        if (Config.LayoutResID.HasValue)
            return base.OnCreateDialog(savedInstanceState);

        var builder = new AndroidX_AlertDialog.Builder(Context, Config.StyleResID ?? 0);

        ConfigureDialogBuilder(builder);

        return builder.Create();
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
    protected BaseAppCompatDialogFragment()
        : base()
    {
    }

    protected BaseAppCompatDialogFragment(TConfig config)
        : base()
    {
        Config = config;
    }

    protected BaseAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
        : base(handle, transfer)
    {
    }
    #endregion
}