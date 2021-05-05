using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Sample.MvvmCross.Core.Messaging;

namespace Sample.MvvmCross.Core
{
    public class MainViewModel : MvxViewModel
    {
        public IMvxCommand ActionSheetButtonClickCommand { get; set; }

        public IMvxCommand ActionSheetBottomButtonClickCommand { get; set; }

        public IMvxCommand AlertButtonClickCommand { get; set; }

        public IMvxCommand ConfirmButtonClickCommand { get; set; }

        public IMvxCommand DeleteButtonClickCommand { get; set; }

        public IMvxCommand LoadingButtonClickCommand { get; set; }

        public IMvxCommand LoginButtonClickCommand { get; set; }

        public IMvxCommand PromptButtonClickCommand { get; set; }

        public IMvxCommand SnackbarButtonClickCommand { get; set; }

        public IMvxCommand ToastButtonClickCommand { get; set; }

        public override void Prepare()
        {
            base.Prepare();

            // Choose which method set to test.
            var messaging = new SyncMessaging();
            //var messaging = new AsyncMessaging();

            ActionSheetButtonClickCommand = new MvxCommand(messaging.ActionSheet);
            ActionSheetBottomButtonClickCommand = new MvxCommand(messaging.ActionSheetBottom);
            AlertButtonClickCommand = new MvxCommand(messaging.Alert);
            ConfirmButtonClickCommand = new MvxCommand(messaging.Confirm);
            DeleteButtonClickCommand = new MvxCommand(messaging.Delete);
            LoadingButtonClickCommand = new MvxCommand(messaging.Loading);
            LoginButtonClickCommand = new MvxCommand(messaging.Login);
            PromptButtonClickCommand = new MvxCommand(messaging.Prompt);
            SnackbarButtonClickCommand = new MvxCommand(messaging.Snackbar);
            ToastButtonClickCommand = new MvxCommand(messaging.Toast);
        }
    }
}
