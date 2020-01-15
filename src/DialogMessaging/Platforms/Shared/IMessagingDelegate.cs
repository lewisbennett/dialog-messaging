using DialogMessaging.Interactions;

namespace DialogMessaging
{
    public interface IMessagingDelegate
    {
        #region Public Methods
        bool OnActionSheetRequested(IActionSheetConfig config);
        bool OnActionSheetBottomRequested(IActionSheetBottomConfig config);
        bool OnAlertRequested(IAlertConfig config);
        bool OnConfirmRequested(IConfirmConfig config);
        bool OnDeleteRequested(IDeleteConfig config);
        bool OnHideLoadingRequested();
        bool OnPromptRequested(IPromptConfig config);
        bool OnShowLoadingRequested(ILoadingConfig config);
        bool OnSnackbarRequested(ISnackbarConfig config);
        bool OnToastRequested(IToastConfig config);
        #endregion
    }
}
