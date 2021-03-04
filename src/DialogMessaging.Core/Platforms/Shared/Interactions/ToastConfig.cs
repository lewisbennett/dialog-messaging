using DialogMessaging.Interactions.Base;

namespace DialogMessaging.Interactions
{
    public static partial class ToastConfigDefaults
    {
    }

    public partial interface IToastConfig : IBaseInteraction
    {
    }

    public partial class ToastConfig : BaseInteraction, IToastConfig
    {
    }
}
