using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Sample.MvvmCross.Core.Messaging;

namespace Sample.MvvmCross.Core
{
    public class MainViewModel : MvxViewModel
    {
        private IMessaging _messaging;

        public IMvxCommand ActionSheetButtonClickCommand { get; private set; }

        public IMvxCommand ActionSheetBottomButtonClickCommand { get; private set; }

        public IMvxCommand AlertButtonClickCommand { get; private set; }

        public IMvxCommand ConfirmButtonClickCommand { get; private set; }

        public IMvxCommand DeleteButtonClickCommand { get; private set; }

        public IMvxCommand LoadingButtonClickCommand { get; private set; }

        public IMvxCommand PromptButtonClickCommand { get; private set; }

        public IMvxCommand SnackbarButtonClickCommand { get; private set; }

        public IMvxCommand ToastButtonClickCommand { get; private set; }

        private void ActionSheetButton_Click()
        {
            _messaging.ActionSheet();
        }

        private void ActionSheetBottomButton_Click()
        {
            _messaging.ActionSheetBottom();
        }

        private void AlertButton_Click()
        {
            _messaging.Alert();
        }

        private void ConfirmButton_Click()
        {
            _messaging.Confirm();
        }

        private void DeleteButton_Click()
        {
            _messaging.Delete();
        }

        private void LoadingButton_Click()
        {
            _messaging.Loading();
        }

        private void PromptButton_Click()
        {
            _messaging.Prompt();
        }

        private void SnackbarButton_Click()
        {
            _messaging.Snackbar();
        }

        private void ToastButton_Click()
        {
            _messaging.Toast();
        }

        public override void Prepare()
        {
            base.Prepare();

            // Choose which method set to test.
            _messaging = new SyncMessaging();
            //_messaging = new AsyncMessaging();

            ActionSheetButtonClickCommand = new MvxCommand(ActionSheetButton_Click);
            ActionSheetBottomButtonClickCommand = new MvxCommand(ActionSheetBottomButton_Click);
            AlertButtonClickCommand = new MvxCommand(AlertButton_Click);
            ConfirmButtonClickCommand = new MvxCommand(ConfirmButton_Click);
            DeleteButtonClickCommand = new MvxCommand(DeleteButton_Click);
            LoadingButtonClickCommand = new MvxCommand(LoadingButton_Click);
            PromptButtonClickCommand = new MvxCommand(PromptButton_Click);
            SnackbarButtonClickCommand = new MvxCommand(SnackbarButton_Click);
            ToastButtonClickCommand = new MvxCommand(ToastButton_Click);
        }
    }
}
