using Microsoft.Extensions.Logging;
using MvvmCross.Binding;
using MvvmCross.Platforms.Android.Core;
using Sample.MvvmCross.Core;
using Sample.MvvmCross.Droid.Binding;

namespace Sample.MvvmCross.Droid;

public class Setup : MvxAndroidSetup<App>
{
    protected override MvxBindingBuilder CreateBindingBuilder()
    {
        return new BindingBuilder();
    }

    protected override ILoggerFactory CreateLogFactory()
    {
        return null;
    }

    protected override ILoggerProvider CreateLogProvider()
    {
        return null;
    }
}