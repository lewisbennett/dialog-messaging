﻿using DialogMessaging.Interactions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DialogMessaging
{
    public interface IMessagingService
    {
        #region Public Methods
        /// <summary>
        /// Displays an action sheet to the user.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        IDisposable ActionSheet(IActionSheetConfig config);

        /// <summary>
        /// Displays an action sheet to the user asynchronously.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        Task<IActionSheetItemConfig> ActionSheetAsync(ActionSheetAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Displays a bottom action sheet to the user.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        IDisposable ActionSheetBottom(IActionSheetBottomConfig config);

        /// <summary>
        /// Displays a bottom action sheet to the user asynchronously.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        Task<IActionSheetItemConfig> ActionSheetBottomAsync(ActionSheetBottomAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        IDisposable Alert(IAlertConfig config);

        /// <summary>
        /// Displays an alert to the user asynchronously.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        Task AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Displays a confirm dialog to the user.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        IDisposable Confirm(IConfirmConfig config);

        /// <summary>
        /// Displays a confirm dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        Task<bool> ConfirmAsync(ConfirmAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Shows a delete dialog to the user.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        IDisposable Delete(IDeleteConfig config);

        /// <summary>
        /// Displays a delete dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        Task<bool> DeleteAsync(DeleteAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        void HideLoading();

        /// <summary>
        /// Displays a login to the user.
        /// </summary>
        /// <param name="config">The login configuration.</param>
        IDisposable Login(ILoginConfig config);

        /// <summary>
        /// Displays a login to the user asynchronously.
        /// </summary>
        /// <param name="config">The login configuration.</param>
        Task<(string, string)> LoginAsync(LoginAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Displays a prompt to the user.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        IDisposable Prompt(IPromptConfig config);

        /// <summary>
        /// Displaus a prompt to the user asynchronously.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        Task<string> PromptAsync(PromptAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Displays a loading wheel to the user.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        IDisposable ShowLoading(ILoadingConfig config);

        /// <summary>
        /// Displays a loading wheel to the user that is shown alongside execution of a task.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        /// <param name="task">The task to execute.</param>
        TTask ShowLoadingAsync<TTask>(LoadingAsyncConfig config, TTask task, CancellationToken cancellationToken = default) where TTask : Task;

        /// <summary>
        /// Displays a snackbar to the user.
        /// </summary>
        /// <param name="config">The snackbar configuration.</param>
        void Snackbar(ISnackbarConfig config);

        /// <summary>
        /// Displays a toast to the user.
        /// </summary>
        /// <param name="config">The toast configuration.</param>
        void Toast(IToastConfig config);
        #endregion
    }
}
