using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using Sample.MvvmCross.Core;

namespace Sample.MvvmCross.iOS;

public class Setup : MvxIosSetup<App>
{
    protected override ILoggerFactory CreateLogFactory()
    {
        return new LoggerFactory();
    }

    protected override ILoggerProvider CreateLogProvider()
    {
        return null;
    }
}