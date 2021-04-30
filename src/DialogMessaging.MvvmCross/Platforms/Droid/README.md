# DialogMessaging.MvvmCross (Android)

## Getting started

At the entry point for your app, call `DialogMessaging.MessagingService.Init(...)`. You need to provide an activity or application reference, and you can optionally provide your own [`IDialogMessagingActivityLifecycleCallbacks`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Droid/Callbacks/IDialogMessagingActivityLifecycleCallbacks.cs) and/or [`IMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/src/DialogMessaging.Core/Platforms/Shared/IMessagingService.cs) implementations.

In order for dialog layouts to function properly, DialogMessaging needs to be notified when an Android view has been inflated within your app. When using MvvmCross, this is done by providing a custom `MvxAndroidViewBinder` class. From within this class, you must call `DialogMessaging.MessagingService.ViewManager.OnViewInflated(...);`, for example:

```
public class ViewBinder : MvxAndroidViewBinder
{
    public override void BindView(View view, Context context, IAttributeSet attrs)
    {
        base.BindView(view, context, attrs);

        DialogMessaging.MessagingService.ViewManager.OnViewInflated(view, attrs);
        
        ...
    }

    public ViewBinder(object source)
        : base(source)
    {
    }
}
```

[Full example](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/samples/Sample.MvvmCross.Droid/Binding) available in the [MvvmCross Android sample project](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/samples/Sample.MvvmCross.Droid).
