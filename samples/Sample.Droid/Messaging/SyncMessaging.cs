using DialogMessaging;
using DialogMessaging.Interactions;
using System;
using System.Threading.Tasks;

namespace Sample.Droid.Messaging
{
    public class SyncMessaging : IMessaging
    {
        public void ActionSheet()
        {
            var config = new ActionSheetConfig
            {
                Title = "Action Sheet",
                Message = "Hello world!",
                ItemClickAction = (item) => MessagingService.Instance.Toast($"Clicked: {item.Text}"),
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemConfig { Text = "Item 1" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 2" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 3" });

            MessagingService.Instance.ActionSheet(config);
        }

        public void ActionSheetBottom()
        {
            var config = new ActionSheetBottomConfig
            {
                Title = "Action Sheet Bottom",
                Message = "Hello world!",
                ItemClickAction = (item) => MessagingService.Instance.Toast($"Clicked: {item.Text}"),
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemConfig { Text = "Item 1" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 2" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 3" });

            MessagingService.Instance.ActionSheetBottom(config);
        }

        public void Alert()
        {
            MessagingService.Instance.Alert(new AlertConfig
            {
                Title = "Alert",
                Message = "Hello world!",
                OkButtonText = "Okay",
                OkButtonClickAction = () => MessagingService.Instance.Snackbar("Okay-ed")
            });
        }

        public void Confirm()
        {
            MessagingService.Instance.Confirm(new ConfirmConfig
            {
                Title = "Confirm",
                Message = "Hello world!",
                ConfirmButtonText = "Confirm",
                ConfirmButtonClickAction = () => MessagingService.Instance.Snackbar("Confirmed"),
                CancelButtonText = "Cancel",
                CancelButtonClickAction = () => MessagingService.Instance.Snackbar("Cancelled")
            });
        }

        public void Delete()
        {
            MessagingService.Instance.Delete(new DeleteConfig
            {
                Title = "Delete",
                Message = "Hello world!",
                DeleteButtonText = "Delete",
                DeleteButtonClickAction = () => MessagingService.Instance.Snackbar("Deleted"),
                CancelButtonText = "Cancel",
                CancelButtonClickAction = () => MessagingService.Instance.Snackbar("Cancelled")
            });
        }

        public async void Loading()
        {
            MessagingService.Instance.ShowLoading(new LoadingConfig { Title = "Loading", Message = "Hello World!" });

            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

            MessagingService.Instance.HideLoading();
        }

        public void Prompt()
        {
            MessagingService.Instance.Prompt(new PromptConfig
            {
                Title = "Prompt",
                Message = "Hello world!",
                Hint = "Enter some text",
                ConfirmButtonText = "Enter",
                ConfirmButtonClickAction = (s) => MessagingService.Instance.Snackbar($"You entered: {s}"),
                CancelButtonText = "Cancel",
                CancelButtonClickAction = () => MessagingService.Instance.Snackbar("Cancelled")
            });
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