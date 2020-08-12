using DialogMessaging;
using DialogMessaging.Interactions;
using System;
using System.Threading.Tasks;

namespace Sample.Droid.Messaging
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

            var item = await MessagingService.Instance.ActionSheetAsync(config).ConfigureAwait(false);

            if (item != null)
                MessagingService.Instance.Toast($"Clicked: {item.Text}");
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

            var item = await MessagingService.Instance.ActionSheetBottomAsync(config).ConfigureAwait(false);

            if (item != null)
                MessagingService.Instance.Toast($"Clicked: {item.Text}");
        }

        public async void Alert()
        {
            await MessagingService.Instance.AlertAsync(new AlertAsyncConfig
            {
                Title = "Alert Async",
                Message = "Hello world!",
                OkButtonText = "Okay"

            }).ConfigureAwait(false);

            MessagingService.Instance.Snackbar("Alerted");
        }

        public async void Confirm()
        {
            var confirmed = await MessagingService.Instance.ConfirmAsync(new ConfirmAsyncConfig
            {
                Title = "Confirm Async",
                Message = "Hello world!",
                ConfirmButtonText = "Confirm",
                CancelButtonText = "Cancel"

            }).ConfigureAwait(false);

            MessagingService.Instance.Snackbar(confirmed ? "Confirmed" : "Cancelled");
        }

        public async void Delete()
        {
            var deleted = await MessagingService.Instance.DeleteAsync(new DeleteAsyncConfig
            {
                Title = "Delete Async",
                Message = "Hello world!",
                DeleteButtonText = "Delete",
                CancelButtonText = "Cancel"
            });

            MessagingService.Instance.Snackbar(deleted ? "Deleted" : "Cancelled");
        }

        public async void Loading()
        {
            await MessagingService.Instance.ShowLoadingAsync(new LoadingAsyncConfig { Title = "Loading Async", Message = "Hello World!" }, Task.Delay(TimeSpan.FromSeconds(5))).ConfigureAwait(false);
        }

        public async void Prompt()
        {
            var entry = await MessagingService.Instance.PromptAsync(new PromptAsyncConfig
            {
                Title = "Prompt Async",
                Message = "Hello world!",
                Hint = "Enter some text",
                ConfirmButtonText = "Enter",
                CancelButtonText = "Cancel"

            }).ConfigureAwait(false);

            MessagingService.Instance.Snackbar($"You entered: {entry}");
        }

        public void Snackbar()
        {
            MessagingService.Instance.Snackbar(new SnackbarConfig
            {
                Message = "Snackbar",
                ActionButtonText = "Action",
                ActionButtonClickAction = Toast
            });
        }

        public void Toast()
        {
            MessagingService.Instance.Toast(new ToastConfig
            {
                Message = "Toast"
            });
        }
    }
}