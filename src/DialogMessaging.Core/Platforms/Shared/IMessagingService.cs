using System;
using System.Threading;
using System.Threading.Tasks;
using DialogMessaging.Interactions;

namespace DialogMessaging;

public interface IMessagingService
{
    #region Methods
    /// <summary>
    ///     Display an action sheet dialog.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable ActionSheet(ActionSheetConfig config);

    /// <summary>
    ///     Display an action sheet dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task<ActionSheetItemAsyncConfig> ActionSheetAsync(ActionSheetAsyncConfig config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display an action sheet dialog from the bottom of the screen.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable ActionSheetBottom(ActionSheetBottomConfig config);

    /// <summary>
    ///     Display an action sheet dialog from the bottom of the screen asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task<ActionSheetItemAsyncConfig> ActionSheetBottomAsync(ActionSheetBottomAsyncConfig config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display an alert dialog.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable Alert(AlertConfig config);

    /// <summary>
    ///     Display an alert dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task<bool> AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display a confirm dialog.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable Confirm(ConfirmConfig config);

    /// <summary>
    ///     Display a confirm dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task<bool> ConfirmAsync(ConfirmAsyncConfig config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display a delete dialog.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable Delete(DeleteConfig config);

    /// <summary>
    ///     Display a delete dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task<bool> DeleteAsync(DeleteAsyncConfig config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display a loading dialog.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable Loading(LoadingConfig config);

    /// <summary>
    ///     Display a loading dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    /// <param name="task">A function to retrieve the task to execute.</param>
    Task LoadingAsync(LoadingAsyncConfig config, Func<Task> task, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display a loading dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    /// <param name="task">A function to retrieve the task to execute.</param>
    Task<T> LoadingAsync<T>(LoadingAsyncConfig config, Func<Task<T>> task, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display a login dialog.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable Login(LoginConfig config);

    /// <summary>
    ///     Display a login dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task<(string, string)> LoginAsync(LoginAsyncConfig config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display a prompt dialog.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable Prompt(PromptConfig config);

    /// <summary>
    ///     Display a prompt dialog asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task<string> PromptAsync(PromptAsyncConfig config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Shows a dialog of unknown configuration type.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    IDisposable ShowDialog(object config);

    /// <summary>
    ///     Shows a dialog of unknown configuration type asynchronously.
    /// </summary>
    /// <param name="config">The dialog configuration.</param>
    Task ShowDialogAsync(object config, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Display a Snackbar.
    /// </summary>
    /// <param name="config">The Snackbar configuration.</param>
    IDisposable Snackbar(SnackbarConfig config);

    /// <summary>
    ///     Display a Toast.
    /// </summary>
    /// <param name="config">The Toast configuration.</param>
    IDisposable Toast(ToastConfig config);
    #endregion
}