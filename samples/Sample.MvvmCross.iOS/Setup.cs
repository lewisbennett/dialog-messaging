using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;

namespace Sample.MvvmCross.iOS
{
    public class Setup : MvxIosSetup<Core.App>
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
}