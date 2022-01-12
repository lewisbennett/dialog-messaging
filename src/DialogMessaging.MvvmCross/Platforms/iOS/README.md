# DialogMessaging.MvvmCross (iOS)

## Getting started

At the entry point for your app, call `DialogMessaging.MessagingService.Init(...)`. You need to provide your app's
primary `UIWindow` instance, which can be accessed within your `AppDelegate` file. For example:

```
[Register ("AppDelegate")]
public class AppDelegate : MvxApplicationDelegate<Setup, Core.App>
{
    public override UIWindow Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        var result = base.FinishedLaunching(application, launchOptions);

        MessagingService.Init(Window);
        
        ...
        
        return result;
    }
}
```

[Full example](https://github.com/lewisbennett/dialog-messaging/blob/release-1.0.0/samples/Sample.MvvmCross.iOS/AppDelegate.cs)
available in
the [MvvmCross iOS sample project](https://github.com/lewisbennett/dialog-messaging/tree/release-1.0.0/samples/Sample.MvvmCross.iOS)
.
