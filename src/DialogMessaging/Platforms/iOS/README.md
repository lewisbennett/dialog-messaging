# DialogMessaging (iOS)

## Getting started

At the entry point for your app, call `DialogMessaging.MessagingService.Init(...)`. You need to provide your app's primary `UIWindow` instance, which can be accessed within your `AppDelegate` file. For example:

```
[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        MessagingService.Init(Window);

        ...

        return true;
    }
}
```

[Full example](https://github.com/lewisbennett/dialog-messaging/blob/master/samples/Sample.iOS/AppDelegate.cs) available in the [iOS sample project](https://github.com/lewisbennett/dialog-messaging/tree/master/samples/Sample.iOS).
