using ViewPump.Intercepting;

namespace DialogMessaging.Platforms.Droid.Infrastructure
{
    public class DialogMessagingInterceptor : IInterceptor
    {
        #region Public Methods
        public InflateResult Intercept(IChain chain)
        {
            var result = chain.Proceed();

            MessagingService.OnViewInflated(result.View, result.Attrs);

            return result;
        }
        #endregion
    }
}
