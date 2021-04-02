﻿using DialogMessaging;
using DialogMessaging.Interactions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.MvvmCross.Core.Messaging
{
    public class AsyncMessaging : IMessaging
    {
        private int _loadingCount;

        public async void ActionSheet()
        {
            var config = new ActionSheetAsyncConfig
            {
                Title = "Action Sheet Async",
                Message = "Hello world!",
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemAsyncConfig { Message = "Item 1" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Message = "Item 2" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Message = "Item 3" });

            var item = await MessagingService.Instance.ActionSheetAsync(config).ConfigureAwait(false);

            if (item != null)
                MessagingService.Instance.Toast($"Clicked: {item.Message}");
        }

        public async void ActionSheetBottom()
        {
            var config = new ActionSheetBottomAsyncConfig
            {
                Title = "Action Sheet Bottom Async",
                Message = "Hello world!",
                CancelButtonText = "Cancel"
            };

            config.Items.Add(new ActionSheetItemAsyncConfig { Message = "Item 1" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Message = "Item 2" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Message = "Item 3" });

            var item = await MessagingService.Instance.ActionSheetBottomAsync(config).ConfigureAwait(false);

            if (item != null)
                MessagingService.Instance.Toast($"Clicked: {item.Message}");
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
            var config = new LoadingAsyncConfig { Title = "Loading Async", Message = "Hello World!" };

            await MessagingService.Instance.ShowLoadingAsync(config, LoadingDelayAsync(config, _loadingCount++)).ConfigureAwait(false);
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

        private async Task LoadingDelayAsync(LoadingAsyncConfig config, int loadingCount)
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

                })).ConfigureAwait(false);

                timer.Dispose();
            }
            else
                await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
        }
    }
}