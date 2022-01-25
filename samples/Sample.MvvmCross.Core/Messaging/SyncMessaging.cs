using System;
using System.Threading;
using System.Threading.Tasks;
using DialogMessaging;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;

namespace Sample.MvvmCross.Core.Messaging;

public class SyncMessaging : IMessaging
{
    private int _loadingCount;

    public void ActionSheet()
    {
        var config = new ActionSheetConfig
        {
            Title = "Action Sheet",
            Message = "Hello world!",
            ItemClickAction = (item) => MessagingService.Instance.Toast($"Clicked: {item.Message}"),
            CancelButtonText = "Cancel"
        };

        config.Items.Add(new ActionSheetItemConfig { Message = "Item 1" });
        config.Items.Add(new ActionSheetItemConfig { Message = "Item 2" });
        config.Items.Add(new ActionSheetItemConfig { Message = "Item 3" });

        MessagingService.Instance.ActionSheet(config);
    }

    public void ActionSheetBottom()
    {
        var config = new ActionSheetBottomConfig
        {
            Title = "Action Sheet Bottom",
            Message = "Hello world!",
            ItemClickAction = (item) => MessagingService.Instance.Toast($"Clicked: {item.Message}"),
            CancelButtonText = "Cancel"
        };

        config.Items.Add(new ActionSheetItemConfig { Message = "Item 1" });
        config.Items.Add(new ActionSheetItemConfig { Message = "Item 2" });
        config.Items.Add(new ActionSheetItemConfig { Message = "Item 3" });

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
            CancelButtonClickAction = () => MessagingService.Instance.Snackbar("Canceled")
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
            CancelButtonClickAction = () => MessagingService.Instance.Snackbar("Canceled")
        });
    }

    public async void Loading()
    {
        var config = new LoadingConfig { Title = "Loading", Message = "Hello World!" };

        var loading = MessagingService.Instance.Loading(config);

        await LoadingDelayAsync(config, _loadingCount++);

        loading.Dispose();
    }

    public void Login()
    {
        MessagingService.Instance.Login(new LoginConfig
        {
            Title = "Login",
            Message = "Enter your login credentials.",
            UsernameHint = "Username",
            UsernameInputType = InputType.EmailAddress,
            PasswordHint = "Password",
            LoginButtonText = "Login",
            CancelButtonText = "Cancel",
            LoginButtonClickAction = (username, password) =>
            {
                MessagingService.Instance.Snackbar($"Username: {username}\nPassword: {password}");
            },
            CancelButtonClickAction = () => MessagingService.Instance.Snackbar("Canceled")
        });
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
            CancelButtonClickAction = () => MessagingService.Instance.Snackbar("Canceled")
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

    private async Task LoadingDelayAsync(LoadingConfig config, int loadingCount)
    {
        if (loadingCount % 2 == 0)
        {
            Timer timer = null;

            await Task.WhenAll(Task.Delay(TimeSpan.FromSeconds(5)), Task.Run(() =>
            {
                timer = new Timer((_) =>
                {
                    if (config.Progress.HasValue)
                        config.Progress++;
                    else
                        config.Progress = 0;

                }, null, 0, 40);
            }));

            timer.Dispose();
        }
        else
            await Task.Delay(TimeSpan.FromSeconds(5));
    }
}