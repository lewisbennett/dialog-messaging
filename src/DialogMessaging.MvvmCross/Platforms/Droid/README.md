# DialogMessaging.MvvmCross (Android)

## Getting started

Install `DialogMessaging.MvvmCross` from [NuGet](https://www.nuget.org/packages/DialogMessaging.MvvmCross/), or add a project reference to `DialogMessaging.Core` and `DialogMessaging.MvvmCross`.

At the entry point for your app, call `DialogMessaging.MessagingService.Init(...)`. You need to provide an activity or application reference, and you can optionally provide your own [`IDialogMessagingActivityLifecycleCallbacks`]() and/or [`IMessagingService`]() implementations.
