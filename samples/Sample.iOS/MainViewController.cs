using System;
using Sample.iOS.Messaging;
using UIKit;

namespace Sample.iOS
{
    public partial class MainViewController : UIViewController
    {
        private IMessaging _messaging;

        private void ActionSheetButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.ActionSheet();
        }

        private void ActionSheetBottomButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.ActionSheetBottom();
        }

        private void AlertButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Alert();
        }

        private void ConfirmButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Confirm();
        }

        private void DeleteButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Delete();
        }

        private void LoadingButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Loading();
        }

        private void LoginButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Login();
        }

        private void PromptButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Prompt();
        }

        private void SnackbarButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Snackbar();
        }

        private void ToastButton_TouchUpInside(object sender, EventArgs e)
        {
            _messaging.Toast();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Choose which method set to test.
            _messaging = new SyncMessaging();
            //_messaging = new AsyncMessaging();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ActionSheetButton.TouchUpInside += ActionSheetButton_TouchUpInside;
            ActionSheetBottomButton.TouchUpInside += ActionSheetBottomButton_TouchUpInside;
            AlertButton.TouchUpInside += AlertButton_TouchUpInside;
            ConfirmButton.TouchUpInside += ConfirmButton_TouchUpInside;
            DeleteButton.TouchUpInside += DeleteButton_TouchUpInside;
            LoadingButton.TouchUpInside += LoadingButton_TouchUpInside;
            LoginButton.TouchUpInside += LoginButton_TouchUpInside;
            PromptButton.TouchUpInside += PromptButton_TouchUpInside;
            SnackbarButton.TouchUpInside += SnackbarButton_TouchUpInside;
            ToastButton.TouchUpInside += ToastButton_TouchUpInside;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            ActionSheetButton.TouchUpInside -= ActionSheetButton_TouchUpInside;
            ActionSheetBottomButton.TouchUpInside -= ActionSheetBottomButton_TouchUpInside;
            AlertButton.TouchUpInside -= AlertButton_TouchUpInside;
            ConfirmButton.TouchUpInside -= ConfirmButton_TouchUpInside;
            DeleteButton.TouchUpInside -= DeleteButton_TouchUpInside;
            LoadingButton.TouchUpInside -= LoadingButton_TouchUpInside;
            LoginButton.TouchUpInside -= LoginButton_TouchUpInside;
            PromptButton.TouchUpInside -= PromptButton_TouchUpInside;
            SnackbarButton.TouchUpInside -= SnackbarButton_TouchUpInside;
            ToastButton.TouchUpInside -= ToastButton_TouchUpInside;
        }

        public MainViewController(IntPtr handle)
            : base(handle)
        {
        }
    }
}