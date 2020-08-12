using DialogMessaging;
using DialogMessaging.Interactions;
using System;
using System.Threading.Tasks;

namespace Sample.iOS.Messaging
{
    public class AsyncMessaging : IMessaging
    {
        public async void ActionSheet()
        {
            var config = new ActionSheetAsyncConfig
            {
                Title = "Action Sheet Async",
                Message = "Hello world!",
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemAsyncConfig { Text = "Item 1" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Text = "Item 2" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Text = "Item 3" });

            var item = await MessagingServiceCore.Instance.ActionSheetAsync(config).ConfigureAwait(false);

            if (item != null)
                MessagingServiceCore.Instance.Toast($"Clicked: {item.Text}");
        }

        public async void ActionSheetBottom()
        {
            var config = new ActionSheetBottomAsyncConfig
            {
                Title = "Action Sheet Bottom Async",
                Message = "Hello world!",
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemAsyncConfig { Text = "Item 1" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Text = "Item 2" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Text = "Item 3" });

            var item = await MessagingServiceCore.Instance.ActionSheetBottomAsync(config).ConfigureAwait(false);

            if (item != null)
                MessagingServiceCore.Instance.Toast($"Clicked: {item.Text}");
        }

        public async void Alert()
        {
            await MessagingServiceCore.Instance.AlertAsync(new AlertAsyncConfig
            {
                Title = "Alert Async",
                Message = "Hello world!",
                OkButtonText = "Okay"

            }).ConfigureAwait(false);

            MessagingServiceCore.Instance.Snackbar("Alerted");
        }

        public async void Confirm()
        {
            var confirmed = await MessagingServiceCore.Instance.ConfirmAsync(new ConfirmAsyncConfig
            {
                Title = "Confirm Async",
                Message = "Hello world!",
                ConfirmButtonText = "Confirm",
                CancelButtonText = "Cancel"

            }).ConfigureAwait(false);

            MessagingServiceCore.Instance.Snackbar(confirmed ? "Confirmed" : "Cancelled");
        }

        public async void Delete()
        {
            var deleted = await MessagingServiceCore.Instance.DeleteAsync(new DeleteAsyncConfig
            {
                Title = "Delete Async",
                Message = "Hello world!",
                DeleteButtonText = "Delete",
                CancelButtonText = "Cancel"
            });

            MessagingServiceCore.Instance.Snackbar(deleted ? "Deleted" : "Cancelled");
        }

        public async void Loading()
        {
            await MessagingServiceCore.Instance.ShowLoadingAsync(new LoadingAsyncConfig { Title = "Loading Async", Message = "Hello World!" }, Task.Delay(TimeSpan.FromSeconds(5))).ConfigureAwait(false);
        }

        public async void Prompt()
        {
            var entry = await MessagingServiceCore.Instance.PromptAsync(new PromptAsyncConfig
            {
                Title = "Prompt Async",
                Message = "Hello world!",
                Hint = "Enter some text",
                ConfirmButtonText = "Enter",
                CancelButtonText = "Cancel"

            }).ConfigureAwait(false);

            MessagingServiceCore.Instance.Snackbar($"You entered: {entry}");
        }

        public void Snackbar()
        {
            MessagingServiceCore.Instance.Snackbar(new SnackbarConfig
            {
                Message = "Snackbar",
                ActionButtonText = "Action",
                ActionButtonClickAction = Toast
            });
        }

        public void Toast()
        {
            MessagingServiceCore.Instance.Toast(new ToastConfig
            {
                Message = "Toast"
            });
        }
    }
}