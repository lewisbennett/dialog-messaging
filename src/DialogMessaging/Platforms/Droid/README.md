# DialogMessaging (Android)

## Getting started

At the entry point for your app, call `DialogMessaging.MessagingService.Init(...)`. You need to provide an activity or
application reference, and you can optionally provide your
own [`IDialogMessagingActivityLifecycleCallbacks`](https://github.com/lewisbennett/dialog-messaging/blob/master/src/DialogMessaging.Core/Platforms/Droid/Callbacks/IDialogMessagingActivityLifecycleCallbacks.cs)
and/or [`IMessagingService`](https://github.com/lewisbennett/dialog-messaging/blob/master/src/DialogMessaging.Core/Platforms/Shared/IMessagingService.cs)
implementations.

In order for dialog layouts to function properly, DialogMessaging needs to be notified when an Android view has been
inflated within your app. This functionality is provided
by [ViewPump](https://github.com/lewisbennett/viewpump/tree/master). DialogMessaging will automatically initialize
ViewPump for you if it hasn't already been initialized. This means that DialogMessaging will respect any configuration
you make to ViewPump as long as ViewPump is initialized first. For example:

```
public override void OnCreate()
{
    base.OnCreate();

    // Uncomment to initialize ViewPump with custom configuration.
    //InterceptingService.Init();

    // If the line above is commented, DialogMessaging will initialize ViewPump.
    MessagingService.Init(this);
}
```

[Full example](https://github.com/lewisbennett/dialog-messaging/blob/master/samples/Sample.Droid/MainApplication.cs)
available in
the [Android sample project](https://github.com/lewisbennett/dialog-messaging/tree/master/samples/Sample.Droid).
