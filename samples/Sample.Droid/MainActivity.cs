using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Sample.Droid.Messaging;
using ViewPump;
//using DialogMessaging;

namespace Sample.Droid;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Button _actionSheetButton, _actionSheetBottomButton, _alertButton, _confirmButton, _deleteButton, _loadingButton, _loginButton, _promptButton, _snackbarButton, _toastButton;
    private IMessaging _messaging;

    private void ActionSheetButton_Click(object sender, EventArgs e)
    {
        _messaging.ActionSheet();
    }

    private void ActionSheetBottomButton_Click(object sender, EventArgs e)
    {
        _messaging.ActionSheetBottom();
    }

    private void AlertButton_Click(object sender, EventArgs e)
    {
        _messaging.Alert();
    }

    private void ConfirmButton_Click(object sender, EventArgs e)
    {
        _messaging.Confirm();
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        _messaging.Delete();
    }

    private void LoadingButton_Click(object sender, EventArgs e)
    {
        _messaging.Loading();
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        _messaging.Login();
    }

    private void PromptButton_Click(object sender, EventArgs e)
    {
        _messaging.Prompt();
    }

    private void SnackbarButton_Click(object sender, EventArgs e)
    {
        _messaging.Snackbar();
    }

    private void ToastButton_Click(object sender, EventArgs e)
    {
        _messaging.Toast();
    }

    protected override void AttachBaseContext(Context @base)
    {
        // The base context must be wrapped by the intercepting service.
        // See ViewPump getting started for more details.
        base.AttachBaseContext(InterceptingService.Instance.WrapContext(@base));
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // The messaging service can also be initialized in your main activity.
        // We have initialized the messaging service inside MainApplication though instead.
        // See MainApplication for more details.
        //MessagingService.Init(this);

        SetContentView(Resource.Layout.activity_main);

        _actionSheetButton = FindViewById<Button>(Resource.Id.action_sheet_button);
        _actionSheetBottomButton = FindViewById<Button>(Resource.Id.action_sheet_bottom_button);
        _alertButton = FindViewById<Button>(Resource.Id.alert_button);
        _confirmButton = FindViewById<Button>(Resource.Id.confirm_button);
        _deleteButton = FindViewById<Button>(Resource.Id.delete_button);
        _loadingButton = FindViewById<Button>(Resource.Id.loading_button);
        _loginButton = FindViewById<Button>(Resource.Id.login_button);
        _promptButton = FindViewById<Button>(Resource.Id.prompt_button);
        _snackbarButton = FindViewById<Button>(Resource.Id.snackbar_button);
        _toastButton = FindViewById<Button>(Resource.Id.toast_button);

        // Choose which method set to test.
        _messaging = new SyncMessaging();
        //_messaging = new AsyncMessaging();
    }

    protected override void OnResume()
    {
        base.OnResume();

        _actionSheetButton.Click += ActionSheetButton_Click;
        _actionSheetBottomButton.Click += ActionSheetBottomButton_Click;
        _alertButton.Click += AlertButton_Click;
        _confirmButton.Click += ConfirmButton_Click;
        _deleteButton.Click += DeleteButton_Click;
        _loadingButton.Click += LoadingButton_Click;
        _loginButton.Click += LoginButton_Click;
        _promptButton.Click += PromptButton_Click;
        _snackbarButton.Click += SnackbarButton_Click;
        _toastButton.Click += ToastButton_Click;
    }

    protected override void OnPause()
    {
        base.OnPause();

        _actionSheetButton.Click -= ActionSheetButton_Click;
        _actionSheetBottomButton.Click -= ActionSheetBottomButton_Click;
        _alertButton.Click -= AlertButton_Click;
        _confirmButton.Click -= ConfirmButton_Click;
        _deleteButton.Click -= DeleteButton_Click;
        _loadingButton.Click -= LoadingButton_Click;
        _loginButton.Click += LoginButton_Click;
        _promptButton.Click -= PromptButton_Click;
        _snackbarButton.Click -= SnackbarButton_Click;
        _toastButton.Click -= ToastButton_Click;
    }
}