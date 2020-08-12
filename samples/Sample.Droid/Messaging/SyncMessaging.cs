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
                ItemClickAction = (item) => MessagingServiceCore.Instance.Toast($"Clicked: {item.Text}"),
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemConfig { Text = "Item 1" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 2" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 3" });

            MessagingServiceCore.Instance.ActionSheet(config);
        }

        public void ActionSheetBottom()
        {
            var config = new ActionSheetBottomConfig
            {
                Title = "Action Sheet Bottom",
                Message = "Hello world!",
                ItemClickAction = (item) => MessagingServiceCore.Instance.Toast($"Clicked: {item.Text}"),
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemConfig { Text = "Item 1" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 2" });
            config.Items.Add(new ActionSheetItemConfig { Text = "Item 3" });

            MessagingServiceCore.Instance.ActionSheetBottom(config);
        }

        public void Alert()
        {
            MessagingServiceCore.Instance.Alert(new AlertConfig
            {
                Title = "Alert",
                Message = "Hello world!",
                OkButtonText = "Okay",
                OkButtonClickAction = () => MessagingServiceCore.Instance.Snackbar("Okay-ed")
            });
        }

        public void Confirm()
        {
            MessagingServiceCore.Instance.Confirm(new ConfirmConfig
            {
                Title = "Confirm",
                Message = "Hello world!",
                ConfirmButtonText = "Confirm",
                ConfirmButtonClickAction = () => MessagingServiceCore.Instance.Snackbar("Confirmed"),
                CancelButtonText = "Cancel",
                CancelButtonClickAction = () => MessagingServiceCore.Instance.Snackbar("Cancelled")
            });
        }

        public void Delete()
        {
            MessagingServiceCore.Instance.Delete(new DeleteConfig
            {
                Title = "Delete",
                Message = "Hello world!",
                DeleteButtonText = "Delete",
                DeleteButtonClickAction = () => MessagingServiceCore.Instance.Snackbar("Deleted"),
                CancelButtonText = "Cancel",
                CancelButtonClickAction = () => MessagingServiceCore.Instance.Snackbar("Cancelled")
            });
        }

        public async void Loading()
        {
            MessagingServiceCore.Instance.ShowLoading(new LoadingConfig { Title = "Loading", Message = "Hello World!" });

            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

            MessagingServiceCore.Instance.HideLoading();
        }

        public void Prompt()
        {
            MessagingServiceCore.Instance.Prompt(new PromptConfig
            {
                Title = "Prompt",
                Message = "Hello world!",
                Hint = "Enter some text",
                ConfirmButtonText = "Enter",
                ConfirmButtonClickAction = (s) => MessagingServiceCore.Instance.Snackbar($"You entered: {s}"),
                CancelButtonText = "Cancel",
                CancelButtonClickAction = () => MessagingServiceCore.Instance.Snackbar("Cancelled")
            });
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