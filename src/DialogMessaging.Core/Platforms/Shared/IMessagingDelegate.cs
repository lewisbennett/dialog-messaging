using DialogMessaging.Interactions;

namespace DialogMessaging
{
    public interface IMessagingDelegate
    {
        #region Methods
        /// <summary>
        /// Called when an action sheet dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnActionSheetRequested<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig;

        /// <summary>
        /// Called when a bottom-based action sheet dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnActionSheetBottomRequested<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig;

        /// <summary>
        /// Called when an alert dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnAlertRequested(IAlertConfig config);

        /// <summary>
        /// Called when a confirm dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnConfirmRequested(IConfirmConfig config);

        /// <summary>
        /// Called when a delete dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnDeleteRequested(IDeleteConfig config);

        /// <summary>
        /// Called when a loading dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnLoadingRequested(ILoadingConfig config);

        /// <summary>
        /// Called when a login dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnLoginRequested(ILoginConfig config);

        /// <summary>
        /// Called when a prompt dialog is requested.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        bool OnPromptRequested(IPromptConfig config);

        /// <summary>
        /// Called when a Snackbar is requested.
        /// </summary>
        /// <param name="config">The Snackbar configuration.</param>
        bool OnSnackbarRequested(ISnackbarConfig config);

        /// <summary>
        /// Called when a Toast is requested.
        /// </summary>
        /// <param name="config">The Toast configuration.</param>
        bool OnToastRequested(IToastConfig config);
        #endregion
    }
}
