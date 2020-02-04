using DialogMessaging;
using DialogMessaging.Interactions;

namespace Sample.Droid
{
    public static class Extensions
    {
        /// <summary>
        /// Shows a toast to the user.
        /// </summary>
        /// <param name="message">The toast message.</param>
        public static void Snackbar(this IMessagingService messagingService, string message)
        {
            messagingService.Snackbar(new SnackbarConfig
            {
                Message = message
            });
        }

        /// <summary>
        /// Shows a toast to the user.
        /// </summary>
        /// <param name="message">The toast message.</param>
        public static void Toast(this IMessagingService messagingService, string message)
        {
            messagingService.Toast(new ToastConfig
            {
                Message = message
            });
        }
    }
}